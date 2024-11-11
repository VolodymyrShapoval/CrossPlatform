using Lab4.Library;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Source
{
    [Command(Name = "Lab4", Description = "Console app for lab 4")]
    [HelpOption]
    [Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CommandLineApplication.Execute<Program>(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void OnExecute()
        {
            Console.WriteLine("Invalid command. Use one of the following commands:");
            Console.WriteLine("  version      - Display information about the program (author, version)");
            Console.WriteLine("  run <lab#>   - Run the corresponding lab work (lab1, lab2, lab3)");
            Console.WriteLine("  set-path -p <path> - Set the path to the files (input/output)");
            Console.WriteLine("To view detailed command usage, add '--help' after the command name.");
        }

        [Command("version", Description = "Output the information about the program")]
        private class VersionCommand
        {
            private void OnExecute()  // Change this to public
            {
                Console.WriteLine("Author: Volodymyr Shapoval");
                Console.WriteLine("Version: 1.0.0");
            }
        }

        [Command("set-path", Description = "Set the default path for input/output files")]
        private class SetPathCommand
        {
            [Option("-P|--path <PATH>", "Path to the folder with input and output files", CommandOptionType.SingleValue)]
            [Required]
            public string LabPath { get; set; } = string.Empty;

            private void OnExecute()
            {
                if (string.IsNullOrEmpty(LabPath))
                {
                    Console.WriteLine("Error: The folder at the specified path was not found. Enter a valid path using -p or --path to specify the path.");
                    return;
                }

                EnvironmentVariableTarget target = EnvironmentVariableTarget.User;
                Environment.SetEnvironmentVariable("LAB_PATH", LabPath, target);
                Console.WriteLine($"LAB_PATH set to: {LabPath}");
            }
        }

        [Command("run", Description = "Run the specific lab")]
        [Subcommand(typeof(Lab1Command), typeof(Lab2Command), typeof(Lab3Command))]
        private class RunCommand  // Change this to RunCommand
        {
            private void OnExecute()  // Change this to public
            {
                Console.WriteLine("Choose the subcommand: lab1, lab2, lab3");
            }
        }

        [Command("lab1", Description = "Run lab 1")]
        private class Lab1Command : LabCommandBase
        {
            protected override void OnExecute()
            {
                base.OnExecute();
                LabsLibrary.ExecuteLab(1, InputFilePath!, OutputFilePath!);
            }
        }

        [Command("lab2", Description = "Run lab 2")]
        private class Lab2Command : LabCommandBase
        {
            protected override void OnExecute()
            {
                base.OnExecute();
                LabsLibrary.ExecuteLab(2, InputFilePath!, OutputFilePath!);
            }
        }

        [Command("lab3", Description = "Run lab 3")]
        private class Lab3Command : LabCommandBase
        {
            protected override void OnExecute()
            {
                base.OnExecute();
                LabsLibrary.ExecuteLab(3, InputFilePath!, OutputFilePath!);
            }
        }

        public abstract class LabCommandBase
        {
            [Option("-I|--input <INPUT>", "Input file", CommandOptionType.SingleValue)]
            public string? InputFilePath { get; set; } = null;

            [Option("-o|--output <OUTPUT>", "Output file", CommandOptionType.SingleValue)]
            public string? OutputFilePath { get; set; } = null;


            protected void SetPath()
            {
                // 1. Якщо шлях до файлу заданий параметрами консолі 
                if (!string.IsNullOrEmpty(InputFilePath) && !string.IsNullOrEmpty(OutputFilePath))
                    return;

                // 2. Перевірка значення змінної “LAB_PATH”
                EnvironmentVariableTarget target = EnvironmentVariableTarget.User;
                string? envPath = Environment.GetEnvironmentVariable("LAB_PATH", target);
                if (!string.IsNullOrEmpty(envPath))
                {
                    InputFilePath ??= Path.Combine(envPath, "input.txt");
                    OutputFilePath ??= Path.Combine(envPath, "output.txt");
                    return;
                }

                // 3. Перевірка наявності файлу index.txt в домашній директорії користувача
                string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string indexFilePath = Path.Combine(homeDirectory, "input.txt");
                if (File.Exists(indexFilePath))
                {
                    InputFilePath ??= indexFilePath;
                    OutputFilePath ??= Path.Combine(homeDirectory, "output.txt");
                    return;
                }

                if (!File.Exists(InputFilePath))
                    throw new Exception("Could not find the specified input file.");
            }

            protected virtual void OnExecute()
            {
                SetPath();
            }
        }
    }
}

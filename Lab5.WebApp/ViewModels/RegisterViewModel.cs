using System.ComponentModel.DataAnnotations;

namespace Lab5.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Ім'я користувача не може перевищувати 50 символів")]
        public string Username { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "ФІО не може перевищувати 500 символів")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль має бути від 8 до 16 символів")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", ErrorMessage = "Пароль повинен містити хоча б одну велику літеру, одну цифру та один спеціальний символ")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Phone(ErrorMessage = "Некоректний формат телефону")]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Номер телефону має бути у форматі +380XXXXXXXXX")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Некоректний формат електронної пошти")]
        public string Email { get; set; }
    }
}

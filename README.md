# CrossPlatform
Volodymyr Shapoval SE-31

**Command for building project:**
dotnet build Build.proj -p:Solution=Lab1 -t:Build

**Command for running project:**
dotnet build Build.proj -p:Solution=Lab1 -t:Run

**Command for testing project:** 
dotnet build Build.proj -p:Solution=Lab1 -t:Test

**Scripts for LAB3 – HOW TO CREATE YOUR NUGET PACKAGE AND ADD IT TO YOUR PROJECT**
1. Створюємо папку для локального репозиторію NuGet. 
mkdir NUGET_REPO_PATH

2. Створюємо NuGet пакет та публікуємо його в нашому локальному репозиторії
cd LIBRARY_PATH
dotnet pack --output NUGET_REPO_PATH

3. Підключаємо репозиторій до нашого проекту
cd ..
cd PROJECT_PATH
dotnet nuget add source NUGET_REPO_PATH --name RepoName

4. Додаємо NuGet пакет до нашого проекту:
dotnet add package VShapoval_Chess --version 1.0.0 --source NUGET_REPO_PATH

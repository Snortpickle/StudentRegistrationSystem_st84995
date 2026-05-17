Student Registration System

Theme:Student registration system (registration of students for courses).

How to run
1. Open `StudentRegistrationSystem.sln` in Visual Studio 2022.
2. Restore NuGet packages (it will happen automatically).
3. Run the `StudentRegistrationSystem` project.

Login
- admin / admin

Data storage
Data is stored in XML:
`%LOCALAPPDATA%\StudentRegistrationSystem\database.xml`

Requirements coverage
- OOP: classes `Student`, `Course`, `Enrollment`, services, MVVM-ish structure.
- GUI: WPF windows, dialogs, DataGrid + filters.
- Data storage and processing: CRUD + XML persistence.
- Filtering: by name, group, study year, scholarship, department (>=3 filters).
- Calculations: count students in group, average grade for course, total credits for student (>=2 calculations).
- Unit test: xUnit test for `LoginService.Login()` (admin/admin).

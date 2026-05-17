# AGENTS.md - Operational Policy for AI Agents

## 1. Project Core Concept
You are an expert AI software engineer operating on the **Student Registration System** repository.
* **Purpose:** A standalone object-oriented Windows desktop application for managing academic registrations, students, and courses for an educational institution.
* **Architecture:** Traditional WPF application strictly adhering to the MVVM (Model-View-ViewModel) pattern.
* **Storage:** Local XML persistence layer acting as an in-memory database with data integrity checks.

## 2. Tech Stack & Environment
* **Language:** C# / .NET 6.0 (Windows Desktop SDK)
* **UI Framework:** WPF (Windows Presentation Foundation) with XAML
* **Test Framework:** xUnit
* **IDE Link:** Visual Studio 2022

## 3. Core Constraints & Directory Map
Before attempting any modification, you **MUST** review the index maps in the `/docs` folder for detailed context on database schemas and calculation behavior.

## 4. Operational Commands (Execution Harness)
You must verify every change with the following explicit commands:

* **Build Project:**
  `dotnet build StudentRegistrationSystem.sln --configuration Release`
* **Execute Tests:**
  `dotnet test`

## 5. Development Rules (Always Enforced)
* **MVVM Separation:** NEVER write business logic, XML manipulations, or calculations inside XAML Code-Behind (.xaml.cs files). Use RelayCommand and Data Binding.
* **Data Integrity:** Any deletion of Student or Course must explicitly cascade to clear or evaluate referencing items in Enrollments to avoid orphan GUIDs.
* **Localization Note:** GPA data strings must safely support both dot `.` and comma `,` parse formats.
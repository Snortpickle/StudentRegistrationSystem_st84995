# 🎓 Student Registration System

A WPF desktop application for managing students, courses, and enrollments.

The project demonstrates object-oriented design, MVVM architecture, XML-based persistence, filtering, reporting calculations, unit testing, and AI-assisted engineering documentation.

---

## 📌 Project Theme

**Student registration system** for managing student enrollment in courses.

The application allows users to:

- manage students;
- manage courses;
- manage enrollments;
- filter student and course lists;
- reset filters using a dedicated Command Pattern module;
- calculate useful academic statistics.

---

## 🧰 Technology Stack

| Area | Technology |
|---|---|
| Language | C# |
| Framework | .NET / WPF |
| UI | XAML |
| Architecture | MVVM |
| Data Storage | XML |
| Testing | xUnit |
| IDE | Visual Studio 2022 |
| Version Control | Git + GitHub |

---

## 🚀 How to Run

1. Open the solution file in Visual Studio 2022:

```text
StudentRegistrationSystem.sln
```

2. Restore NuGet packages.

This usually happens automatically when the solution is opened.

3. Build the solution:

```text
Build → Build Solution
```

or:

```text
Ctrl + Shift + B
```

4. Run the project:

```text
StudentRegistrationSystem
```

---

## 🔐 Login

Use the default credentials:

| Username | Password |
|---|---|
| `admin` | `admin` |

---

## 💾 Data Storage

Application data is stored locally in XML format.

```text
%LOCALAPPDATA%\StudentRegistrationSystem\database.xml
```

The XML storage layer supports basic CRUD persistence for the application entities.

---

## ✨ Core Features

### 👨‍🎓 Student Management

- Add students
- Edit students
- Delete students
- Filter students by:
  - name
  - group
  - study year
  - scholarship status

### 📚 Course Management

- Add courses
- Edit courses
- Delete courses
- Filter courses by department

### 📝 Enrollment Management

- Register students for courses
- Manage course enrollments
- View student-course relationships

### 🔎 Filter Reset Feature

The application includes reset controls:

- `Show all students`
- `Show all courses`

These controls clear active filters and display the full list again.

The reset logic is implemented through a dedicated `FilterReset` module using the **Command Pattern**.

---

## 🧱 Architecture

The project follows the **MVVM** architectural pattern.

```text
Views
↓
ViewModels
↓
Services / Modules
↓
Models
↓
XML Data Storage
```

### Main Architectural Layers

| Layer | Responsibility |
|---|---|
| `Views` | WPF XAML user interface |
| `ViewModels` | UI state, commands, and interaction logic |
| `Models` | Domain entities such as Student, Course, and Enrollment |
| `Services` | Data access and application services |
| `Modules` | Feature-specific logic such as filter reset |
| `docs` | Requirements, architecture, design contracts, and experiments |

---

## 🧩 Design Patterns Used

### MVVM

Used to separate the WPF interface from application logic.

### Command Pattern

Used for filter reset actions.

The reset buttons are connected to ViewModel commands, which delegate reset behavior to the dedicated module.

```text
MainWindow.xaml
→ MainViewModel
→ Reset Filter Commands
→ FilterResetService
→ Updated filter state
```

### Service Layer

Used to isolate data processing and persistence logic.

---

## 🧪 Testing

The project includes unit tests using **xUnit**.

Current test coverage includes:

- login validation;
- reset filter service behavior;
- deterministic pure function behavior.

To build the solution in Visual Studio:

```text
Ctrl + Shift + B
```

Expected result:

```text
Build succeeded.
0 errors.
```

---

## 📊 Requirements Coverage

| Requirement Area | Covered |
|---|---|
| OOP classes | ✅ |
| Student, Course, Enrollment models | ✅ |
| Services | ✅ |
| MVVM structure | ✅ |
| GUI with forms and dialogs | ✅ |
| Filtering | ✅ |
| CRUD operations | ✅ |
| XML persistence | ✅ |
| Unit tests | ✅ |
| AI-assisted documentation | ✅ |
| Mermaid architecture diagrams | ✅ |
| Design Pattern module | ✅ |
| Spec-driven UI design | ✅ |

---

## 🤖 AI Engineering Harness

This project includes AI-assisted engineering documentation and experiments.

The AI workflow was not used only to generate code. It was used as part of a structured engineering process with requirements, architecture, patterns, and design constraints.

### Included Documentation

| Area | Path |
|---|---|
| BDD Requirements | `docs/requirements` |
| Architecture Diagrams | `docs/architecture` |
| Project Roadmap | `docs/plans/roadmap.md` |
| Design Contract | `docs/DESIGN.md` |
| Experiments | `docs/experiments` |

---

## 📐 Engineering Methods Used

### 1. Behavior-Driven Development

BDD requirements were written using:

```text
Given
When
Then
```

This helped describe feature behavior before implementation.

### 2. Architecture-as-Code

Mermaid diagrams were used to document system flow and module interaction.

### 3. Pure Function Experiment

The reset filter logic was tested as a predictable, side-effect-free function.

### 4. Design Pattern Implementation

The reset filter module was implemented using the **Command Pattern**.

### 5. Spec-Driven UI

The UI was updated using a strict design contract in:

```text
docs/DESIGN.md
```

This ensured that generated UI changes followed project-specific rules instead of producing generic interface code.

---

## 📁 Project Structure

```text
StudentRegistrationSystem
├── docs
│   ├── architecture
│   ├── experiments
│   ├── plans
│   ├── requirements
│   └── DESIGN.md
├── src
│   └── StudentRegistrationSystem
│       ├── Common
│       ├── Converters
│       ├── Models
│       ├── Modules
│       │   └── FilterReset
│       ├── Services
│       ├── ViewModels
│       └── Views
├── tests
├── README.md
└── StudentRegistrationSystem.sln
```

---

## 🧭 Important Documentation Links

- Requirements: `docs/requirements`
- Architecture: `docs/architecture`
- Roadmap: `docs/plans/roadmap.md`
- Design Contract: `docs/DESIGN.md`
- Filter Reset Module: `src/StudentRegistrationSystem/Modules/FilterReset`
- Experiment Logs: `docs/experiments`

---

## ✅ Current Status

| Component | Status |
|---|---|
| Student management | Complete |
| Course management | Complete |
| Enrollment management | Complete |
| XML persistence | Complete |
| Filter reset module | Complete |
| Command Pattern integration | Complete |
| Spec-driven UI update | Complete |
| Documentation | Complete |
| Build verification | Complete |

---

## 🧠 Summary

The **Student Registration System** is a WPF MVVM desktop application that combines practical student/course management features with structured software engineering methods.

It demonstrates:

- clean separation of concerns;
- modular feature implementation;
- XML persistence;
- testable business logic;
- design pattern usage;
- AI-assisted development with engineering constraints.

The project is designed not only to work, but also to show traceable architectural decisions.

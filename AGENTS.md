# AGENTS.md — Operational Policy for AI Agents

This document defines the operating rules for AI agents working on the **Student Registration System** repository.

AI agents must follow these instructions before making changes, generating code, editing documentation, or proposing architectural modifications.

---

## 1. Project Core Concept

The **Student Registration System** is a standalone object-oriented Windows desktop application for managing academic registration data.

### Purpose

The application manages:

- students;
- courses;
- enrollments;
- filtering and search;
- academic calculations;
- local XML-based persistence.

### Architecture

The project follows a traditional **WPF MVVM** architecture.

```text
Views
↓
ViewModels
↓
Services / Modules
↓
Models
↓
XML Storage
```

### Storage Model

The application uses local XML persistence as the data storage layer.

The XML layer acts as a lightweight local database and must preserve data integrity.

---

## 2. Technology Stack

| Area | Requirement |
|---|---|
| Language | C# |
| Runtime | .NET 6.0 |
| UI Framework | WPF |
| UI Markup | XAML |
| Architecture | MVVM |
| Persistence | XML |
| Test Framework | xUnit |
| IDE | Visual Studio 2022 |
| Platform | Windows Desktop |

---

## 3. Repository Map

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
│       ├── Services
│       ├── ViewModels
│       └── Views
├── tests
├── AGENTS.md
├── README.md
└── StudentRegistrationSystem.sln
```

### Key Folders

| Folder | Purpose |
|---|---|
| `src/StudentRegistrationSystem/Models` | Domain models such as `Student`, `Course`, and `Enrollment` |
| `src/StudentRegistrationSystem/ViewModels` | UI state, commands, and MVVM interaction logic |
| `src/StudentRegistrationSystem/Views` | WPF XAML windows and dialogs |
| `src/StudentRegistrationSystem/Services` | Persistence and application services |
| `src/StudentRegistrationSystem/Modules` | Feature-specific modules such as `FilterReset` |
| `tests` | xUnit test project |
| `docs` | Requirements, architecture, roadmap, design contracts, and experiments |

---

## 4. Required Context Review Before Changes

Before modifying code, an AI agent must review the relevant project context.

### Required Documents

| Task Type | Required Context |
|---|---|
| Feature behavior | `docs/requirements` |
| Architecture or flow | `docs/architecture` |
| UI changes | `docs/DESIGN.md` |
| Project scope | `docs/plans/roadmap.md` |
| Module changes | relevant module `README.md` |
| AI experiment work | `docs/experiments` |

### Rule

Do not generate code from vague assumptions.

If a requirement, diagram, or design contract exists, it must be treated as the source of truth.

Humanity has already produced enough software from “seems obvious”; this repository will not join the pile.

---

## 5. Operational Commands

AI agents should verify changes using the following commands when the environment supports them.

### Build

```bash
dotnet build StudentRegistrationSystem.sln --configuration Release
```

### Tests

```bash
dotnet test
```

### Environment Limitation

If the environment does not contain the .NET SDK, the agent must clearly report the limitation.

Example:

```text
dotnet: command not found
```

This must be documented as an environment limitation, not as proof that the project code is invalid.

---

## 6. Development Rules

### MVVM Separation

AI agents must preserve MVVM boundaries.

Do not place business logic in:

```text
MainWindow.xaml.cs
```

or other XAML code-behind files.

### Allowed UI Behavior

XAML may bind to:

- ViewModel properties;
- ViewModel commands;
- converters;
- styles and resources.

### Not Allowed in XAML Code-Behind

Do not add:

- database access;
- XML persistence logic;
- filtering calculations;
- business rules;
- direct collection manipulation;
- feature logic that belongs in ViewModels, Services, or Modules.

---

## 7. Data Integrity Rules

The XML persistence layer must be handled carefully.

AI agents must not:

- delete stored records unintentionally;
- rewrite XML structure without migration reasoning;
- break existing save/load behavior;
- create orphan enrollments;
- remove validation checks;
- cascade destructive changes without explicit requirements.

Any change affecting persistence must include a clear explanation and test coverage when possible.

---

## 8. Module and Feature Rules

Feature-specific logic should be placed in modules when it improves clarity and testability.

Current modules include:

```text
src/StudentRegistrationSystem/Modules/FilterReset
```

### Module Rules

A module should include:

- focused responsibility;
- clear public API;
- minimal dependencies;
- no direct UI control access;
- no database access unless explicitly required;
- README documentation explaining the module purpose.

### FilterReset Module

The `FilterReset` module is responsible for reset-filter behavior.

It uses:

- Command Pattern;
- immutable filter state models;
- pure reset calculations;
- ViewModel command integration.

The module must remain side-effect controlled.

---

## 9. Pure Function Rules

When implementing business calculations, prefer pure functions where possible.

A pure function must:

- return predictable output;
- avoid modifying input objects;
- avoid database access;
- avoid UI access;
- avoid direct collection mutation;
- avoid global mutable state.

Good:

```csharp
public static StudentFilterState ResetStudentFilters(StudentFilterState current)
{
    return new StudentFilterState(
        string.Empty,
        string.Empty,
        null,
        false
    );
}
```

Bad:

```csharp
Students.Clear();
MessageBox.Show("Filters reset");
SaveDatabase();
```

One returns a value. The other starts a tiny house fire.

---

## 10. Command Pattern Rules

User-triggered actions should be exposed through commands.

For WPF MVVM, buttons should bind to commands such as:

```xml
Command="{Binding ClearStudentFiltersCommand}"
Command="{Binding ClearCourseFiltersCommand}"
```

### Command Rules

Commands may:

- call ViewModel handlers;
- trigger service or module operations;
- coordinate UI state updates through the ViewModel.

Commands must not:

- access UI controls directly;
- perform database operations unless explicitly designed to do so;
- hide complex business logic inside anonymous callbacks.

---

## 11. UI Design Rules

All UI changes must follow:

```text
docs/DESIGN.md
```

### UI Requirements

AI agents must:

- use WPF XAML;
- preserve the existing desktop application structure;
- use readable labels;
- maintain spacing and alignment;
- use accessible control names where appropriate;
- keep buttons near the relevant feature area;
- bind actions through ViewModel commands.

### UI Anti-Patterns

Do not:

- replace the WPF app with React, Streamlit, or HTML;
- create generic dashboard cards unrelated to the feature;
- add business logic to XAML code-behind;
- use random colors outside the design contract;
- stack multiple unrelated primary buttons together;
- introduce inaccessible icon-only controls for important actions.

---

## 12. Documentation Rules

Every meaningful feature or architectural change should update documentation.

### Required Documentation Updates

| Change Type | Documentation |
|---|---|
| New feature | `docs/requirements` |
| New architecture flow | `docs/architecture` |
| New module | module-level `README.md` |
| UI design change | `docs/DESIGN.md` or relevant section |
| AI-assisted experiment | `docs/experiments` |
| Roadmap milestone | `docs/plans/roadmap.md` |

### Markdown Rules

Markdown files should use:

- clear headings;
- short paragraphs;
- tables where useful;
- code fences for commands and paths;
- relative file paths;
- no vague statements like “improved stuff”.

Yes, “improved stuff” is how future maintainers learn to hate past maintainers.

---

## 13. Testing Rules

AI agents should add or update tests when changing business logic.

### Test Areas

Tests should cover:

- service behavior;
- pure function outputs;
- command-related behavior where practical;
- validation rules;
- persistence behavior when relevant.

### Current Testing Stack

```text
xUnit
```

### Test Expectations

Tests should be:

- deterministic;
- focused;
- named clearly;
- independent from UI rendering;
- independent from local machine-specific paths when possible.

---

## 14. Git and Commit Rules

AI-generated changes should be small, reviewable, and scoped.

### Good Commit Examples

```text
add reset filter requirements
implement filter reset command module
add spec driven UI experiment log
fix xaml reset filter buttons
```

### Bad Commit Examples

```text
fix
update
changes
final
stuff
```

A commit message should explain what changed without requiring forensic analysis.

---

## 15. AI Prompting Rules

AI agents must work from explicit constraints.

Good prompts include:

- feature goal;
- relevant files;
- architecture rules;
- design constraints;
- prohibited changes;
- expected verification commands.

Bad prompts include:

```text
make it better
fix everything
build a dashboard
improve UI
```

These prompts are how software becomes soup.

---

## 16. Failure Reporting Rules

When something fails, report it clearly.

A failure report should include:

- command attempted;
- error message;
- likely cause;
- whether it is an environment issue or code issue;
- recommended next step.

Example:

```text
Command attempted:
dotnet build StudentRegistrationSystem.sln --configuration Release

Result:
dotnet: command not found

Reason:
The execution environment does not have the .NET SDK installed.

Next step:
Run the build locally in Visual Studio 2022.
```

---

## 17. Success Criteria

A change is considered complete only when:

- it follows the relevant requirement or design contract;
- code compiles locally or build limitation is documented;
- MVVM separation is preserved;
- documentation is updated;
- generated code is reviewed;
- GitHub links point to files on the `main` branch.

---

## 18. Final Instruction for AI Agents

Do not optimize for producing a large amount of code.

Optimize for:

- correctness;
- maintainability;
- traceability;
- testability;
- alignment with the existing project.

The goal is not to impress anyone with architectural confetti.

The goal is to keep the **Student Registration System** understandable, buildable, and useful.

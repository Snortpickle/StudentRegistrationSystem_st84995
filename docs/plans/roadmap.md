# 🗺️ Software Product Roadmap — Student Registration System

This roadmap tracks the development progress of the **Student Registration System** WPF MVVM application.

---

## ✅ Phase 1: Core Architecture & Infrastructure — Completed

**Goal:** Establish the technical foundation for the application.

- [x] Repository infrastructure established.
- [x] `DataService` created for local XML persistence.
- [x] `StatisticsService` created for academic calculations.
- [x] XML-backed local persistence model implemented.
- [x] Unique GUID identifier references added for entity relationships.
- [x] Authorization layer added with demo login validation.
- [x] Basic domain entities created:
  - `Student`
  - `Course`
  - `Enrollment`

---

## ✅ Phase 2: CRUD Features & MVVM Layout — Completed

**Goal:** Implement the core MVP user workflows.

- [x] Tab-based navigation window added.
- [x] Student, Course, and Enrollment `DataGrid` views implemented.
- [x] Modal dialog windows added for creating and editing records.
- [x] Entry validation rules added for update and creation workflows.
- [x] Relational deletion handling implemented.
- [x] Orphaned course registrations are cleaned automatically.
- [x] Real-time calculation panel integrated.
- [x] Aggregate statistics added:
  - total scores
  - entity counts
  - selected parameter calculations

---

## ✅ Phase 3: Reset Filters Module & AI Engineering Harness — Completed

**Goal:** Improve filtering usability and document the feature through structured AI-assisted engineering methods.

### Reset Filters Command Pattern Module

The reset filters feature has been implemented using the **Command Pattern**.

Completed work:

- [x] Created a dedicated `FilterReset` module.
- [x] Added command objects for student and course filter reset actions.
- [x] Added pure filter state models.
- [x] Added `FilterResetService` for deterministic reset calculations.
- [x] Updated `MainViewModel` to trigger reset behavior through command objects.
- [x] Added module-level documentation in `README.md`.
- [x] Updated architecture documentation with a Mermaid sequence diagram.
- [x] Added tests for reset behavior.

### Scope Adjustment

The reset filters feature was refactored from direct ViewModel logic into a dedicated module.

This improves:

- maintainability;
- testability;
- architectural traceability;
- separation between UI behavior and pure reset calculation.

The pure reset calculation remains free from:

- UI access;
- database access;
- direct `ObservableCollection` mutation;
- global state changes.

---

## 🧪 Phase 4: Robustness, Testing & Optimization — Current Phase

**Goal:** Improve reliability, verification, and maintainability.

- [ ] Integrate automated CI lint checks using the engineered `AGENTS.md` context parameters.
- [ ] Migrate inline local queries to optimized LINQ structures inside `StatisticsService`.
- [x] Implement extensive manual test scenarios covering numeric parsing edge cases:
  - dot vs comma in GPA;
  - invalid numeric input;
  - empty numeric fields.

---

## 🎨 Phase 5: Spec-Driven UI Improvements — Completed

**Goal:** Use a strict design contract to guide AI-assisted UI updates.

Completed work:

- [x] Created `docs/DESIGN.md`.
- [x] Defined UI framework choice: WPF XAML.
- [x] Defined color palette, typography, spacing, and component rules.
- [x] Added accessibility guidance for labels, tooltips, and command controls.
- [x] Updated reset filter UI controls in `MainWindow.xaml`.
- [x] Connected reset buttons to existing ViewModel commands.
- [x] Verified that UI changes do not add business logic to code-behind.
- [x] Built the project successfully in Visual Studio.

---

## ⏳ Phase 6: Deferred Releases — Post-MVP Backlog

**Goal:** Track larger improvements that are outside the current MVP scope.

- [ ] **Database Migration:** Replace local XML persistence with a secure SQL Server database instance.
- [ ] **Advanced Role-Based Access Control:** Replace demo credentials with dynamic account management and password hashing.
- [ ] **Automated CI Pipeline:** Add GitHub Actions for build and test verification.
- [ ] **Expanded Test Coverage:** Add more tests for enrollment rules, persistence behavior, and statistics calculations.
- [ ] **Improved Error Handling:** Add user-friendly validation and error messages across all forms.

---

## 📌 Current Project Status

| Area | Status |
|---|---|
| Core architecture | ✅ Complete |
| CRUD workflows | ✅ Complete |
| XML persistence | ✅ Complete |
| MVVM layout | ✅ Complete |
| Reset filters module | ✅ Complete |
| Command Pattern integration | ✅ Complete |
| Spec-driven UI update | ✅ Complete |
| Manual testing | ✅ In progress |
| CI automation | ⏳ Planned |
| SQL migration | ⏳ Deferred |

---

## 🧠 Roadmap Summary

The current MVP is functional and includes:

- student management;
- course management;
- enrollment management;
- XML persistence;
- filtering and reset filters;
- statistics calculations;
- modular reset logic;
- AI-assisted engineering documentation.

Future work should focus on automation, stronger persistence options, expanded testing, and production-grade authentication.

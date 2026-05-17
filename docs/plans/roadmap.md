# Software Product Roadmap - Student Registration System

## Phase 1: Core Architecture & Infrastructure (MVP) - COMPLETED
* [x] Establishment of repository infrastructure (DataService, StatisticsService).
* [x] XML-backed memory local persistence database model with unique GUID identifier references.
* [x] Authorization layer containing standard encrypted/demo check validations (admin/admin).
* [x] Basic structural Entities (Student, Course, Enrollment schemas).

## Phase 2: CRUD Features & MVVM Layout (MVP) - COMPLETED
* [x] Tab-based navigation control window (Students, Courses, Enrollments DataGrids).
* [x] Modal dialog windows binding handling for entry updates and addition validation rules.
* [x] Relational constraints deletion handling (automatic cleaning of orphaned course registrations).
* [x] Real-time calculations display panel integration (aggregate total scores, counts by selected parameters).

## Phase 3: Robustness, Testing & Optimization - CURRENT PHASE
* [ ] Integration of automated CI lint checks using the engineered `AGENTS.md` context parameters.
* [ ] Full migration from inline local queries to optimized LINQ structures inside StatisticsService.
* [x] Implementation of extensive manual test scenarios covering numeric parsing edge-cases (e.g., dot vs. comma in GPA).

## Phase 4: Deferred Releases (Post-MVP Backlog)
* [ ] **Database Migration:** Swapping the local structural DataService layer for a secure SQL Server database instance.
* [ ] **Advanced Role-Based Access Control:** Moving past demo credentials to dynamic database password hashing and account management tiers.

* [ ] ## Reset Filters Command Pattern Module

Status: Complete

The reset filters feature has been implemented using the Command Pattern.

Completed work:

- Created a dedicated `FilterReset` module.
- Added command objects for student and course filter reset actions.
- Added pure filter state models.
- Added `FilterResetService` for deterministic reset calculations.
- Updated `MainViewModel` to trigger reset behavior through command objects.
- Added module-level documentation in `README.md`.
- Updated architecture documentation with a Mermaid sequence diagram.
- Added tests for reset behavior.

Scope adjustment:

The reset filters feature was refactored from direct ViewModel logic into a dedicated module. This improves maintainability, testability, and traceability while keeping the pure reset calculation free from UI, database, and collection side effects.

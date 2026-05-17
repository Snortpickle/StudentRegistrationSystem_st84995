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
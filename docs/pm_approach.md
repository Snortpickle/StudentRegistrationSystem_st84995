# Project Management & Hybrid Team Approach

## 1. Workflow Methodology
This project uses a **Hybrid Scrum-Kanban (Scrumban)** framework designed for highly efficient solo-developer environments augmented by AI-native software agents. 
* **Human Role (Architect & Reviewer):** Handles core architectural boundaries, design system principles, final code reviews, and harness steering.
* **AI Agent Role (Feature Engineer & Tester):** Generates boilerplate structures, handles implementation details inside ViewModels, creates automated xUnit test boundaries, and handles XML serialization scripts.

## 2. Division of Responsibilities

| Technical Area | Responsible Party | Verification Mechanism |
| :--- | :--- | :--- |
| **Architecture & Database Contract** | Human | Pre-defined Interface validation |
| **UI Implementation (WPF/XAML)** | Hybrid (AI Layout + Human Polish) | Manual verification via View Inspection |
| **Data Manipulation & Services** | AI Agent | Automated compilation verification + integrity loops |
| **Unit Testing (xUnit Boundaries)**| AI Agent | Continuous integration pipeline via `dotnet test` |
| **Code Review & Quality Gate** | Human | Manual code differential sign-off before merge |

## 3. Data Integrity & Safety Guardrails
1. **Serialization Policy:** Data persistence is manually committed by the user through the `Save XML` control or verified during application launch using integrity hooks.
2. **Defensive Programming:** AI agents must always preserve existing validation boundaries (GPA constraints: 0.0–10.0, Study Year constraints: 1-4, Credits > 0).
# 🧭 Project Management & Hybrid Team Approach

This document describes the project management approach used for the **Student Registration System**.

The project follows a hybrid workflow where the human developer acts as the architect, reviewer, and final decision-maker, while AI agents assist with implementation, documentation, testing support, and structured code generation.

---

## 1. Workflow Methodology

The project uses a **Hybrid Scrum-Kanban** approach.

This means the work is organized around small feature tasks, but progress is managed continuously through GitHub commits, pull requests, documentation updates, and manual verification.

### Why Hybrid Scrum-Kanban?

This method fits the project because:

- the project is developed by a small team;
- features are implemented incrementally;
- AI-generated code must be reviewed before merge;
- documentation evolves together with the code;
- tasks can move quickly from idea to implementation to verification.

---

## 2. Team Model

The project uses a **Human + AI Agent** development model.

| Role | Responsibility |
|---|---|
| Human Developer | Defines goals, reviews code, validates architecture, tests locally, approves merges |
| AI Agent | Generates code, documentation drafts, tests, diagrams, and implementation suggestions |
| GitHub | Stores source control, pull requests, commit history, and review trace |
| Visual Studio | Provides local build, debugging, and verification environment |

The AI agent is treated as an assistant, not as an autonomous project owner.

Final responsibility remains with the human developer. Tragic, perhaps, but necessary.

---

## 3. Division of Responsibilities

| Technical Area | Responsible Party | Verification Mechanism |
|---|---|---|
| Architecture boundaries | Human | Review against MVVM and project structure |
| Requirements writing | Human + AI | BDD review and GitHub documentation |
| UI implementation | Hybrid | Visual inspection and WPF build verification |
| ViewModel command wiring | Hybrid | Manual UI testing and build verification |
| Services and modules | AI Agent + Human Review | Code review and unit tests |
| XML persistence | Human Review | Data integrity checks |
| Unit tests | AI Agent + Human Review | xUnit and build verification |
| Documentation | Hybrid | Markdown preview and link checks |
| Pull request approval | Human | Manual merge decision |

---

## 4. Development Workflow

The typical development cycle is:

```text
Task definition
        ↓
Requirement or design document
        ↓
AI-assisted implementation
        ↓
Pull request creation
        ↓
Human review
        ↓
Local build verification
        ↓
Merge to main
        ↓
Fetch / Pull locally
        ↓
Final documentation and submission links

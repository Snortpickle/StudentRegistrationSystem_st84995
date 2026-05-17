# EXP-2026-05-17 Pure Function Experiment

## Goal

Evaluate whether AI can generate a pure-function implementation using structured BDD requirements and Mermaid diagrams.

---

# Selected Feature

Reset Student and Course Filters

---

# Prompt Used

```text
Using the following BDD requirements and Mermaid sequence diagram, write the logic for the reset filters feature as a Pure Function in C#.

STRICT RULES:
- No side effects
- No UI access
- No database access
- No ObservableCollection modifications
- No mutable global state
- The function must return predictable output
```

BDD requirements and Mermaid sequence diagrams were included below the prompt.

---

# AI Result

The AI generated:

- A new pure-function service named `FilterResetService`
- Immutable state records:
  - `StudentFilterState`
  - `CourseFilterState`
- Deterministic reset logic
- xUnit tests for behavior validation

The generated logic avoided:

- UI dependencies
- Database access
- ObservableCollection mutations
- Side effects

---

# Example Generated Logic

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

---

# Testing Performed

The following tests were created:

- Student filter reset clears all fields
- Course filter reset clears department filter
- Multiple calls with identical input return identical output

---

# First Attempt Success

Partial success.

The initial implementation mixed ViewModel update logic with filter reset logic.

Additional clarification was required to enforce:

- stateless behavior
- immutable return values
- separation from MVVM command handling

---

# Final Evaluation

The experiment demonstrated that structured BDD requirements and Mermaid diagrams significantly improved AI-generated code quality.

The AI successfully produced deterministic pure functions after strict architectural constraints were added.

The resulting design improved separation of concerns in the WPF MVVM architecture.
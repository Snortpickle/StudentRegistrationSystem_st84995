# Flow: Reset Student and Course Filters

```mermaid
sequenceDiagram
    actor User
    participant View as MainWindow.xaml
    participant VM as MainViewModel
    participant StudentCommand as ResetStudentFiltersCommand
    participant CourseCommand as ResetCourseFiltersCommand
    participant Service as FilterResetService
    participant State as StudentFilterState / CourseFilterState

    User->>View: Clicks "Show all students" or "Show all courses"
    View->>VM: Executes bound ICommand

    alt Reset student filters
        VM->>StudentCommand: Execute()
        StudentCommand->>VM: Invoke student reset action
        VM->>Service: ResetStudentFilters(currentState)
        Service->>State: Create cleared student filter state
        State-->>Service: Return immutable state
        Service-->>VM: Return cleared student filters
        VM->>VM: Apply returned values
        VM->>VM: Refresh student list
    else Reset course filters
        VM->>CourseCommand: Execute()
        CourseCommand->>VM: Invoke course reset action
        VM->>Service: ResetCourseFilters(currentState)
        Service->>State: Create cleared course filter state
        State-->>Service: Return immutable state
        Service-->>VM: Return cleared course filters
        VM->>VM: Apply returned values
        VM->>VM: Refresh course list
    end

    VM-->>View: Display full list
```

## Pattern Used

This flow applies the Command Pattern.

The reset actions are represented as command objects that implement `ICommand`. The ViewModel exposes these commands to the View, while the pure reset logic remains inside `FilterResetService`.

## Dependencies

- `MainWindow.xaml` binds buttons to ViewModel commands.
- `MainViewModel` owns state and applies returned reset values.
- `ResetStudentFiltersCommand` and `ResetCourseFiltersCommand` encapsulate user-triggered actions.
- `FilterResetService` performs deterministic reset calculations.
- `StudentFilterState` and `CourseFilterState` represent input and output state.

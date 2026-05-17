# FilterReset Module

## Why Command Pattern here

The filter-reset actions are user-triggered UI operations (`Show all students`, `Show all courses`) that are ideal command use-cases in MVVM:

- The **View** binds buttons to command objects.
- The **Command** encapsulates the action request.
- The **ViewModel** decides how to apply returned state and refresh views.

This keeps XAML code-behind free from business logic and preserves MVVM separation.

## Design

- `Services/FilterResetService.cs` contains **pure reset calculations**.
  - No database access.
  - No direct UI access.
  - No `ObservableCollection` mutations.
- `Commands/*.cs` contain command objects used by `MainViewModel`.
- `Models/FilterResetState.cs` defines immutable state contracts returned by the service.

## Flow

1. User clicks reset button in `MainWindow.xaml`.
2. Bound command object executes (`ResetStudentFiltersCommand` / `ResetCourseFiltersCommand`).
3. `MainViewModel` calls `FilterResetService` to compute reset state.
4. `MainViewModel` applies state to filter properties and refreshes collection views.

This preserves testability and keeps side effects in the ViewModel layer only.

# 🧩 FilterReset Module

This module handles the **reset filter** feature for the Student Registration System.

It is used when the user clicks:

- `Show all students`
- `Show all courses`

The module keeps reset logic separate from the UI and follows the **Command Pattern**.

---

## 🎯 Why Command Pattern?

The reset actions are user-triggered operations, which makes them a natural fit for commands in WPF MVVM.

The pattern helps keep responsibilities clear:

| Part | Responsibility |
|---|---|
| `MainWindow.xaml` | Displays reset buttons |
| `MainViewModel` | Applies returned state and refreshes lists |
| `Commands/` | Encapsulates reset actions |
| `Services/FilterResetService.cs` | Calculates reset state |
| `Models/FilterResetState.cs` | Defines immutable filter state |

---

## 🧱 Design

`FilterResetService` contains the pure reset calculations.

It does **not**:

- access the database;
- access UI controls;
- mutate `ObservableCollection`;
- change global state.

The ViewModel is responsible for applying the returned state and refreshing the visible lists.

---

## 🔁 Flow

```text
User clicks reset button
        ↓
MainWindow.xaml command binding
        ↓
ResetStudentFiltersCommand / ResetCourseFiltersCommand
        ↓
MainViewModel calls FilterResetService
        ↓
FilterResetService returns cleared state
        ↓
MainViewModel applies state and refreshes list

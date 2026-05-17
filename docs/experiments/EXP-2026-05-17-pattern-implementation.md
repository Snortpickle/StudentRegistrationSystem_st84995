## Goal

Evaluate whether an AI assistant can implement the selected reset filters feature using a suitable design pattern without creating unnecessary complexity.

## Selected Feature

Reset Student and Course Filters

## Selected Pattern

Command Pattern

## Why This Pattern Was Chosen

The reset filters feature is triggered by user actions in a WPF MVVM interface.

The Command Pattern is suitable because WPF buttons can bind to commands exposed by the ViewModel. This allows the View to trigger behavior without containing business logic directly.

The selected pattern also fits the existing architecture because the project already follows the MVVM approach, where UI actions should be exposed through commands instead of being handled directly in the view.

## Prompt Used

```text
Implement the reset filters feature in my WPF MVVM StudentRegistrationSystem project using the Command Pattern.

Requirements:
- Create a dedicated module folder: src/StudentRegistrationSystem/Modules/FilterReset/
- Use the Command Pattern to connect reset filter actions to the existing MainViewModel.
- Keep FilterResetService pure and side-effect free.
- Commands may trigger state updates in the ViewModel, but the reset calculation must remain in the pure service.
- Do not access the database.
- Do not access UI controls directly.
- Do not modify ObservableCollection inside the pure service.
- Add clear comments where the Command Pattern is applied.
- Add or update tests if needed.
- Add README.md inside the module folder explaining the selected pattern and why it fits.
- Follow the existing AGENTS.md instructions.
```

## AI Result

The AI created a dedicated `FilterReset` module for the reset filters feature.

The module includes:

- command objects for resetting student and course filters
- pure state models for filter values
- `FilterResetService` for deterministic reset calculations
- tests for reset behavior
- `README.md` documentation explaining the pattern choice

The implementation also updated `MainViewModel` so that reset actions are triggered through command objects instead of direct UI logic.

## Pattern Accuracy

The Command Pattern was applied correctly.

The reset actions are encapsulated as command objects that implement `ICommand`. These commands represent user-triggered actions from the WPF interface.

The ViewModel exposes the commands to the View, while the reset calculation remains inside `FilterResetService`.

The pure service does not directly access:

- UI controls
- the database
- `ObservableCollection`
- external mutable state

This keeps the business logic predictable and easier to test.

## Did the Pattern Clarify the Code?

Yes.

The pattern clarified the code by separating:

- button-triggered UI behavior
- command execution
- pure reset calculation
- ViewModel state updates
- list refresh behavior

This made the reset filters feature easier to understand and easier to document.

## Did It Cause Overengineering?

Only minor additional structure was introduced.

For a small reset feature, separate command classes may be more structure than strictly necessary. However, for this assignment, the pattern is justified because it makes the module easier to test, document, and trace architecturally.

The solution avoided unnecessary complexity because the pure reset logic remained simple and the command objects only encapsulate user-triggered actions.

## Testing

The AI attempted to run build and test commands:

```text
dotnet build StudentRegistrationSystem.sln --configuration Release
dotnet test
```

The AI environment reported:

```text
dotnet: command not found
```

This was an environment limitation because the .NET CLI was not available in that environment.

The project should be verified locally in Visual Studio using:

```text
Build → Build Solution
```

or:

```text
Ctrl + Shift + B
```

## Final Evaluation

The Command Pattern was a suitable choice for the reset filters feature because it aligns naturally with WPF MVVM.

The final implementation provides a maintainable structure where command objects trigger behavior, the ViewModel applies state, and `FilterResetService` keeps reset calculations pure and predictable.

The pattern helped create a clearer architecture without introducing excessive complexity.

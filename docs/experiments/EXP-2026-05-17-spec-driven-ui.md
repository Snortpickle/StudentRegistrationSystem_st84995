# EXP-2026-05-17 Spec Driven UI

## Goal

Evaluate whether an AI assistant can generate frontend UI code from a strict design contract and connect it to an existing backend module.

## Selected Feature

Reset Student and Course Filters

## Design Contract

The UI generation was guided by:

```text
docs/DESIGN.md
```

The design contract defined:

- framework choice
- color palette
- typography rules
- spacing rules
- component rules
- accessibility rules
- MVVM integration rules
- backend module connection rules

## Framework Used

WPF XAML

## Why WPF Was Used

The existing Student Registration System is a WPF MVVM desktop application.

Using WPF XAML allowed the generated UI to connect directly to the existing `MainViewModel` commands and the `FilterReset` module created in Task 4.

A separate Streamlit, React, or HTML interface was not used because it would duplicate the frontend instead of integrating with the existing application.

## Prompt Used

```text
Use docs/DESIGN.md as the strict design contract.

Implement the frontend UI for the Reset Student and Course Filters feature in the existing WPF MVVM StudentRegistrationSystem project.

Requirements:
- Use WPF XAML, not React, Streamlit, or web UI.
- Follow all constraints in docs/DESIGN.md.
- Update MainWindow.xaml so the student filter area has a clear "Show all students" reset button.
- Update MainWindow.xaml so the course filter area has a clear "Show all courses" reset button.
- Bind the buttons to the existing ViewModel commands created for the FilterReset module.
- Use the actual command property names from MainViewModel.
- Do not add business logic to MainWindow.xaml.cs.
- Do not access the database from the UI.
- Do not modify ObservableCollection directly from the UI.
- Keep the UI accessible with readable labels and clear spacing.
- Ensure the reset buttons trigger the Command Pattern module created in Task 4.
- Add comments only where they clarify the binding between UI and commands.
- Run build if available.
```

## AI Result

The AI updated the WPF UI for the reset filters feature.

The generated UI changes included:

- explicit labels for student filter fields
- explicit labels for course filter fields
- a `Show all students` reset button
- a `Show all courses` reset button
- spacing and alignment improvements
- accessibility metadata such as `AutomationProperties.Name`
- tooltips for reset controls

The UI remained inside `MainWindow.xaml`.

## Connection to Backend Module

The generated UI connects to the backend module through MVVM command bindings.

Expected flow:

```text
MainWindow.xaml
→ MainViewModel command
→ ResetStudentFiltersCommand / ResetCourseFiltersCommand
→ FilterResetService
→ returned filter state
→ refreshed list
```

The reset buttons remained bound to the existing ViewModel commands:

```xml
Command="{Binding ClearStudentFiltersCommand}"
Command="{Binding ClearCourseFiltersCommand}"
```

## Did the AI Follow DESIGN.md?

Mostly yes.

The generated UI followed the design contract by:

- using WPF XAML
- keeping the existing MVVM structure
- using clear reset button labels
- avoiding database access from the UI
- keeping reset logic outside `MainWindow.xaml.cs`
- connecting UI actions to ViewModel commands
- improving spacing, labels, and accessibility metadata

## Did the AI Hallucinate Generic Styles?

No major hallucination was observed.

The AI did not replace the WPF application with a generic web dashboard and did not introduce unrelated UI components.

It stayed focused on the reset filters feature and updated the existing desktop UI.

## How Many Prompts Were Needed?

One main prompt was used to generate the UI changes.

One manual fix was required afterward because an invalid XAML comment caused a build error. After removing or correcting the invalid comment, the project built successfully.

## Accessibility and Structure Evaluation

The generated UI is structurally sound because the reset buttons are placed near the related filter sections.

The labels are text-based rather than icon-only, which improves clarity and accessibility.

The use of `AutomationProperties.Name` and `ToolTip` values improves usability for assistive technologies and general users.

## Build Verification

The project was built locally in Visual Studio.

Result:

```text
Build succeeded.
0 errors.
```

This confirmed that the updated XAML and project structure compile successfully.

## Final Evaluation

Spec Driven Development helped constrain the AI output and kept the generated UI aligned with the existing WPF MVVM architecture.

The design contract prevented the AI from creating a generic interface and helped ensure that the UI connected to the backend module created in Task 4.

The final result is a working WPF UI update that supports the reset filters feature while preserving MVVM separation.

# 🎨 DESIGN.md — Student Registration System UI Contract

This document defines the visual and structural design contract for the **Student Registration System** UI.

Its purpose is to guide AI-assisted frontend generation so that UI changes stay consistent, accessible, and connected to the existing **WPF MVVM** backend logic.

---

## 1. Purpose

The design contract ensures that generated UI code:

- follows the existing WPF desktop application structure;
- keeps business logic out of code-behind files;
- uses consistent colors, spacing, and typography;
- connects buttons and controls to ViewModel commands;
- supports accessibility through readable labels and control names.

---

## 2. Framework Choice

| Area | Decision |
|---|---|
| UI Framework | **WPF XAML** |
| Architecture | **MVVM** |
| Styling Location | XAML styles and resources |
| Backend Connection | ViewModel command bindings |

### Reason

The existing application is a **WPF MVVM desktop application**.

The UI must be implemented in XAML and connected to ViewModel commands instead of creating a separate web interface.

Creating a React, Streamlit, or HTML frontend would duplicate the UI and weaken integration with the existing application.

---

## 3. Feature Scope

### Selected Feature

```text
Reset Student and Course Filters
```

The UI must provide clear controls that allow the user to:

- reset active student filters;
- reset active course filters;
- return to the full student or course list;
- trigger the existing backend module created in Task 4.

Required reset controls:

```text
Show all students
Show all courses
```

---

## 4. Color Palette

Use a calm academic desktop palette.

<table>
  <tr>
    <th>Role</th>
    <th>Color</th>
    <th>Preview</th>
    <th>Usage</th>
  </tr>
  <tr>
    <td><strong>Primary</strong></td>
    <td><code>#2563EB</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#2563EB;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Main actions, active states, important highlights</td>
  </tr>
  <tr>
    <td><strong>Secondary</strong></td>
    <td><code>#64748B</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#64748B;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Secondary actions, muted interface elements</td>
  </tr>
  <tr>
    <td><strong>Background</strong></td>
    <td><code>#F8FAFC</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#F8FAFC;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Main window background</td>
  </tr>
  <tr>
    <td><strong>Surface / Card</strong></td>
    <td><code>#FFFFFF</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#FFFFFF;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Panels, cards, grouped content areas</td>
  </tr>
  <tr>
    <td><strong>Text</strong></td>
    <td><code>#0F172A</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#0F172A;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Main readable text</td>
  </tr>
  <tr>
    <td><strong>Muted Text</strong></td>
    <td><code>#64748B</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#64748B;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Hints, secondary labels, helper text</td>
  </tr>
  <tr>
    <td><strong>Border</strong></td>
    <td><code>#CBD5E1</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#CBD5E1;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Input borders, panel borders, separators</td>
  </tr>
  <tr>
    <td><strong>Success</strong></td>
    <td><code>#16A34A</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#16A34A;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Successful actions or positive status</td>
  </tr>
  <tr>
    <td><strong>Error</strong></td>
    <td><code>#DC2626</code></td>
    <td><span style="display:inline-block;width:28px;height:16px;background:#DC2626;border-radius:4px;border:1px solid #CBD5E1;"></span></td>
    <td>Validation errors or destructive actions</td>
  </tr>
</table>

---

## 5. Typography

Use the default WPF system font.

### Rules

- Window titles should use larger bold text.
- Section headings should be bold and clearly separated.
- Form labels should be readable and aligned consistently.
- Button text should be short and action-oriented.
- Avoid decorative fonts.

### Suggested Scale

| Element | Style |
|---|---|
| Window title | Bold, large |
| Section heading | Bold, medium |
| Form label | Regular or semi-bold |
| Table content | Regular |
| Helper text | Smaller, muted |

---

## 6. Spacing Rules

Use consistent spacing throughout the interface.

| Area | Rule |
|---|---|
| Window edges | Minimum `12px` margin |
| Form fields | Minimum `8px` spacing |
| Buttons | Minimum `8px` internal padding |
| Sections | Visually grouped with clear separation |
| Filter controls | Reset button placed near the related filters |

Do not place controls directly against window edges.

Do not crowd labels, inputs, and buttons together like they are fighting for rent.

---

## 7. Component Rules

### Buttons

Buttons must:

- have clear action labels;
- bind to ViewModel commands;
- avoid business logic in code-behind;
- use consistent spacing;
- be placed near the feature they affect.

### Reset Buttons

Reset buttons must use these labels:

```text
Show all students
Show all courses
```

They must bind to the existing ViewModel commands:

```xml
Command="{Binding ClearStudentFiltersCommand}"
Command="{Binding ClearCourseFiltersCommand}"
```

### Filter Sections

Filter sections must:

- keep student filters and course filters separate;
- include labels for important fields;
- place reset controls near the relevant filters;
- clearly indicate what the reset button affects.

---

## 8. Accessibility Rules

The UI must:

- use readable text contrast;
- use descriptive button labels;
- avoid icon-only controls for important actions;
- support keyboard navigation where possible;
- include tooltips where they improve clarity;
- use `AutomationProperties.Name` for important interactive controls.

Example:

```xml
<Button
    Content="Show all students"
    AutomationProperties.Name="Show all students"
    ToolTip="Reset student filters and display every student"
    Command="{Binding ClearStudentFiltersCommand}" />
```

---

## 9. MVVM Integration Rules

The UI must not call backend logic directly.

The UI must bind to ViewModel properties and commands.

Expected flow:

```text
MainWindow.xaml
→ MainViewModel command
→ ResetStudentFiltersCommand / ResetCourseFiltersCommand
→ FilterResetService
→ returned filter state
→ MainViewModel applies state
→ refreshed list
```

---

## 10. Backend Module Connection

The reset buttons must trigger the Command Pattern module created in Task 4.

The UI must not:

- access the database;
- mutate `ObservableCollection` directly;
- call `FilterResetService` from XAML code-behind;
- place reset business logic in `MainWindow.xaml.cs`.

The ViewModel is responsible for applying returned state and refreshing the visible lists.

---

## 11. Anti-Patterns

Do not:

- replace WPF with React, Streamlit, or HTML;
- create generic dashboard cards unrelated to the feature;
- use random colors outside this file;
- add database access to UI code;
- add business logic to XAML code-behind;
- stack unrelated primary buttons together;
- use icon-only buttons for important actions.

---

## 12. Success Criteria

The UI update is successful when:

- `MainWindow.xaml` follows this design contract;
- reset buttons are visible near the correct filter sections;
- buttons bind to the correct ViewModel commands;
- no business logic is added to code-behind;
- the project builds successfully;
- the reset feature remains connected to the Task 4 backend module.

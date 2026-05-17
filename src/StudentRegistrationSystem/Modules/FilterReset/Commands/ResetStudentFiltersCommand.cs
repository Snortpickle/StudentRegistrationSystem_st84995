using System;
using System.Windows.Input;

namespace StudentRegistrationSystem.Modules.FilterReset.Commands;

/// <summary>
/// Command Pattern: encapsulates the student-filter reset request as a command object.
/// </summary>
public sealed class ResetStudentFiltersCommand : ICommand
{
    private readonly Action _execute;

    public ResetStudentFiltersCommand(Action execute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _execute();
}

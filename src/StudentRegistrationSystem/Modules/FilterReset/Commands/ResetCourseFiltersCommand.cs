using System;
using System.Windows.Input;

namespace StudentRegistrationSystem.Modules.FilterReset.Commands;

/// <summary>
/// Command Pattern: encapsulates the course-filter reset request as a command object.
/// </summary>
public sealed class ResetCourseFiltersCommand : ICommand
{
    private readonly Action _execute;

    public ResetCourseFiltersCommand(Action execute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _execute();
}

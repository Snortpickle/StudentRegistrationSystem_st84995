using StudentRegistrationSystem.Common;

namespace StudentRegistrationSystem.Models;

public sealed class Course : ObservableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    private string _title = "";
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private string _department = "";
    public string Department
    {
        get => _department;
        set => SetProperty(ref _department, value);
    }

    private int _credits = 3;
    public int Credits
    {
        get => _credits;
        set => SetProperty(ref _credits, value);
    }

    private int _maxStudents = 30;
    public int MaxStudents
    {
        get => _maxStudents;
        set => SetProperty(ref _maxStudents, value);
    }
}

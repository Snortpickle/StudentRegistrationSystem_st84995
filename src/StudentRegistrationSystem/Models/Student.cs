using StudentRegistrationSystem.Common;

namespace StudentRegistrationSystem.Models;

public sealed class Student : ObservableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    private string _firstName = "";
    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    private string _lastName = "";
    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    private string _group = "";
    public string Group
    {
        get => _group;
        set => SetProperty(ref _group, value);
    }

    private int _studyYear = 1;
    public int StudyYear
    {
        get => _studyYear;
        set => SetProperty(ref _studyYear, value);
    }

    private double _gpa;
    public double GPA
    {
        get => _gpa;
        set => SetProperty(ref _gpa, value);
    }

    private bool _hasScholarship;
    public bool HasScholarship
    {
        get => _hasScholarship;
        set => SetProperty(ref _hasScholarship, value);
    }

    public string FullName => $"{LastName} {FirstName}";
}

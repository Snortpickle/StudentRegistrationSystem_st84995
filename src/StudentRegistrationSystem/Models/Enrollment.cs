using StudentRegistrationSystem.Common;

namespace StudentRegistrationSystem.Models;

public enum EnrollmentStatus
{
    Active,
    Completed,
    Dropped
}

public sealed class Enrollment : ObservableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }

    private DateTime _registeredAt = DateTime.Now;
    public DateTime RegisteredAt
    {
        get => _registeredAt;
        set => SetProperty(ref _registeredAt, value);
    }

    private EnrollmentStatus _status = EnrollmentStatus.Active;
    public EnrollmentStatus Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    private double? _grade;
    public double? Grade
    {
        get => _grade;
        set => SetProperty(ref _grade, value);
    }
}

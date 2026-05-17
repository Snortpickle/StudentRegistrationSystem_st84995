namespace StudentRegistrationSystem.Models;

/// <summary>
/// One-file "database" stored in XML.
/// </summary>
public sealed class Database
{
    public List<Student> Students { get; set; } = new();
    public List<Course> Courses { get; set; } = new();
    public List<Enrollment> Enrollments { get; set; } = new();
}

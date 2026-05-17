using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Services;

public sealed class DataService
{
    private readonly string _filePath;

    public DataService(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<Database> LoadAsync()
    {
        if (!File.Exists(_filePath))
        {
            var db = CreateDemoData();
            await SaveAsync(db);
            return db;
        }

        await using var fs = File.OpenRead(_filePath);
        var serializer = new XmlSerializer(typeof(Database));
        return (Database)(serializer.Deserialize(fs) ?? new Database());
    }

    public async Task SaveAsync(Database db)
    {
        // Save asynchronously to avoid UI freezing.
        await Task.Run(() =>
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);

            using var fs = File.Create(_filePath);
            var serializer = new XmlSerializer(typeof(Database));
            serializer.Serialize(fs, db);
        });
    }

    private static Database CreateDemoData()
    {
        var s1 = new Student { FirstName = "Anna", LastName = "Ivanova", Group = "IT-31", StudyYear = 3, GPA = 8.6, HasScholarship = true };
        var s2 = new Student { FirstName = "Maksim", LastName = "Petrov", Group = "IT-31", StudyYear = 3, GPA = 7.2, HasScholarship = false };
        var s3 = new Student { FirstName = "Elina", LastName = "Bērziņa", Group = "IT-21", StudyYear = 2, GPA = 9.1, HasScholarship = true };

        var c1 = new Course { Title = "Object-Oriented Programming", Department = "CS", Credits = 4, MaxStudents = 25 };
        var c2 = new Course { Title = "Databases", Department = "CS", Credits = 3, MaxStudents = 30 };
        var c3 = new Course { Title = "Software Engineering", Department = "SE", Credits = 3, MaxStudents = 40 };

        var e1 = new Enrollment { StudentId = s1.Id, CourseId = c1.Id, RegisteredAt = DateTime.Today.AddDays(-7), Status = EnrollmentStatus.Active };
        var e2 = new Enrollment { StudentId = s1.Id, CourseId = c2.Id, RegisteredAt = DateTime.Today.AddDays(-14), Status = EnrollmentStatus.Completed, Grade = 9.0 };
        var e3 = new Enrollment { StudentId = s3.Id, CourseId = c1.Id, RegisteredAt = DateTime.Today.AddDays(-2), Status = EnrollmentStatus.Active };

        return new Database
        {
            Students = new() { s1, s2, s3 },
            Courses = new() { c1, c2, c3 },
            Enrollments = new() { e1, e2, e3 }
        };
    }
}

using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Services;

public static class StatisticsService
{
    public static int CountStudentsInGroup(Database db, string group)
        => db.Students.Count(s => string.Equals(s.Group, group, StringComparison.OrdinalIgnoreCase));

    public static double? AverageGradeForCourse(Database db, Guid courseId)
    {
        var grades = db.Enrollments
            .Where(e => e.CourseId == courseId && e.Grade.HasValue)
            .Select(e => e.Grade!.Value)
            .ToList();

        return grades.Count == 0 ? null : grades.Average();
    }

    public static int TotalCreditsForStudent(Database db, Guid studentId)
    {
        var courseIds = db.Enrollments
            .Where(e => e.StudentId == studentId && e.Status != EnrollmentStatus.Dropped)
            .Select(e => e.CourseId)
            .Distinct()
            .ToList();

        return db.Courses.Where(c => courseIds.Contains(c.Id)).Sum(c => c.Credits);
    }
}

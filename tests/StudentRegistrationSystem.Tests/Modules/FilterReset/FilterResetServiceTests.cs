using StudentRegistrationSystem.Modules.FilterReset.Services;
using Xunit;

namespace StudentRegistrationSystem.Tests.Modules.FilterReset;

public class FilterResetServiceTests
{
    [Fact]
    public void ResetStudents_ReturnsExpectedDefaults()
    {
        var service = new FilterResetService();

        var result = service.ResetStudents();

        Assert.Equal(string.Empty, result.StudentNameFilter);
        Assert.Equal(string.Empty, result.GroupFilter);
        Assert.Null(result.StudyYearFilter);
        Assert.False(result.OnlyScholarship);
    }

    [Fact]
    public void ResetCourses_ReturnsExpectedDefaults()
    {
        var service = new FilterResetService();

        var result = service.ResetCourses();

        Assert.Equal(string.Empty, result.CourseDepartmentFilter);
    }
}

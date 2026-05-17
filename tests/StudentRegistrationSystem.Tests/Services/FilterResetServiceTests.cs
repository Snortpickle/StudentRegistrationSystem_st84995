using StudentRegistrationSystem.Services;
using Xunit;

namespace StudentRegistrationSystem.Tests.Services;

public class FilterResetServiceTests
{
    [Fact]
    public void ResetStudentFilters_ClearsAllFields()
    {
        var current = new StudentFilterState("Jane", "CS-1", 3, true);

        var result = FilterResetService.ResetStudentFilters(current);

        Assert.Equal(string.Empty, result.StudentNameFilter);
        Assert.Equal(string.Empty, result.GroupFilter);
        Assert.Null(result.StudyYearFilter);
        Assert.False(result.OnlyScholarship);
    }

    [Fact]
    public void ResetCourseFilters_ClearsDepartmentFilter()
    {
        var current = new CourseFilterState("Math");

        var result = FilterResetService.ResetCourseFilters(current);

        Assert.Equal(string.Empty, result.CourseDepartmentFilter);
    }

    [Fact]
    public void ResetStudentFilters_IsDeterministicForSameInput()
    {
        var current = new StudentFilterState("Alex", "EE-2", 2, true);

        var result1 = FilterResetService.ResetStudentFilters(current);
        var result2 = FilterResetService.ResetStudentFilters(current);

        Assert.Equal(result1, result2);
    }
}

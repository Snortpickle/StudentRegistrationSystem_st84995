using StudentRegistrationSystem.Modules.FilterReset.Models;

namespace StudentRegistrationSystem.Modules.FilterReset.Services;

/// <summary>
/// Pure calculation service for reset filter actions.
/// It returns new state objects and performs no UI, DB, or collection mutations.
/// </summary>
public sealed class FilterResetService
{
    public StudentFilterState ResetStudents() => new(
        StudentNameFilter: string.Empty,
        GroupFilter: string.Empty,
        StudyYearFilter: null,
        OnlyScholarship: false);

    public CourseFilterState ResetCourses() => new(CourseDepartmentFilter: string.Empty);
}

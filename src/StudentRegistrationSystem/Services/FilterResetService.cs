namespace StudentRegistrationSystem.Services;

public static class FilterResetService
{
    public static StudentFilterState ResetStudentFilters(StudentFilterState current)
    {
        _ = current;
        return new StudentFilterState(
            StudentNameFilter: string.Empty,
            GroupFilter: string.Empty,
            StudyYearFilter: null,
            OnlyScholarship: false);
    }

    public static CourseFilterState ResetCourseFilters(CourseFilterState current)
    {
        _ = current;
        return new CourseFilterState(CourseDepartmentFilter: string.Empty);
    }
}

public readonly record struct StudentFilterState(
    string? StudentNameFilter,
    string? GroupFilter,
    int? StudyYearFilter,
    bool OnlyScholarship);

public readonly record struct CourseFilterState(string? CourseDepartmentFilter);

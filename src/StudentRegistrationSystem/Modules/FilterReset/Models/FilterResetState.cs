namespace StudentRegistrationSystem.Modules.FilterReset.Models;

public sealed record StudentFilterState(
    string? StudentNameFilter,
    string? GroupFilter,
    int? StudyYearFilter,
    bool OnlyScholarship);

public sealed record CourseFilterState(string? CourseDepartmentFilter);

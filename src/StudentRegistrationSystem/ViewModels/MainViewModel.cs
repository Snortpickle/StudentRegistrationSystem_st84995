using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using StudentRegistrationSystem.Common;
using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.Services;
using StudentRegistrationSystem.Views;

namespace StudentRegistrationSystem.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    private readonly DataService _dataService;
    private Database _db = new();

    public ObservableCollection<Student> Students { get; } = new();
    public ObservableCollection<Course> Courses { get; } = new();
    public ObservableCollection<Enrollment> Enrollments { get; } = new();

    // ICollectionView for filtering/searching
    public ICollectionView StudentsView { get; }
    public ICollectionView CoursesView { get; }
    public ICollectionView EnrollmentsView { get; }

    private Student? _selectedStudent;
    public Student? SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            if (SetProperty(ref _selectedStudent, value))
            {
                UpdateStats();
                (EditStudentCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteStudentCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }

    private Course? _selectedCourse;
    public Course? SelectedCourse
    {
        get => _selectedCourse;
        set
        {
            if (SetProperty(ref _selectedCourse, value))
            {
                UpdateStats();
                (EditCourseCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteCourseCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }

    private Enrollment? _selectedEnrollment;
    public Enrollment? SelectedEnrollment
    {
        get => _selectedEnrollment;
        set
        {
            if (SetProperty(ref _selectedEnrollment, value))
            {
                (EditEnrollmentCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteEnrollmentCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
    }

    // Filters (>=3)
    private string? _studentNameFilter;
    public string? StudentNameFilter
    {
        get => _studentNameFilter;
        set { if (SetProperty(ref _studentNameFilter, value)) StudentsView.Refresh(); }
    }

    private string? _groupFilter;
    public string? GroupFilter
    {
        get => _groupFilter;
        set { if (SetProperty(ref _groupFilter, value)) StudentsView.Refresh(); }
    }

    private int? _studyYearFilter;
    public int? StudyYearFilter
    {
        get => _studyYearFilter;
        set { if (SetProperty(ref _studyYearFilter, value)) StudentsView.Refresh(); }
    }

    private bool _onlyScholarship;
    public bool OnlyScholarship
    {
        get => _onlyScholarship;
        set { if (SetProperty(ref _onlyScholarship, value)) StudentsView.Refresh(); }
    }

    private string? _courseDepartmentFilter;
    public string? CourseDepartmentFilter
    {
        get => _courseDepartmentFilter;
        set { if (SetProperty(ref _courseDepartmentFilter, value)) CoursesView.Refresh(); }
    }

    // Calculations (>=2)
    private string _statsText = "";
    public string StatsText
    {
        get => _statsText;
        set => SetProperty(ref _statsText, value);
    }

    public ICommand AddStudentCommand { get; }
    public ICommand EditStudentCommand { get; }
    public ICommand DeleteStudentCommand { get; }

    public ICommand AddCourseCommand { get; }
    public ICommand EditCourseCommand { get; }
    public ICommand DeleteCourseCommand { get; }

    public ICommand AddEnrollmentCommand { get; }
    public ICommand EditEnrollmentCommand { get; }
    public ICommand DeleteEnrollmentCommand { get; }

    public ICommand SaveCommand { get; }
    public ICommand ReloadCommand { get; }

    public MainViewModel()
    {
        var dataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "StudentRegistrationSystem");

        _dataService = new DataService(Path.Combine(dataFolder, "database.xml"));

        StudentsView = CollectionViewSource.GetDefaultView(Students);
        StudentsView.Filter = StudentFilter;

        CoursesView = CollectionViewSource.GetDefaultView(Courses);
        CoursesView.Filter = CourseFilter;

        EnrollmentsView = CollectionViewSource.GetDefaultView(Enrollments);

        AddStudentCommand = new RelayCommand(AddStudent);
        EditStudentCommand = new RelayCommand(EditStudent, () => SelectedStudent != null);
        DeleteStudentCommand = new RelayCommand(DeleteStudent, () => SelectedStudent != null);

        AddCourseCommand = new RelayCommand(AddCourse);
        EditCourseCommand = new RelayCommand(EditCourse, () => SelectedCourse != null);
        DeleteCourseCommand = new RelayCommand(DeleteCourse, () => SelectedCourse != null);

        AddEnrollmentCommand = new RelayCommand(AddEnrollment);
        EditEnrollmentCommand = new RelayCommand(EditEnrollment, () => SelectedEnrollment != null);
        DeleteEnrollmentCommand = new RelayCommand(DeleteEnrollment, () => SelectedEnrollment != null);

        SaveCommand = new RelayCommand(async () => await SaveAsync());
        ReloadCommand = new RelayCommand(async () => await LoadAsync());

        _ = LoadAsync();
    }

    private bool StudentFilter(object obj)
    {
        if (obj is not Student s) return true;

        if (!string.IsNullOrWhiteSpace(StudentNameFilter))
        {
            var needle = StudentNameFilter.Trim().ToLowerInvariant();
            var hay = (s.FirstName + " " + s.LastName).ToLowerInvariant();
            if (!hay.Contains(needle)) return false;
        }

        if (!string.IsNullOrWhiteSpace(GroupFilter))
        {
            if (!string.Equals(s.Group, GroupFilter.Trim(), StringComparison.OrdinalIgnoreCase))
                return false;
        }

        if (StudyYearFilter.HasValue && s.StudyYear != StudyYearFilter.Value)
            return false;

        if (OnlyScholarship && !s.HasScholarship)
            return false;

        return true;
    }

    private bool CourseFilter(object obj)
    {
        if (obj is not Course c) return true;

        if (!string.IsNullOrWhiteSpace(CourseDepartmentFilter))
        {
            if (!string.Equals(c.Department, CourseDepartmentFilter.Trim(), StringComparison.OrdinalIgnoreCase))
                return false;
        }

        return true;
    }

    private async Task LoadAsync()
    {
        try
        {
            _db = await _dataService.LoadAsync();

            Students.Clear();
            foreach (var s in _db.Students) Students.Add(s);

            Courses.Clear();
            foreach (var c in _db.Courses) Courses.Add(c);

            Enrollments.Clear();
            foreach (var e in _db.Enrollments) Enrollments.Add(e);

            UpdateStats();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async Task SaveAsync()
    {
        try
        {
            _db.Students = Students.ToList();
            _db.Courses = Courses.ToList();
            _db.Enrollments = Enrollments.ToList();

            await _dataService.SaveAsync(_db);
            UpdateStats();

            MessageBox.Show("Data was saved to XML.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void AddStudent()
    {
        var s = new Student { StudyYear = 3 };
        var dlg = new StudentEditWindow(s) { Owner = Application.Current.MainWindow };
        if (dlg.ShowDialog() == true)
        {
            Students.Add(s);
            StudentsView.Refresh();
            UpdateStats();
        }
    }

    private void EditStudent()
    {
        if (SelectedStudent == null) return;

        var copy = Clone(SelectedStudent);
        var dlg = new StudentEditWindow(copy) { Owner = Application.Current.MainWindow };
        if (dlg.ShowDialog() == true)
        {
            SelectedStudent.FirstName = copy.FirstName;
            SelectedStudent.LastName = copy.LastName;
            SelectedStudent.Group = copy.Group;
            SelectedStudent.StudyYear = copy.StudyYear;
            SelectedStudent.GPA = copy.GPA;
            SelectedStudent.HasScholarship = copy.HasScholarship;

            StudentsView.Refresh();
            UpdateStats();
        }
    }

    private void DeleteStudent()
    {
        if (SelectedStudent == null) return;

        var res = MessageBox.Show("Delete the selected student? Their enrollments will also be removed.", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (res != MessageBoxResult.Yes) return;

        // remove related enrollments
        var toRemove = Enrollments.Where(e => e.StudentId == SelectedStudent.Id).ToList();
        foreach (var e in toRemove) Enrollments.Remove(e);

        Students.Remove(SelectedStudent);
        SelectedStudent = null;

        StudentsView.Refresh();
        EnrollmentsView.Refresh();
        UpdateStats();
    }

    private void AddCourse()
    {
        var c = new Course();
        var dlg = new CourseEditWindow(c) { Owner = Application.Current.MainWindow };
        if (dlg.ShowDialog() == true)
        {
            Courses.Add(c);
            CoursesView.Refresh();
            UpdateStats();
        }
    }

    private void EditCourse()
    {
        if (SelectedCourse == null) return;

        var copy = Clone(SelectedCourse);
        var dlg = new CourseEditWindow(copy) { Owner = Application.Current.MainWindow };
        if (dlg.ShowDialog() == true)
        {
            SelectedCourse.Title = copy.Title;
            SelectedCourse.Department = copy.Department;
            SelectedCourse.Credits = copy.Credits;
            SelectedCourse.MaxStudents = copy.MaxStudents;

            CoursesView.Refresh();
            UpdateStats();
        }
    }

    private void DeleteCourse()
    {
        if (SelectedCourse == null) return;

        var res = MessageBox.Show("Delete the selected course? Related enrollments will also be removed.", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (res != MessageBoxResult.Yes) return;

        var toRemove = Enrollments.Where(e => e.CourseId == SelectedCourse.Id).ToList();
        foreach (var e in toRemove) Enrollments.Remove(e);

        Courses.Remove(SelectedCourse);
        SelectedCourse = null;

        CoursesView.Refresh();
        EnrollmentsView.Refresh();
        UpdateStats();
    }

    private void AddEnrollment()
    {
        if (Students.Count == 0 || Courses.Count == 0)
        {
            MessageBox.Show("Please add at least 1 student and 1 course.", "Enrollment", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var e = new Enrollment { RegisteredAt = DateTime.Now };
        var dlg = new EnrollmentEditWindow(e, Students.ToList(), Courses.ToList()) { Owner = Application.Current.MainWindow };
        if (dlg.ShowDialog() == true)
        {
            // basic validation: avoid duplicates
            var dup = Enrollments.Any(x => x.StudentId == e.StudentId && x.CourseId == e.CourseId && x.Status != EnrollmentStatus.Dropped);
            if (dup)
            {
                MessageBox.Show("This student is already enrolled in this course.", "Enrollment", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Enrollments.Add(e);
            EnrollmentsView.Refresh();
            UpdateStats();
        }
    }

    private void EditEnrollment()
    {
        if (SelectedEnrollment == null) return;

        var copy = Clone(SelectedEnrollment);
        var dlg = new EnrollmentEditWindow(copy, Students.ToList(), Courses.ToList()) { Owner = Application.Current.MainWindow };
        if (dlg.ShowDialog() == true)
        {
            SelectedEnrollment.StudentId = copy.StudentId;
            SelectedEnrollment.CourseId = copy.CourseId;
            SelectedEnrollment.RegisteredAt = copy.RegisteredAt;
            SelectedEnrollment.Status = copy.Status;
            SelectedEnrollment.Grade = copy.Grade;

            EnrollmentsView.Refresh();
            UpdateStats();
        }
    }

    private void DeleteEnrollment()
    {
        if (SelectedEnrollment == null) return;

        var res = MessageBox.Show("Delete the selected enrollment?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (res != MessageBoxResult.Yes) return;

        Enrollments.Remove(SelectedEnrollment);
        SelectedEnrollment = null;

        EnrollmentsView.Refresh();
        UpdateStats();
    }

    private void UpdateStats()
    {
        // Calculation 1: count students in selected student's group (or any group filter)
        var group = !string.IsNullOrWhiteSpace(GroupFilter)
            ? GroupFilter.Trim()
            : SelectedStudent?.Group;

		int? groupCount = group == null ? null : StatisticsService.CountStudentsInGroup(_dbWithRuntime(), group);

        // Calculation 2: average grade in selected course
		double? avg = SelectedCourse == null ? null : StatisticsService.AverageGradeForCourse(_dbWithRuntime(), SelectedCourse.Id);

        // Calculation 3 (extra): total credits for selected student
		int? credits = SelectedStudent == null ? null : StatisticsService.TotalCreditsForStudent(_dbWithRuntime(), SelectedStudent.Id);

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Statistics:");
        sb.AppendLine($"• Total students: {Students.Count}");
        sb.AppendLine($"• Total courses: {Courses.Count}");
        sb.AppendLine($"• Total enrollments: {Enrollments.Count}");

        if (group != null)
            sb.AppendLine($"• Students in group \"{group}\": {(groupCount.HasValue ? groupCount.Value.ToString() : "no data")}");

        if (SelectedCourse != null)
            sb.AppendLine($"• Average grade for course \"{SelectedCourse.Title}\": {(avg.HasValue ? avg.Value.ToString("0.00") : "no data")}");

        if (SelectedStudent != null)
            sb.AppendLine($"• Total credits (active/completed) for \"{SelectedStudent.FullName}\": {(credits.HasValue ? credits.Value.ToString() : "no data")}");

        StatsText = sb.ToString();
    }

    private Database _dbWithRuntime()
        => new()
        {
            Students = Students.ToList(),
            Courses = Courses.ToList(),
            Enrollments = Enrollments.ToList()
        };

    private static Student Clone(Student s) => new()
    {
        Id = s.Id,
        FirstName = s.FirstName,
        LastName = s.LastName,
        Group = s.Group,
        StudyYear = s.StudyYear,
        GPA = s.GPA,
        HasScholarship = s.HasScholarship
    };

    private static Course Clone(Course c) => new()
    {
        Id = c.Id,
        Title = c.Title,
        Department = c.Department,
        Credits = c.Credits,
        MaxStudents = c.MaxStudents
    };

    private static Enrollment Clone(Enrollment e) => new()
    {
        Id = e.Id,
        StudentId = e.StudentId,
        CourseId = e.CourseId,
        RegisteredAt = e.RegisteredAt,
        Status = e.Status,
        Grade = e.Grade
    };
}
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Views;

public partial class EnrollmentEditWindow : Window
{
    public sealed class Vm
    {
        public Enrollment Enrollment { get; }
        public List<Student> Students { get; }
        public List<Course> Courses { get; }

        public List<EnrollmentStatus> StatusValues { get; } = new()
        {
            EnrollmentStatus.Active,
            EnrollmentStatus.Completed,
            EnrollmentStatus.Dropped
        };

        public Student? SelectedStudent { get; set; }
        public Course? SelectedCourse { get; set; }

        public Vm(Enrollment enrollment, List<Student> students, List<Course> courses)
        {
            Enrollment = enrollment;
            Students = students;
            Courses = courses;

            SelectedStudent = Students.FirstOrDefault(s => s.Id == enrollment.StudentId);
            SelectedCourse = Courses.FirstOrDefault(c => c.Id == enrollment.CourseId);
        }
    }

    private readonly Vm _vm;

    public EnrollmentEditWindow(Enrollment enrollment, List<Student> students, List<Course> courses)
    {
        InitializeComponent();
        _vm = new Vm(enrollment, students, courses);
        DataContext = _vm;
    }

    private void Ok_OnClick(object sender, RoutedEventArgs e)
    {
        if (_vm.SelectedStudent == null || _vm.SelectedCourse == null)
        {
            MessageBox.Show("Please select a student and a course.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (_vm.Enrollment.Grade.HasValue && (_vm.Enrollment.Grade < 0 || _vm.Enrollment.Grade > 10))
        {
            MessageBox.Show("Grade must be between 0 and 10.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _vm.Enrollment.StudentId = _vm.SelectedStudent.Id;
        _vm.Enrollment.CourseId = _vm.SelectedCourse.Id;

        DialogResult = true;
    }
}

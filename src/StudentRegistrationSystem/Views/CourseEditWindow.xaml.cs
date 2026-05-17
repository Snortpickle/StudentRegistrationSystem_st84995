using System.Windows;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Views;

public partial class CourseEditWindow : Window
{
    public CourseEditWindow(Course course)
    {
        InitializeComponent();
        DataContext = course;
    }

    private void Ok_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not Course c) { DialogResult = false; return; }

        if (string.IsNullOrWhiteSpace(c.Title))
        {
            MessageBox.Show("Course title is required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (c.Credits < 1 || c.Credits > 30)
        {
            MessageBox.Show("Credits must be between 1 and 30.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (c.MaxStudents < 1 || c.MaxStudents > 500)
        {
            MessageBox.Show("Max students must be between 1 and 500.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
    }
}

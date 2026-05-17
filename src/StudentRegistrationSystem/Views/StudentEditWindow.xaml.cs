using System.Windows;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Views;

public partial class StudentEditWindow : Window
{
    public StudentEditWindow(Student student)
    {
        InitializeComponent();
        DataContext = student;
    }

    private void Ok_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not Student s) { DialogResult = false; return; }

        if (string.IsNullOrWhiteSpace(s.FirstName) || string.IsNullOrWhiteSpace(s.LastName))
        {
            MessageBox.Show("First name and last name are required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (s.StudyYear < 1 || s.StudyYear > 6)
        {
            MessageBox.Show("Study year must be between 1 and 6.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (s.GPA < 0 || s.GPA > 10)
        {
            MessageBox.Show("GPA must be between 0 and 10.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
    }
}

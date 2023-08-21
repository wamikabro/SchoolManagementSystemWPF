using SchoolManagementSystem.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace SchoolManagementSystem
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        MenuUC menuUC;
        
        AddStudentUC addStudentUC;
        AddTeacherUC addTeacherUC;
        AddStaffUC addStaffUC;

        SearchStudentUC searchStudentUC;
        SearchTeacherUC searchTeacherUC;
        SearchStaffUC searchStaffUC;

        SettingsUC settingsUC;
        ReportUC reportUC;

        public Home()
        {
            InitializeComponent();

            // Objects
            menuUC = new MenuUC();

            addStudentUC = new AddStudentUC();
            addTeacherUC = new AddTeacherUC();
            addStaffUC = new AddStaffUC();

            searchStudentUC = new SearchStudentUC();
            searchTeacherUC = new SearchTeacherUC();
            searchStaffUC = new SearchStaffUC();

            settingsUC = new SettingsUC();
            reportUC = new ReportUC();

            // Adding into MainContent
            MainContent.Children.Add(menuUC);
            
/*          MainContent.Children.Add(addStudentUC);
            MainContent.Children.Add(addTeacherUC);
            MainContent.Children.Add(addStaffUC);

            MainContent.Children.Add(searchStudentUC);
            MainContent.Children.Add(searchTeacherUC);
            MainContent.Children.Add(searchStaffUC);

            MainContent.Children.Add(settingsUC);
            MainContent.Children.Add(reportUC);

            // Collapse all except menuUC
            addStudentUC.Visibility = addTeacherUC.Visibility 
                = addStaffUC.Visibility = searchStudentUC.Visibility 
                = searchTeacherUC.Visibility = searchStaffUC.Visibility
                = settingsUC.Visibility = reportUC.Visibility 
                = Visibility.Collapsed;*/
        }



        private void addNewButton_Click(object sender, RoutedEventArgs e)
        {
            if (addButtonOptions.Visibility == Visibility.Collapsed)
                addButtonOptions.Visibility = Visibility.Visible;
            else
                addButtonOptions.Visibility = Visibility.Collapsed;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchButtonOptions.Visibility == Visibility.Collapsed)
                searchButtonOptions.Visibility = Visibility.Visible;

            else
                searchButtonOptions.Visibility = Visibility.Collapsed;

        }

        // If any option of Add New Button is Checked
        private void addStudentButton_Checked(object sender, RoutedEventArgs e)
        {
            // deCheck the options from searchButtonOptoins if Checked
            foreach (RadioButton searchButtonOption in searchButtonOptions.Children)
                searchButtonOption.IsChecked = false;

            // Check the "Add New Button"
            addNewButton.IsChecked = true;

        }
        private void addTeacherButton_Checked(object sender, RoutedEventArgs e)
        {
            // deCheck the options from searchButtonOptoins if Checked
            foreach (RadioButton searchButtonOption in searchButtonOptions.Children)
                searchButtonOption.IsChecked = false;

            // Check the "Add New Button"
            addNewButton.IsChecked = true;
        }
        private void addStaffButton_Checked(object sender, RoutedEventArgs e)
        {
            // deCheck the options from searchButtonOptoins if Checked
            foreach (RadioButton searchButtonOption in searchButtonOptions.Children)
                searchButtonOption.IsChecked = false;

            // Check the "Add New Button"
            addNewButton.IsChecked = true;
        }

        // if any option of the Search Button is Checked
        private void searchStudentButton_Checked(object sender, RoutedEventArgs e)
        {
            // deCheck the options from addButtonOptions if checked
            foreach (RadioButton addButtonOption in addButtonOptions.Children)
                addButtonOption.IsChecked = false;

            // Check the "Search Button"
            searchButton.IsChecked = true;
        }
        private void searchTeacherButton_Checked(object sender, RoutedEventArgs e)
        {
            // deselect the options from addButtonOptions if checked
            foreach (RadioButton addButtonOption in addButtonOptions.Children)
                addButtonOption.IsChecked = false;

            // Check the "Search Button"
            searchButton.IsChecked = true;
        }
        private void searchStaffButton_Checked(object sender, RoutedEventArgs e)
        {
            // deselect the options from addButtonOptions if checked
            foreach (RadioButton addButtonOption in addButtonOptions.Children)
                addButtonOption.IsChecked = false;

            // Check the "Search Button"
            searchButton.IsChecked = true;
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is MenuUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new MenuUC());
            }

            // deCheck the options from searchButtonOptoins if Checked
            foreach (RadioButton searchButtonOption in searchButtonOptions.Children)
                searchButtonOption.IsChecked = false;

            // deselect the options from addButtonOptions if checked
            foreach (RadioButton addButtonOption in addButtonOptions.Children)
                addButtonOption.IsChecked = false;
        }

        // Add button options clicked
        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is AddStudentUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new AddStudentUC());
            }
        }
        private void addTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is AddTeacherUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new AddTeacherUC());
            }

        }
        private void addStaffButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is AddStaffUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new AddStaffUC());
            }

        }

        // Search Button Options Click
        private void searchStudentButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is SearchStudentUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new SearchStudentUC());
            }

        }

        private void searchTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is SearchTeacherUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new SearchTeacherUC());
            }

        }

        private void searchStaffButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is SearchStaffUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new SearchStaffUC());
            }

        }

        // remaining buttons
        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is SettingsUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new SettingsUC());
            }

            // deCheck the options from searchButtonOptoins if Checked
            foreach (RadioButton searchButtonOption in searchButtonOptions.Children)
                searchButtonOption.IsChecked = false;

            // deselect the options from addButtonOptions if checked
            foreach (RadioButton addButtonOption in addButtonOptions.Children)
                addButtonOption.IsChecked = false;
        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the UC is already added, otherwise add.
            bool contains = false;
            foreach (UIElement child in MainContent.Children)
                if (child is ReportUC) contains = true;

            if (!contains)
            {
                MainContent.Children.Clear();
                MainContent.Children.Add(new ReportUC());
            }

            // deCheck the options from searchButtonOptoins if Checked
            foreach (RadioButton searchButtonOption in searchButtonOptions.Children)
                searchButtonOption.IsChecked = false;

            // deselect the options from addButtonOptions if checked
            foreach (RadioButton addButtonOption in addButtonOptions.Children)
                addButtonOption.IsChecked = false;
        }
    }
}

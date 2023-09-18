using SchoolManagementSystem.Functionality.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolManagementSystem.User_Controls
{
    /// <summary>
    /// Interaction logic for SearchStudentUC.xaml
    /// </summary>
    public partial class SearchStudentUC : UserControl
    {
        DataTable dataTable;
        bool filteredData = false;
        public SearchStudentUC()
        {
            InitializeComponent();
            LoadStudentDataGrid();
        }

        // database connection 
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");
        
        public void LoadStudentDataGrid()
        {
            SqlCommand loadStudentData = new 
                SqlCommand("SELECT * FROM StudentTable", con);
            
            dataTable = new DataTable();
            
            con.Open();
            SqlDataReader sqlDataReader = loadStudentData.ExecuteReader();
            dataTable.Load(sqlDataReader);
            con.Close();

            StudentDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text != String.Empty)
            {
                filteredData = true;
                // Get the filter criteria from the search box
                string filter = SearchTextBox.Text.ToLower();

                dataTable.DefaultView.RowFilter = "ID LIKE '%" + filter +
                    "%' OR FirstName LIKE '%" + filter +
                    "%' OR LastName LIKE '%" + filter +
                    "%' OR FatherName LIKE '%" + filter +
                    "%' OR Email LIKE '%" + filter + "%'";

                // Refresh the DataGridView to reflect the filtered data
                StudentDataGrid.ItemsSource = dataTable.DefaultView;
            }

            if (filteredData == true && SearchTextBox.Text == String.Empty)
            {
                filteredData = false;
                LoadStudentDataGrid();
            }

        }

        private void StudentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the selected item (row) when double-clicked
            DataRowView selectedItem = (DataRowView)StudentDataGrid.SelectedItem;

            if (selectedItem!= null)
            {

                // Create an instance of StudentDetailsDialog
                StudentDetailsDialog studentDetailsDialog = new StudentDetailsDialog();

                // Populate the UserControl's data elements with the selected data
                studentDetailsDialog.FirstNameTextBox.Text = (string) selectedItem["FirstName"];
                studentDetailsDialog.LastNameTextBox.Text = (string) selectedItem["LastName"];
                studentDetailsDialog.FatherNameTextBox.Text = (string) selectedItem["FatherName"];

                studentDetailsDialog.GenderComboBox.SelectedIndex =
                    selectedItem["Gender"].ToString().Equals("Male") ? 0 : 1;

                studentDetailsDialog.GradeComboBox.SelectedItem = selectedItem["Grade"];
                studentDetailsDialog.PhoneNumberTextBox.Text = (string) selectedItem["PhoneNumber"];
                studentDetailsDialog.EmailTextBox.Text = (string) selectedItem["Email"];
                studentDetailsDialog.BloodGroupComboBox.SelectedItem = (string) selectedItem["BloodGroup"];
                studentDetailsDialog.AddressTextBox.Text = (string) selectedItem["Address"];
                studentDetailsDialog.GuardianNameTextBox.Text = (string) selectedItem["GuardianName"];
                studentDetailsDialog.DOBDatePicker.SelectedDate = (DateTime) selectedItem["DateOfBirth"];
                studentDetailsDialog.DOADatePicker.SelectedDate = (DateTime) selectedItem["DateOfAdmissions"];

                // Create and show the dialog window
                var dialogWindow = new Window
                {
                    Content = studentDetailsDialog,
                    Title = "Student Details",
                    Width = 400,
                    Height = 450,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                dialogWindow.ShowDialog();
            }
        }
    }
}

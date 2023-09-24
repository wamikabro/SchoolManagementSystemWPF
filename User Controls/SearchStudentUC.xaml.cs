using MySqlX.XDevAPI.Relational;
using SchoolManagementSystem.Functionality.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
        Window dialogWindow;
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

            FilterStudents();
        }

        public void FilterStudents()
        {
            if (SearchTextBox.Text != String.Empty)
            {
                filteredData = true;

                // Get the filter string
                string filter = SearchTextBox.Text.ToLower();

                // in case given filter is ID and check it against ID
                int filterID = 0;
                if (int.TryParse(SearchTextBox.Text, out int result))
                    filterID = result;

                // Initialize filter expressions for ID and string columns
                string idFilterExpression = "ID = " + filterID;
                string stringFilterExpression = "FirstName LIKE '%" + filter +
                    "%' OR LastName LIKE '%" + filter +
                    "%' OR FatherName LIKE '%" + filter +
                    "%' OR Email LIKE '%" + filter + "%'";

                // Combine the filter expressions based on whether filterID is zero
                string combinedFilterExpression = filterID != 0 ?
                    "(" + idFilterExpression + ") OR (" + stringFilterExpression + ")" :
                    stringFilterExpression;

                dataTable.DefaultView.RowFilter = combinedFilterExpression;


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
                StudentDetailsDialog studentDetailsDialog = new StudentDetailsDialog((int)selectedItem["ID"]);

                // Subscribing to the event
                studentDetailsDialog.StudentUpdated += StudentDetailsDialog_StudentUpdated;

                // Populate the UserControl's data elements with the selected data
                studentDetailsDialog.FirstNameTextBox.Text = (string) selectedItem["FirstName"];
                studentDetailsDialog.LastNameTextBox.Text = (string) selectedItem["LastName"];
                studentDetailsDialog.FatherNameTextBox.Text = (string) selectedItem["FatherName"];

                // Set right gender by first converting gender to string and comparing it with
                // Male, if gender is male then set GenderComboBox's index to 0 otherwise 1.
                studentDetailsDialog.GenderComboBox.SelectedIndex =
                    selectedItem["Gender"].ToString().Equals("Male") ? 0 : 1;

                // Cast the Grade to int. As we know Grade 1 is on 0 index and so on.
                // So by subtracting 1, we are actually chosing the right grade from combobox
                // eg. Student is in Grade 3. To chose grade 3 from Index of Combo box we need 2 index
                // which is 3 - 1 = 2. That's what we've done.
                studentDetailsDialog.GradeComboBox.SelectedIndex = (int) selectedItem["Grade"] - 1;


                studentDetailsDialog.PhoneNumberTextBox.Text = (string) selectedItem["PhoneNumber"];
                studentDetailsDialog.EmailTextBox.Text = (string) selectedItem["Email"];

                /*
                // This way of showing right BloodGroup isn't working because I don't know
                // How to loop through ComboBox items.
                
                for(int i = 0; i < studentDetailsDialog.BloodGroupComboBox.Items.Count; i++)
                {
                    if (selectedItem["BloodGroup"].
                        ToString().
                        Equals(studentDetailsDialog.BloodGroupComboBox.Items[i].ToString()))
                    {
                        studentDetailsDialog.BloodGroupComboBox.SelectedIndex = i;
                    }
                    
                }*/

                // Fetched BloodGroup and converted to ToString. 
                // Checked one by one, and showed the one that matches.
                string BloodGroupText = selectedItem["BloodGroup"].ToString();
                if (BloodGroupText.Equals("ONegative"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 0;
                else if (BloodGroupText.Equals("OPositive"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 1;
                else if (BloodGroupText.Equals("ANegative"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 2;
                else if (BloodGroupText.Equals("APositive"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 3;
                else if (BloodGroupText.Equals("BNegative"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 4;
                else if (BloodGroupText.Equals("BPositive"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 5;
                else if (BloodGroupText.Equals("ABNegative"))
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 6;
                else
                    studentDetailsDialog.BloodGroupComboBox.SelectedIndex = 7;

                studentDetailsDialog.AddressTextBox.Text = (string) selectedItem["Address"];
                studentDetailsDialog.GuardianNameTextBox.Text = (string) selectedItem["GuardianName"];
                studentDetailsDialog.DOBDatePicker.SelectedDate = (DateTime) selectedItem["DateOfBirth"];
                studentDetailsDialog.DOADatePicker.SelectedDate = (DateTime) selectedItem["DateOfAdmissions"];

                // Show the dialog window
                dialogWindow = new Window
                {
                    Content = studentDetailsDialog,
                    Title = "Student Details",
                    Width = 400,
                    Height = 450,
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                dialogWindow.ShowDialog();

        

            }
        }

        // Handle the event
        private void StudentDetailsDialog_StudentUpdated(object sender, EventArgs e)
        {
            // Refresh the student table
            LoadStudentDataGrid();

            // Apply the filters if any
            FilterStudents();
        }

        


    }
}

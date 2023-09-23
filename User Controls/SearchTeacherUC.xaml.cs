using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for SearchTeacherUC.xaml
    /// </summary>
    public partial class SearchTeacherUC : UserControl
    {
        DataTable dataTable;
        bool filteredData = false;
        public SearchTeacherUC()
        {
            InitializeComponent();
            LoadTeacherDataGrid();
        }

        // database connection 
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");

        public void LoadTeacherDataGrid()
        {
            SqlCommand loadTeacherData = new
                SqlCommand("SELECT * FROM TeacherTable", con);
            dataTable = new DataTable();

            con.Open();
            SqlDataReader sqlDataReader = loadTeacherData.ExecuteReader();
            dataTable.Load(sqlDataReader);
            con.Close();

            TeacherDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FilterTeachers();
        }

        public void FilterTeachers()
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
                TeacherDataGrid.ItemsSource = dataTable.DefaultView;
            }

            if (filteredData == true && SearchTextBox.Text == String.Empty)
            {
                filteredData = false;
                LoadTeacherDataGrid();
            }
        }

        private void TeacherDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the selected item (row) when double-clicked
            DataRowView selectedItem = (DataRowView)TeacherDataGrid.SelectedItem;

            if (selectedItem != null)
            {

                // Create an instance of StudentDetailsDialog
                TeacherDetailsDialog teacherDetailsDialog = new TeacherDetailsDialog((int)selectedItem["ID"]);

                // Subscribing to the event
                teacherDetailsDialog.TeacherUpdated += TeacherDetailsDialog_TeacherUpdated;

                // Populate the UserControl's data elements with the selected data
                teacherDetailsDialog.FirstNameTextBox.Text = (string)selectedItem["FirstName"];
                teacherDetailsDialog.LastNameTextBox.Text = (string)selectedItem["LastName"];
                teacherDetailsDialog.FatherNameTextBox.Text = (string)selectedItem["FatherName"];

                // Set right gender by first converting gender to string and comparing it with
                // Male, if gender is male then set GenderComboBox's index to 0 otherwise 1.
                teacherDetailsDialog.GenderComboBox.SelectedIndex =
                    selectedItem["Gender"].ToString().Equals("Male") ? 0 : 1;

                // Cast the Grade to int. As we know Grade 1 is on 0 index and so on.
                // So by subtracting 1, we are actually chosing the right grade from combobox
                // eg. Student is in Grade 3. To chose grade 3 from Index of Combo box we need 2 index
                // which is 3 - 1 = 2. That's what we've done.
                teacherDetailsDialog.GradeComboBox.SelectedIndex = (int)selectedItem["Grade"] - 1;


                teacherDetailsDialog.PhoneNumberTextBox.Text = (string)selectedItem["PhoneNumber"];
                teacherDetailsDialog.EmailTextBox.Text = (string)selectedItem["Email"];

                /*
                // This way of showing right BloodGroup isn't working because I don't know
                // How to loop through ComboBox items.
                
                for(int i = 0; i < teacherDetailsDialog.BloodGroupComboBox.Items.Count; i++)
                {
                    if (selectedItem["BloodGroup"].
                        ToString().
                        Equals(teacherDetailsDialog.BloodGroupComboBox.Items[i].ToString()))
                    {
                        teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = i;
                    }
                    
                }*/

                // Fetched BloodGroup and converted to ToString. 
                // Checked one by one, and showed the one that matches.
                string BloodGroupText = selectedItem["BloodGroup"].ToString();
                if (BloodGroupText.Equals("ONegative"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 0;
                else if (BloodGroupText.Equals("OPositive"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 1;
                else if (BloodGroupText.Equals("ANegative"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 2;
                else if (BloodGroupText.Equals("APositive"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 3;
                else if (BloodGroupText.Equals("BNegative"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 4;
                else if (BloodGroupText.Equals("BPositive"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 5;
                else if (BloodGroupText.Equals("ABNegative"))
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 6;
                else
                    teacherDetailsDialog.BloodGroupComboBox.SelectedIndex = 7;

                teacherDetailsDialog.AddressTextBox.Text = (string)selectedItem["Address"];
                teacherDetailsDialog.SubjectTextBox.Text = (string)selectedItem["Subject"];
                teacherDetailsDialog.DOBDatePicker.SelectedDate = (DateTime)selectedItem["DateOfBirth"];
                teacherDetailsDialog.DOADatePicker.SelectedDate = (DateTime)selectedItem["DateOfAdmissions"];

                // Create and show the dialog window
                var dialogWindow = new Window
                {
                    Content = teacherDetailsDialog,
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
        private void TeacherDetailsDialog_TeacherUpdated(object sender, EventArgs e)
        {
            // Refresh the student table
            LoadTeacherDataGrid();

            // Apply the filters if any
            FilterTeachers();
        }


    }
}

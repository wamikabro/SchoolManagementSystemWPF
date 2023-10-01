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
using System.Configuration;

namespace SchoolManagementSystem.User_Controls
{
    /// <summary>
    /// Interaction logic for SearchStaffUC.xaml
    /// </summary>
 

    public partial class SearchStaffUC : UserControl
    {
        DataTable dataTable;
        bool filteredData = false;
        public SearchStaffUC()
        {
            InitializeComponent();
            LoadStaffDataGrid();
        }

        // database connection 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);

        public void LoadStaffDataGrid()
        {
            SqlCommand loadStaffData = new
                SqlCommand("SELECT * FROM StaffTable", con);
            dataTable = new DataTable();

            con.Open();
            SqlDataReader sqlDataReader = loadStaffData.ExecuteReader();
            dataTable.Load(sqlDataReader);
            con.Close();

            StaffDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FilterStaff();
        }

        public void FilterStaff()
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
                StaffDataGrid.ItemsSource = dataTable.DefaultView;
            }

            if (filteredData == true && SearchTextBox.Text == String.Empty)
            {
                filteredData = false;
                LoadStaffDataGrid();
            }
        }

        private void StaffDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the selected item (row) when double-clicked
            DataRowView selectedItem = (DataRowView)StaffDataGrid.SelectedItem;

            if (selectedItem != null)
            {

                // Create an instance of StaffDetailsDialog
                StaffDetailsDialog staffDetailsDialog = new StaffDetailsDialog((int)selectedItem["ID"]);

                // Subscribing to the event
                staffDetailsDialog.StaffUpdated += StaffDetailsDialog_StaffUpdated;

                // Populate the UserControl's data elements with the selected data
                staffDetailsDialog.FirstNameTextBox.Text = (string)selectedItem["FirstName"];
                staffDetailsDialog.LastNameTextBox.Text = (string)selectedItem["LastName"];
                staffDetailsDialog.FatherNameTextBox.Text = (string)selectedItem["FatherName"];
                staffDetailsDialog.JobTitleTextBox.Text = (string)selectedItem["JobTitle"];
                staffDetailsDialog.PhoneNumberTextBox.Text = (string)selectedItem["PhoneNumber"];
                staffDetailsDialog.EmailTextBox.Text = (string)selectedItem["Email"];
                
                // Fetched BloodGroup and converted to ToString. 
                // Checked one by one, and showed the one that matches.
                string BloodGroupText = selectedItem["BloodGroup"].ToString();
                if (BloodGroupText.Equals("ONegative"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 0;
                else if (BloodGroupText.Equals("OPositive"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 1;
                else if (BloodGroupText.Equals("ANegative"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 2;
                else if (BloodGroupText.Equals("APositive"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 3;
                else if (BloodGroupText.Equals("BNegative"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 4;
                else if (BloodGroupText.Equals("BPositive"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 5;
                else if (BloodGroupText.Equals("ABNegative"))
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 6;
                else
                    staffDetailsDialog.BloodGroupComboBox.SelectedIndex = 7;

                staffDetailsDialog.AddressTextBox.Text = (string)selectedItem["Address"];
                staffDetailsDialog.DOBDatePicker.SelectedDate = (DateTime)selectedItem["DateOfBirth"];
                staffDetailsDialog.DOADatePicker.SelectedDate = (DateTime)selectedItem["DateOfAdmissions"];

                // Create and show the dialog window
                var dialogWindow = new Window
                {
                    Content = staffDetailsDialog,
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
        private void StaffDetailsDialog_StaffUpdated(object sender, EventArgs e)
        {
            // Refresh the student table
            LoadStaffDataGrid();

            // Apply the filters if any
            FilterStaff();
        }
    }
}

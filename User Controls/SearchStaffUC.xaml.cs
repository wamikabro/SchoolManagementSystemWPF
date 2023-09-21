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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");

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
            if (SearchTextBox.Text != String.Empty)
            {
                filteredData = true;
                // Get the filter criteria from the search box
                string filter = SearchTextBox.Text.ToLower();

                dataTable.DefaultView.RowFilter = "FirstName LIKE '%" + filter +
                    "%' OR LastName LIKE '%" + filter +
                    "%' OR FatherName LIKE '%" + filter +
                    "%' OR Email LIKE '%" + filter + "%'";

                // Refresh the DataGridView to reflect the filtered data
                StaffDataGrid.ItemsSource = dataTable.DefaultView;
            }

            if (filteredData == true && SearchTextBox.Text == String.Empty)
            {
                filteredData = false;
                LoadStaffDataGrid();
            }
        }
    }
}

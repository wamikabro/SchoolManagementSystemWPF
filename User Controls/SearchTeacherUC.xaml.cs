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
                TeacherDataGrid.ItemsSource = dataTable.DefaultView;
            }

            if (filteredData == true && SearchTextBox.Text == String.Empty)
            {
                filteredData = false;
                LoadTeacherDataGrid();
            }
        }
    }
}

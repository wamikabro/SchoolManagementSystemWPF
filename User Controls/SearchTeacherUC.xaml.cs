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
            DataTable dataTable = new DataTable();

            con.Open();
            SqlDataReader sqlDataReader = loadTeacherData.ExecuteReader();
            dataTable.Load(sqlDataReader);
            con.Close();

            TeacherDataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}

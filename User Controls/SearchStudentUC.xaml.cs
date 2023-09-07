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
            DataTable dataTable = new DataTable();
            
            con.Open();
            SqlDataReader sqlDataReader = loadStudentData.ExecuteReader();
            dataTable.Load(sqlDataReader);
            con.Close();

            StudentDataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}

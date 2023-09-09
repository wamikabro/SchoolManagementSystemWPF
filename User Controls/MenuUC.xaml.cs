using System;
using System.Collections.Generic;
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
    /// Interaction logic for MenuUC.xaml
    /// </summary>
    public partial class MenuUC : UserControl
    {
        // SQL Connection
        protected SqlConnection con;


        public string Grade1Teacher { get; set; }
        public string Grade2Teacher { get; set; }
        public string Grade3Teacher { get; set; }
        public string Grade4Teacher { get; set; }
        public string Grade5Teacher { get; set; }
        public string Grade6Teacher { get; set; }
        public string Grade7Teacher { get; set; }
        public string Grade8Teacher { get; set; }
 
        public MenuUC()
        {
            InitializeComponent();
            

            con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");
            con.Open();

            DataContext = this;
            ExtractTeacherNames();
            
            

        }

        public void ExtractTeacherNames()
        {
            try
            {
                // Extracting Names

                // Grade 1
                SqlCommand teacherGrade1 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 1", con);
                SqlDataReader reader1 = teacherGrade1.ExecuteReader();
                reader1.Read();
                Grade1Teacher = reader1["FirstName"].ToString() + " " + reader1["LastName"].ToString();

                // Grade 2
                SqlCommand teacherGrade2 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 2", con);
                SqlDataReader reader2 = teacherGrade2.ExecuteReader();
                reader2.Read();
                Grade2Teacher = reader2["FirstName"].ToString() + " " + reader2["LastName"].ToString();

                // Grade 3
                SqlCommand teacherGrade3 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 3", con);
                SqlDataReader reader3 = teacherGrade3.ExecuteReader();
                reader3.Read();
                Grade3Teacher = reader3["FirstName"].ToString() + " " + reader3["LastName"].ToString();

                // Grade 4
                SqlCommand teacherGrade4 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 4", con);
                SqlDataReader reader4 = teacherGrade4.ExecuteReader();
                reader4.Read();
                Grade4Teacher = reader4["FirstName"].ToString() + " " + reader4["LastName"].ToString();

                // Grade 5
                SqlCommand teacherGrade5 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 5", con);
                SqlDataReader reader5 = teacherGrade5.ExecuteReader();
                reader5.Read();
                Grade5Teacher = reader5["FirstName"].ToString() + " " + reader5["LastName"].ToString();

                // Grade 6
                SqlCommand teacherGrade6 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 6", con);
                SqlDataReader reader6 = teacherGrade6.ExecuteReader();
                reader6.Read();
                Grade6Teacher = reader6["FirstName"].ToString() + " " + reader6["LastName"].ToString();

                // Grade 7
                SqlCommand teacherGrade7 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 7", con);
                SqlDataReader reader7 = teacherGrade7.ExecuteReader();
                reader7.Read();
                Grade7Teacher = reader7["FirstName"].ToString() + " " + reader7["LastName"].ToString();

                // Grade 5
                SqlCommand teacherGrade8 = new
                SqlCommand("SELECT FirstName, LastName FROM TeacherTable WHERE Grade = 8", con);
                SqlDataReader reader8 = teacherGrade8.ExecuteReader();
                reader8.Read();
                Grade8Teacher = reader8["FirstName"].ToString() + " " + reader8["LastName"].ToString();
            }
            catch (Exception)
            {

            }
        }


    }
}

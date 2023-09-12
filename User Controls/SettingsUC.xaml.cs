using MySql.Data.MySqlClient;
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
    /// Interaction logic for SettingsUC.xaml
    /// </summary>
    public partial class SettingsUC : UserControl
    {
        // SQL Connection
        protected SqlConnection con;



        public SettingsUC()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");

            con.Open();

            SqlCommand fontSizeDatabase = new
                SqlCommand("SELECT FontSize from Settings", con);
            SqlDataReader reader = fontSizeDatabase.ExecuteReader();
            reader.Read();

            FontSizeSlider.Value = reader.GetInt32(0);

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");
            con.Open();

            SqlCommand updateFontSize = new SqlCommand("UPDATE Settings SET FontSize = @NewFontSize", con);
            updateFontSize.Parameters.AddWithValue("@NewFontSize", FontSizeSlider.Value);
            updateFontSize.ExecuteNonQuery();
        }
    }
}

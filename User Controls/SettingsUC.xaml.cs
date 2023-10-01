using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);

            con.Open();

            SqlCommand fontSizeDatabase = new
                SqlCommand("SELECT FontSize from Settings", con);
            SqlDataReader reader = fontSizeDatabase.ExecuteReader();
            reader.Read();

            FontSizeSlider.Value = reader.GetInt32(0);

            SetThemeSwitchState();

            con.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            con.Open();

            SqlCommand updateFontSize = new SqlCommand("UPDATE Settings SET FontSize = @NewFontSize", con);
            updateFontSize.Parameters.AddWithValue("@NewFontSize", FontSizeSlider.Value);
            updateFontSize.ExecuteNonQuery();

            SqlCommand updateThemeSwitch = new SqlCommand("UPDATE Settings SET ThemeSwitch = @NewThemeSwitch", con);
            updateThemeSwitch.Parameters.AddWithValue("NewThemeSwitch", ThemeSwitch.IsChecked);
            updateThemeSwitch.ExecuteNonQuery();

            con.Close();
        }

        private void ThemeSwitch_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary darkTheme = new ResourceDictionary{
                Source = new Uri("ResourceDictionaries/DarkTheme.xaml", UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
        }

        private void ThemeSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary lightTheme = new ResourceDictionary
            {
                Source = new Uri("ResourceDictionaries/LightTheme.xaml", UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(lightTheme);

        }

        private void SetThemeSwitchState()
        {
            ThemeSwitch.IsChecked = Application.Current.Resources.MergedDictionaries
                .Any(dictionary =>
                    dictionary.Source != null && dictionary.Source.OriginalString == "ResourceDictionaries/DarkTheme.xaml");
        }
    }
}

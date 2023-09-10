using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ReportUC.xaml
    /// </summary>
    public partial class ReportUC : UserControl
    {
        public ReportUC()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string subject = SubjectTextBox.Text;
                string issue = IssueTextBox.Text;

                // Specify the recipient email address (replace with the desired email address)
                string recipientEmail = "wamik.abro212@gmail.com";

                // Compose the mailto URL with subject, body, and recipient
                string mailtoUrl = $"mailto:{recipientEmail}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(issue)}";

                // Start the default email client
                Process.Start(mailtoUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}

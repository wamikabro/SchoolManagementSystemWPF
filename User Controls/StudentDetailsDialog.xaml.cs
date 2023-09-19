using System;
using System.Collections.Generic;
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
    /// Interaction logic for StudentDetailsDialog.xaml
    /// </summary>
    public partial class StudentDetailsDialog : UserControl
    {
        public StudentDetailsDialog()
        {
            InitializeComponent();
        }

        private void EditLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FirstNameTextBox.IsReadOnly = false;
            LastNameTextBox.IsReadOnly = false;
            FatherNameTextBox.IsReadOnly = false;
            GenderComboBox.IsEnabled = true;
            GradeComboBox.IsEnabled = true;
            PhoneNumberTextBox.IsReadOnly = false;
            EmailTextBox.IsReadOnly = false;
            BloodGroupComboBox.IsEnabled = true;
            AddressTextBox.IsReadOnly = false;
            GuardianNameTextBox.IsReadOnly = false;
            DOBDatePicker.IsEnabled = true;
            DOADatePicker.IsEnabled = true;
            SaveButton.IsEnabled = true;

        }
    }
}

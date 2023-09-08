using SchoolManagementSystem.Functionality.Enums;
using SchoolManagementSystem.Functionality;
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
    /// Interaction logic for AddStaffUC.xaml
    /// </summary>
    public partial class AddStaffUC : UserControl
    {
        public AddStaffUC()
        {
            InitializeComponent();
            DOADatePicker.SelectedDate = DateTime.Today;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Fetching the selections
            DateTime dateOfBirth;
            try
            {
                dateOfBirth = (DateTime)DOBDatePicker.SelectedDate;
            }
            catch (Exception)
            {
                MessageBox.Show("Date of Birth must be set.");
                return;
            }


            DateTime dateOfAdmissions;
            try
            {
                dateOfAdmissions = (DateTime)DOADatePicker.SelectedDate;
            }
            catch (Exception)
            {
                MessageBox.Show("Date of Admissions must be set.");
                return;
            }

            String firstName = FirstNameTextBox.Text;
            String lastName = LastNameTextBox.Text;
            String fatherName = FatherNameTextBox.Text;


            String genderText = GenderComboBox.Text;
            Gender gender;
            Enum.TryParse(genderText, out gender);

            String phoneNumber = PhoneNumberTextBox.Text;
            String email = EmailTextBox.Text;

            String bloodGroupText = BloodGroupComboBox.Text;
            BloodType bloodGroup;
            Enum.TryParse(bloodGroupText, out bloodGroup);

            String address = AddressTextBox.Text;
            String jobTitle = JobTitleTextBox.Text;
            try
            {
                // Data verification will be done in the class
                Staff staff = new Staff(firstName, lastName, fatherName, gender,
                    phoneNumber, email, bloodGroup, address, jobTitle, dateOfBirth,
                    dateOfAdmissions);

                staff.StoreStaff();

                // After submission reset entries
                ResetEntries();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ResetEntries()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            FatherNameTextBox.Text = "";
            GenderComboBox.SelectedIndex = 0;
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            BloodGroupComboBox.SelectedIndex = 0;
            AddressTextBox.Text = "";
            JobTitleTextBox.Text = "";
            DOBDatePicker.SelectedDate = null;
            DOADatePicker.SelectedDate = DateTime.Today;
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetEntries();
        }
    }
}

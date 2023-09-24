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
    /// Interaction logic for StaffDetailsDialog.xaml
    /// </summary>
    public partial class StaffDetailsDialog : UserControl
    {
        // to hold the id of teacher whose details are being changed.
        // the id will be set by SearchTeacherUC because it knows what item was clicked.
        int id;

        // Define an event to notify of successful updates
        public event EventHandler StaffUpdated;
        public StaffDetailsDialog(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void EditLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FirstNameTextBox.IsReadOnly = false;
            LastNameTextBox.IsReadOnly = false;
            FatherNameTextBox.IsReadOnly = false;
            GenderComboBox.IsEnabled = true;
            JobTitleTextBox.IsReadOnly = false;
            PhoneNumberTextBox.IsReadOnly = false;
            EmailTextBox.IsReadOnly = false;
            BloodGroupComboBox.IsEnabled = true;
            AddressTextBox.IsReadOnly = false;
            DOBDatePicker.IsEnabled = true;
            DOADatePicker.IsEnabled = true;
            SaveButton.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
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

            String firstName = FirstNameTextBox.Text.ToLower();
            String lastName = LastNameTextBox.Text.ToLower();
            String fatherName = FatherNameTextBox.Text.ToLower();


            String genderText = GenderComboBox.Text;
            Gender gender;
            Enum.TryParse(genderText, out gender);

            String jobTitle = JobTitleTextBox.Text;
            String phoneNumber = PhoneNumberTextBox.Text;
            String email = EmailTextBox.Text.ToLower();


            String bloodGroupText = BloodGroupComboBox.Text;
            BloodType bloodGroup;
            Enum.TryParse(bloodGroupText, out bloodGroup);

            String address = AddressTextBox.Text;

            try
            {
                // Data verification will be done in the class
                Staff staff = new Staff(firstName, lastName, fatherName, gender,
                    phoneNumber, email, bloodGroup, address, jobTitle, dateOfBirth,
                    dateOfAdmissions);

                // send id that was recieved from SearchStaffUC while constructing
                // StaffDetailsDialog
                staff.UpdateStaff(id);

                // Raise the event because staff is successfully updated.
                OnStaffUpdated(EventArgs.Empty);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // event to be called on Staff Updated Successfully
        protected virtual void OnStaffUpdated(EventArgs e)
        {
            StaffUpdated?.Invoke(this, e);
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}

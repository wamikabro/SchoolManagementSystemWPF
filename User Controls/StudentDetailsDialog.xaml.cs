using SchoolManagementSystem.Functionality;
using SchoolManagementSystem.Functionality.Enums;
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
        // to hold the id of student whose details are being changed.
        // the id will be set by SearchStudentUC because it knows what item was clicked.
        int id;

        // Define an event to notify of successful updates
        public event EventHandler StudentUpdated;

        // Okay button has been clicked event
        public event EventHandler OkayButtonClicked;

        public StudentDetailsDialog(int id)
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

            int grade = int.Parse(GradeComboBox.Text);
            String phoneNumber = PhoneNumberTextBox.Text;
            String email = EmailTextBox.Text.ToLower();


            String bloodGroupText = BloodGroupComboBox.Text;
            BloodType bloodGroup;
            Enum.TryParse(bloodGroupText, out bloodGroup);

            String address = AddressTextBox.Text;
            String guardianName = GuardianNameTextBox.Text;

            try
            {
                // Data verification will be done in the class
                Student student = new Student(firstName, lastName, fatherName, gender, grade,
                    phoneNumber, email, bloodGroup, address, guardianName, dateOfBirth,
                    dateOfAdmissions);

                // send id that was recieved from SearchStudentUC while constructing
                // StudentDetailsDialog
                student.UpdateStudent(id);

                // Raise the event because setudent is successfully updated.
                OnStudentUpdated(EventArgs.Empty);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // event to be called on Student Updated Successfully
        protected virtual void OnStudentUpdated(EventArgs e)
        {
            StudentUpdated?.Invoke(this, e);
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {

            // Close the dialog window (the parent window that hosts this UserControl)
            Window.GetWindow(this).Close();
            
        }


    }
}

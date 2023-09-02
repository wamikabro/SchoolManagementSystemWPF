﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using SchoolManagementSystem.Functionality;
using SchoolManagementSystem.Functionality.Enums;

namespace SchoolManagementSystem.User_Controls
{
    /// <summary>
    /// Interaction logic for AddStudentUC.xaml
    /// </summary>
    public partial class AddStudentUC : UserControl
    {
        public AddStudentUC()
        {
            InitializeComponent();
            DOADatePicker.SelectedDate = DateTime.Today;
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Fetching the selections
            String firstName = FirstNameTextBox.Text;
            String lastName = LastNameTextBox.Text;
            String fatherName = FatherNameTextBox.Text;
            
            
            String genderText = GenderComboBox.Text;
            Gender gender;
            Enum.TryParse(genderText, out gender);

            int grade = int.Parse(GradeComboBox.Text);
            String phoneNumber = PhoneNumberTextBox.Text;
            String email = EmailTextBox.Text;


            String bloodGroupText = BloodGroupComboBox.Text;
            BloodType bloodGroup;
            Enum.TryParse(bloodGroupText, out bloodGroup);
                        
            String address = AddressTextBox.Text;
            String guardianName = GuardianNameTextBox.Text;
            DateTime dateOfBirth;
            try
            {
                dateOfBirth = (DateTime)DOBDatePicker.SelectedDate;
            }
            catch(Exception)
            {
                MessageBox.Show("Date of Birth must be set.");
                return;
            }


            DateTime dateOfAdmissions = (DateTime) DOADatePicker.SelectedDate;

            Student student = new Student(firstName, lastName, fatherName, gender, grade, 
                phoneNumber, email, bloodGroup, address, guardianName, dateOfBirth,
                dateOfAdmissions);

            /*MessageBox.Show(firstName + "\n" 
                + lastName + "\n"
                + fatherName + "\n"
                + gender + "\n"
                + grade + "\n"
                + phoneNumber + "\n"
                + email + "\n"
                + bloodGroup + "\n"
                + address + "\n"
                + guardianName + "\n"
                + dateOfBirth + "\n"
                + dateOfAdmissions + "\n");*/

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

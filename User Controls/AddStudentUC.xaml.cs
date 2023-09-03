using System;
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
using System.Data;

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

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");

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

            int grade = int.Parse(GradeComboBox.Text);
            String phoneNumber = PhoneNumberTextBox.Text;
            String email = EmailTextBox.Text;


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
                try
                {

                    // Store data in the Database
                    SqlCommand storeStudent = new
                        SqlCommand("INSERT INTO StudentTable VALUES (@FirstName, @LastName, @FatherName, @Gender, @Grade, @PhoneNumber, @Email, @BloodGroup, @Address, @GuardianName, @DateOfBirth, @DateOfAdmissions)", con);
                    // command type
                    storeStudent.CommandType = CommandType.Text;

                    // placement
                    storeStudent.Parameters.AddWithValue("@FirstName", firstName);
                    storeStudent.Parameters.AddWithValue("@LastName", lastName);
                    storeStudent.Parameters.AddWithValue("@FatherName", fatherName);
                    storeStudent.Parameters.AddWithValue("@Gender", gender);
                    storeStudent.Parameters.AddWithValue("@Grade", grade);
                    storeStudent.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    storeStudent.Parameters.AddWithValue("@Email", email);
                    storeStudent.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                    storeStudent.Parameters.AddWithValue("@Address", address);
                    storeStudent.Parameters.AddWithValue("@GuardianName", guardianName);
                    storeStudent.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    storeStudent.Parameters.AddWithValue("@DateOfAdmissions", dateOfAdmissions);



                    con.Open();
                    storeStudent.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

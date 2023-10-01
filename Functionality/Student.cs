using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Functionality.Enums;
using System.Windows;

namespace SchoolManagementSystem.Functionality
{
    public class Student : Person
    {
        private string guardianName;



        public Student(string firstName, string lastName,
                string fatherName, Gender gender, int grade, string phoneNumber, string email,
                BloodType bloodGroup, string address, string guardianName, DateTime dateOfBirth, DateTime dateOfAdmissions)
            : base(firstName, lastName, fatherName, gender, grade, phoneNumber, address, email, bloodGroup, dateOfBirth, dateOfAdmissions)
        {
            GuardianName = guardianName;
        }
        
        // Getters and Setters of Student Class
        public string GuardianName
        {
            get => guardianName;
            set
            {
                if (value.Length > 1)
                    this.guardianName = value;
                else
                {
                    throw new ArgumentException("Guardian Name must be greater than 1 letter");
                }
            }
        }

        public void StoreStudent()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Store data in the Database
                    SqlCommand storeStudent = new
                    SqlCommand("INSERT INTO StudentTable VALUES (@FirstName, @LastName, @FatherName, @Gender, @Grade, @PhoneNumber, @Email, @BloodGroup, @Address, @GuardianName, @DateOfBirth, @DateOfAdmissions)", connection);
                    // command type
                    storeStudent.CommandType = CommandType.Text;
                    // placement
                    storeStudent.Parameters.AddWithValue("@FirstName", firstName);
                    storeStudent.Parameters.AddWithValue("@LastName", lastName);
                    storeStudent.Parameters.AddWithValue("@FatherName", fatherName);
                    storeStudent.Parameters.AddWithValue("@Gender", gender.ToString());
                    storeStudent.Parameters.AddWithValue("@Grade", grade);
                    storeStudent.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    storeStudent.Parameters.AddWithValue("@Email", email);
                    storeStudent.Parameters.AddWithValue("@BloodGroup", bloodGroup.ToString());
                    storeStudent.Parameters.AddWithValue("@Address", address);
                    storeStudent.Parameters.AddWithValue("@GuardianName", guardianName);
                    storeStudent.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    storeStudent.Parameters.AddWithValue("@DateOfAdmissions", dateOfAdmissions);

                    storeStudent.ExecuteNonQuery();
                    
                    connection.Close();
                }

                MessageBox.Show("Student Called \"" + 
                    firstName + " " + 
                    lastName + 
                    "\"Added in Students Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateStudent(int studentID)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Store data in the Database
                    SqlCommand updateStudent = new SqlCommand(
                        "UPDATE StudentTable SET " +
                        "FirstName = @FirstName, " +
                        "LastName = @LastName, " +
                        "FatherName = @FatherName, " +
                        "Gender = @Gender, " +
                        "Grade = @Grade, " +
                        "PhoneNumber = @PhoneNumber, " +
                        "Email = @Email, " +
                        "BloodGroup = @BloodGroup, " +
                        "Address = @Address, " +
                        "GuardianName = @GuardianName, " +
                        "DateOfBirth = @DateOfBirth, " +
                        "DateOfAdmissions = @DateOfAdmissions " +
                        "WHERE ID = @ID", connection);

                    // Command type
                    updateStudent.CommandType = CommandType.Text;

                    // Set parameters
                    updateStudent.Parameters.AddWithValue("@ID", studentID); // Provide the student's ID you want to update
                    updateStudent.Parameters.AddWithValue("@FirstName", firstName);
                    updateStudent.Parameters.AddWithValue("@LastName", lastName);
                    updateStudent.Parameters.AddWithValue("@FatherName", fatherName);
                    updateStudent.Parameters.AddWithValue("@Gender", gender.ToString());
                    updateStudent.Parameters.AddWithValue("@Grade", grade);
                    updateStudent.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    updateStudent.Parameters.AddWithValue("@Email", email);
                    updateStudent.Parameters.AddWithValue("@BloodGroup", bloodGroup.ToString());
                    updateStudent.Parameters.AddWithValue("@Address", address);
                    updateStudent.Parameters.AddWithValue("@GuardianName", guardianName);
                    updateStudent.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    updateStudent.Parameters.AddWithValue("@DateOfAdmissions", dateOfAdmissions);


                    updateStudent.ExecuteNonQuery();
                    connection.Close();
                }
                
                MessageBox.Show("Student with ID " + studentID + " updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

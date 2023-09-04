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


        // Constructors of Student
        public Student()
        {
        }

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
                // Store data in the Database
                SqlCommand storeStudent = new
                    SqlCommand("INSERT INTO StudentTable VALUES (@FirstName, @LastName, @FatherName, @Gender, @Grade, @PhoneNumber, @Email, @BloodGroup, @Address, @GuardianName, @DateOfBirth, @DateOfAdmissions)", con);
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



                con.Open();
                storeStudent.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

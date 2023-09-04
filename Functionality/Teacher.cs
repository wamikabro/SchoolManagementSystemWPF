using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SchoolManagementSystem.Functionality.Enums;

namespace SchoolManagementSystem.Functionality
{
    public class Teacher : Person
    {
        // Own Attributes
        private string subject;

        // Constructor
        public Teacher(string firstName, string lastName,
                string fatherName, Gender gender, int grade, string phoneNumber, string email,
                BloodType bloodGroup, string address, string subject, DateTime dateOfBirth, DateTime dateOfAdmissions)
            : base(firstName, lastName, fatherName, gender, grade, phoneNumber, address, email, bloodGroup, dateOfBirth, dateOfAdmissions)
        {
            Subject = subject;
        }

        // Getters and Setters of Items belonging to Teacher Class
        public string Subject { get => subject; 
            set
            {
                if (value.Length > 2)
                {
                    subject = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Subject");
                }

            } 
        }

        public void StoreTeacher()
        {
            try
            {
                // Store data in the Database
                SqlCommand storeTeacher = new
                    SqlCommand("INSERT INTO TeacherTable VALUES (@FirstName, @LastName, @FatherName, @Gender, @Grade, @PhoneNumber, @Email, @BloodGroup, @Address, @Subject, @DateOfBirth, @DateOfAdmissions)", con);
                // command type
                storeTeacher.CommandType = CommandType.Text;

                // placement
                storeTeacher.Parameters.AddWithValue("@FirstName", firstName);
                storeTeacher.Parameters.AddWithValue("@LastName", lastName);
                storeTeacher.Parameters.AddWithValue("@FatherName", fatherName);
                storeTeacher.Parameters.AddWithValue("@Gender", gender.ToString());
                storeTeacher.Parameters.AddWithValue("@Grade", grade);
                storeTeacher.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                storeTeacher.Parameters.AddWithValue("@Address", address);
                storeTeacher.Parameters.AddWithValue("@Email", email);
                storeTeacher.Parameters.AddWithValue("@BloodGroup", bloodGroup.ToString());
                storeTeacher.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                storeTeacher.Parameters.AddWithValue("@DateOfAdmissions", dateOfAdmissions);
                storeTeacher.Parameters.AddWithValue("@Subject", subject);



                con.Open();
                storeTeacher.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

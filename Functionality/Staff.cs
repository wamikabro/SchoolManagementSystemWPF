using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using SchoolManagementSystem.Functionality.Enums;

namespace SchoolManagementSystem.Functionality
{
    public class Staff : Person
    {
        // Own Attributes 
        private string jobTitle;

        // Sending data to the constructor of Person wihtout Grade 
        // and GuardianName Since Staff has nothing to do with Grade (Classes)
        // And we don't need to know their guardian
        public Staff(string firstName, string lastName,
                string fatherName, Gender gender, string phoneNumber, string email,
                BloodType bloodGroup, string address, string jobTitle, DateTime dateOfBirth, DateTime dateOfAdmissions)
            : base(firstName, lastName, fatherName, gender, phoneNumber, address, email, bloodGroup, dateOfBirth, dateOfAdmissions)
        {
            JobTitle = jobTitle;
        }

        // Getter Setter
        public string JobTitle { 
            get => jobTitle;
            set
            {
                if (value.Length > 2)
                {
                    jobTitle = value;
                }
                else
                {
                   throw new ArgumentException("Invalid Job Title");
                }
            }
        }

        public void StoreStaff()
        {
            try
            {
                using (SqlConnection connection = ((App)Application.Current).connection)
                {
                    connection.Open();

                    // Store data in the Database
                    SqlCommand storeStaff = new
                    SqlCommand("INSERT INTO StaffTable VALUES (@FirstName, @LastName, @FatherName, @Gender, @PhoneNumber, @Address ,@Email, @BloodGroup, @DateOfBirth, @DateOfAdmissions, @JobTitle)", connection);
                    // command type
                    storeStaff.CommandType = CommandType.Text;

                    // placement
                    storeStaff.Parameters.AddWithValue("@FirstName", firstName);
                    storeStaff.Parameters.AddWithValue("@LastName", lastName);
                    storeStaff.Parameters.AddWithValue("@FatherName", fatherName);
                    storeStaff.Parameters.AddWithValue("@Gender", gender.ToString());
                    storeStaff.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    storeStaff.Parameters.AddWithValue("@Address", address);
                    storeStaff.Parameters.AddWithValue("@Email", email);
                    storeStaff.Parameters.AddWithValue("@BloodGroup", bloodGroup.ToString());
                    storeStaff.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    storeStaff.Parameters.AddWithValue("@DateOfAdmissions", dateOfAdmissions);
                    storeStaff.Parameters.AddWithValue("@JobTitle", jobTitle);

                    storeStaff.ExecuteNonQuery();

                    connection.Close();
                }

                MessageBox.Show(jobTitle + " Called \"" +
               firstName + " " +
               lastName +
               "\"Added in Staff Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateStaff(int staffID)
        {
            try
            {
                using (SqlConnection connection = ((App)Application.Current).connection)
                {
                    connection.Open();

                    // Store data in the Database
                    SqlCommand updateStaff = new SqlCommand(
                    "UPDATE StaffTable SET " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "FatherName = @FatherName, " +
                    "Gender = @Gender, " +
                    "JobTitle = @JobTitle, " +
                    "PhoneNumber = @PhoneNumber, " +
                    "Email = @Email, " +
                    "BloodGroup = @BloodGroup, " +
                    "Address = @Address, " +
                    "DateOfBirth = @DateOfBirth, " +
                    "DateOfAdmissions = @DateOfAdmissions " +
                    "WHERE ID = @ID", connection);

                    // Command type
                    updateStaff.CommandType = CommandType.Text;

                    // Set parameters
                    updateStaff.Parameters.AddWithValue("@ID", staffID); // Provide the staff's ID you want to update
                    updateStaff.Parameters.AddWithValue("@FirstName", firstName);
                    updateStaff.Parameters.AddWithValue("@LastName", lastName);
                    updateStaff.Parameters.AddWithValue("@FatherName", fatherName);
                    updateStaff.Parameters.AddWithValue("@Gender", gender.ToString());
                    updateStaff.Parameters.AddWithValue("@JobTitle", jobTitle);
                    updateStaff.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    updateStaff.Parameters.AddWithValue("@Email", email);
                    updateStaff.Parameters.AddWithValue("@BloodGroup", bloodGroup.ToString());
                    updateStaff.Parameters.AddWithValue("@Address", address);
                    updateStaff.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    updateStaff.Parameters.AddWithValue("@DateOfAdmissions", dateOfAdmissions);

                    updateStaff.ExecuteNonQuery();

                    connection.Close();
                }    
                MessageBox.Show("Staff with ID " + staffID + " updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

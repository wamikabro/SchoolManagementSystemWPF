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
                // Store data in the Database
                SqlCommand storeStaff = new
                    SqlCommand("INSERT INTO StaffTable VALUES (@FirstName, @LastName, @FatherName, @Gender, @PhoneNumber, @Address ,@Email, @BloodGroup, @DateOfBirth, @DateOfAdmissions, @JobTitle)", con);
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


                con.Open();
                storeStaff.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(jobTitle + " Called \"" +
               firstName + " " +
               lastName +
               "\"Added in Staff Successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

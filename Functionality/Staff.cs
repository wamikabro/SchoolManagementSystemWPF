using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SchoolManagementSystem.Functionality.Enums;

namespace SchoolManagementSystem.Functionality
{
    public class Staff : Person
    {
        // Own Attributes 
        private string jobTitle;

        // Sending data to the constructor of Person wihtout Grade 
        // Since Staff has nothing to do with Grade (Classes) 
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
    }
}

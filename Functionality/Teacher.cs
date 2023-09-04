using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

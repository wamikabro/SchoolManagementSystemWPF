using SchoolManagementSystemFunctionality.Enums;
using System;

namespace SchoolManagementSystemFunctionality
{
    internal class Student : Person
    {
        private string guardianName;


        // Constructors of Student
        public Student()
        {
        }

        public Student(string firstName, string lastName,
                string fatherName, Gender gender, int grade, string phoneNumber, string email,
                BloodType bloodGroup,string address, string guardianName, DateTime dateOfBirth, DateTime dateOfAdmissions)
            : base(firstName, lastName, fatherName, gender, grade, phoneNumber, address, email, bloodGroup, dateOfBirth, dateOfAdmissions)
        {
            GuardianName = guardianName;
        }
        // Getters and Setters of Student Class
        public string GuardianName { get => guardianName; set => guardianName = value; }
    }
}

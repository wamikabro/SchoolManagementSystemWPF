using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Functionality.Enums;

namespace SchoolManagementSystem.Functionality
{
    abstract public class Person
    {
        // SQL Connection
        protected SqlConnection con;

        // All these values will be used by Student and Teacher Object
        protected string firstName;
        protected string lastName;
        protected string fatherName;
        protected Gender gender;
        protected string phoneNumber;
        protected string email;
        protected BloodType bloodGroup;
        protected string address;
        protected int grade;
        protected DateTime dateOfBirth;
        protected DateTime dateOfAdmissions;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length > 1)
                    this.firstName = value;
                else
                {
                    /*This setter is simply checking if the name is greater or not
                     if not then the exception will be thrown */
                    throw new ArgumentException("First Name must be greater than 1 letter");
                }
            }
        }

        // Getter and setter methods for lastName
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > 1)
                    this.lastName = value;
                else
                {
                    /*This setter is simply checking if the name is greater or not
                     if not then the exception will be thrown */
                    throw new ArgumentException("Last Name must be greater than 1 letter");
                }
            }
        }

        // Getter and setter methods for fatherName
        public string FatherName
        {
            get { return fatherName; }
            set
            {
                if (value.Length > 1)
                    this.fatherName = value;
                else
                {
                    /*This setter is simply checking if the name is greater or not
                     if not then the exception will be thrown */
                    throw new ArgumentException("Father Name must be greater than 1 letter");
                }
            }
        }

        // Gender Getter Setter
        Gender getGender()
        {
            return gender;
        }
        public void setGender(char value)
        {
            if (value.Equals('f') || value.Equals('F'))
            {
                gender = Gender.Female;
            }
            else if (value.Equals('m') || value.Equals('M'))
            {
                gender = Gender.Male;
            }
            else
            {
                throw new ArgumentException("The Gender is Invalid.");
            }
        }

        // Getter and setter methods for phoneNumber
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value.Length == 11 && value.StartsWith("03") ||
                    value.Length == 10 && value.StartsWith("3") ||
                    value.Length == 13 && value.StartsWith("+92"))
                {
                    this.phoneNumber = value;
                }
                else
                {
                    // This setter is simply checking if the number is valid or not
                    throw new ArgumentException("The Phone Number is invalid");
                }
            }
        }

        // Getter and setter methods for email
        public string Email
        {
            get { return email; }
            set
            {
                if (value.ToLower().EndsWith("@gmail.com") || value.ToLower().EndsWith("@hotmail.com") ||
                    value.ToLower().EndsWith("@icloud.com") ||
                    value.Equals(""))
                {
                    this.email = value;
                }
                else
                {
                    // Email invalid
                    throw new ArgumentException("The Email is invalid");
                }
            }
        }

        // BloodGroup Enum
        BloodType getBloodType()
        {
            return bloodGroup;
        }
        public void setBloodType(string value)
        {
            if (value.ToUpper().Equals("A+"))
                bloodGroup = BloodType.APositive;
            else if (value.ToUpper().Equals("A-"))
                bloodGroup = BloodType.ANegative;
            else if (value.ToUpper().Equals("B+"))
                bloodGroup = BloodType.BPositive;
            else if (value.ToUpper().Equals("B-"))
                bloodGroup = BloodType.BNegative;
            else if (value.ToUpper().Equals("AB+"))
                bloodGroup = BloodType.ABPositive;
            else if (value.ToUpper().Equals("AB-"))
                bloodGroup = BloodType.ABNegative;
            else if (value.ToUpper().Equals("O+"))
                bloodGroup = BloodType.OPositive;
            else if (value.ToUpper().Equals("O-"))
                bloodGroup = BloodType.ONegative;
            else
                throw new ArgumentException("Invalid Blood Group.");
        }

        // Address Getter Setter 
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // Grade Getter Setter
        public int Grade
        {
            get => grade;
            set
            {
                // If the grade is between 1 to 12
                if (value >= 1 && value <= 12)
                    grade = value;
                else
                    throw new ArgumentException("Invalid Grade. It should be in between 1 to 12.");
            }
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                // If the age is 18 or almost 18 
                if (DateTime.Now.Year - value.Year >= 3 && DateTime.Now.Year - value.Year <= 60)
                    dateOfBirth = value;

                else
                    throw new ArgumentException("Age is either too long or too short.");
            }

        }

        public DateTime DateOfAdmissions
        {
            get => dateOfAdmissions;
            set => dateOfAdmissions = value;
        }

        /* Normally during submitting the data, it will be checked if the 
            data given is filled, otherwise the exception will be thrown
            so default constructor will never be called*/

        // This constructor is needed to empty Children Teacher, Student can be created
        public Person()
        {
        }

        // For those who has nohing to do with grades (classes) eg. Staff
        public Person(string firstName, string lastName, string fatherName, Gender gender, string phoneNumber, string address, string email, BloodType bloodGroup, DateTime dateOfBirth, DateTime dateOfAdmissions)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            this.gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            this.bloodGroup = bloodGroup;
            DateOfBirth = dateOfBirth;
            DateOfAdmissions = dateOfAdmissions;
        }
        /* // Other Constructors
        
                // In case the person got admission on mandatory information only
                public Person(string firstName, string lastName, string fatherName, Gender gender, int grade, string phoneNumber)
                {
                    FirstName = firstName;
                    LastName = lastName;
                    FatherName = fatherName;
                    this.gender = gender;
                    Grade = grade;
                    PhoneNumber = phoneNumber;
                    Identity = Identity++;
                }
                // In case email and bloodGroup are missing
                public Person(string firstName, string lastName, string fatherName, Gender gender, int grade, string phoneNumber, string address)
                {
                    FirstName = firstName;
                    LastName = lastName;
                    FatherName = fatherName;
                    this.gender = gender;
                    Grade = grade;
                    PhoneNumber = phoneNumber;
                    Address = address;
                    Identity = Identity++;
                }
                // In case bloodGroup is missing
                public Person(string firstName, string lastName, string fatherName, Gender gender, int grade, string phoneNumber, string address, string email)
                {
                    FirstName = firstName;
                    LastName = lastName;
                    FatherName = fatherName;
                    this.gender = gender;
                    Grade = grade;
                    PhoneNumber = phoneNumber;
                    Address = address;
                    Email = email;
                    Identity = Identity++;
                }*/

        // In case full information was given
        public Person(string firstName, string lastName, string fatherName, Gender gender, int grade, string phoneNumber, string address, string email, BloodType bloodGroup, DateTime dateOfBirth, DateTime dateOfAdmissions)
        {
            con = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            this.gender = gender;
            Grade = grade;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            this.bloodGroup = bloodGroup;
            DateOfBirth = dateOfBirth;
            DateOfAdmissions = dateOfAdmissions;
        }
    }
}


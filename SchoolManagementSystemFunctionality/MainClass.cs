using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SchoolManagementSystemFunctionality
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // Database
            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>();
            List<Staff> staff = new List<Staff>();

            AddInDatabase(teachers, students, staff);
            
        }


        static void AddInDatabase(List<Teacher> teachers, List<Student> students, List<Staff> staffs)
        {
            // Keep restarting the program until
            int choice;
            do
            {
                // Show options to the User and Take Input
                Console.Write("Choose an Option\n1. Add Teacher\n2. Add Student\n3. Add Staff\n4. Show Teachers\n5. Show Students\n6. Show Staff\n7. Exit\n> ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Teacher teacher = new Teacher();

                    FirstNameLabel:
                    try
                    {
                        Console.Write("Add First Name: ");
                        teacher.FirstName = Console.ReadLine();
                    }
                    catch(ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message,ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto FirstNameLabel;
                    }


                    LastNameLabel:
                    try
                    {
                        Console.Write("Add Last Name: ");
                        teacher.LastName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto LastNameLabel;
                    }

                    FatherNameLabel:
                    try
                    {
                        Console.Write("Add Father Name: ");
                        teacher.FatherName = Console.ReadLine();
                    }
                    catch(ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto FatherNameLabel;
                    }

                    

                    GenderLabel:
                    try
                    {
                        Console.Write("Add Gender (m = Male, f = Female): ");

                        try
                        {
                            teacher.setGender(Convert.ToChar(Console.ReadLine()));
                        
                        }catch (FormatException)
                        {
                            MessageBox.Show("Just Type 1 Character", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto GenderLabel;
                        }
                        
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GenderLabel;
                    }



                    GradeLabel:
                    try
                    {
                        Console.Write("Add Grade: ");
                        teacher.Grade = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GradeLabel;
                    }

                    NumberLabel:
                    try
                    {
                        Console.Write("Add Number: ");
                        teacher.PhoneNumber = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto NumberLabel;
                    }


                    EmailLabel:
                    try
                    {
                        Console.Write("Add Email: ");
                        teacher.Email = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto EmailLabel;
                    }
                    

                    // Taking Blood Group Input
                    BloodGroupLabel:
                    try
                    {
                        Console.Write("Add Blood Type (A+, A-, B+, B-, AB+, AB-, O+, O-): ");
                        teacher.setBloodType(Console.ReadLine());
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto BloodGroupLabel;
                    }

                    AddressLabel:
                    try
                    {
                        Console.Write("Add Address: ");
                        teacher.Address = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto AddressLabel;
                    }

                    SubjectLabel:
                    try
                    {
                        Console.Write("Add Subject: ");
                        teacher.Subject = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto SubjectLabel;
                    }

                    DateOfBirthLabel:
                    try
                    {
                        Console.Write("Date Of Birth 'dd/MM/yyyy': ");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                        {
                            teacher.DateOfBirth = dateOfBirth;
                        }
                        else
                        {
                            // If the issue occurs in the prefered age, then the exception is thrown by the Person class itself
                            // But here it Throws new exception and send it to catch clause but with this issue.
                            throw new ArgumentException("Write in this format dd/MM/yyyy eg. 06/09/2003");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto DateOfBirthLabel;
                    }

                    DateOfAdmissionsLabel:
                    try
                    {
                        Console.Write("Date Of Admission 'dd/MM/yyyy': ");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfAdmissions))
                        {
                            teacher.DateOfAdmissions = dateOfAdmissions;
                        }
                        else
                        {
                            // If the issue occurs in something else, then the exception is thrown by the Person class itself
                            // But here it Throws new exception and send it to catch clause but with this issue.
                            throw new ArgumentException("Write in this format dd/MM/yyyy eg. 06/09/2003");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto DateOfAdmissionsLabel;
                    }

                    // Adding Newly Made teacher into List/Database of Teachers
                    teachers.Add(teacher);

                }
                else if (choice == 2)
                {
                    Student student = new Student();

                    FirstNameLabel:
                    try
                    {
                        Console.Write("Add First Name: ");
                        student.FirstName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto FirstNameLabel;
                    }


                    LastNameLabel:
                    try
                    {
                        Console.Write("Add Last Name: ");
                        student.LastName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto LastNameLabel;
                    }

                    FatherNameLabel:
                    try
                    {
                        Console.Write("Add Father Name: ");
                        student.FatherName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto FatherNameLabel;
                    }

                    GenderLabel:
                    try
                    {
                        Console.Write("Add Gender (m = Male, f = Female): ");

                        try
                        {
                            student.setGender(Convert.ToChar(Console.ReadLine()));

                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Just Type 1 Character", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto GenderLabel;
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GenderLabel;
                    }

                    GradeLabel:
                    try
                    {
                        Console.Write("Add Grade: ");
                        student.Grade = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GradeLabel;
                    }

                    NumberLabel:
                    try
                    {
                        Console.Write("Add Number: ");
                        student.PhoneNumber = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto NumberLabel;
                    }


                    EmailLabel:
                    try
                    {
                        Console.Write("Add Email: ");
                        student.Email = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto EmailLabel;
                    }

                    // Taking Blood Group Input
                    BloodGroupLabel:
                    try
                    {
                        Console.Write("Add Blood Type (A+, A-, B+, B-, AB+, AB-, O+, O-): ");
                        student.setBloodType(Console.ReadLine());
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto BloodGroupLabel;
                    }

                    AddressLabel:
                    try
                    {
                        Console.Write("Add Address: ");
                        student.Address = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto AddressLabel;
                    }

                    GuardianNameLabel:
                    try
                    {
                        Console.Write("Add Guardian Name: ");
                        student.Address = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GuardianNameLabel;
                    }

                    DateOfBirthLabel:
                    try
                    {
                        Console.Write("Date Of Birth 'dd/MM/yyyy': ");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                        {
                            student.DateOfBirth = dateOfBirth;
                        }
                        else
                        {
                            // If the issue occurs in something else, then the exception is thrown by the Person class itself
                            // But here it Throws new exception and send it to catch clause but with this issue.
                            throw new ArgumentException("Write in this format dd/MM/yyyy eg. 06/09/2003");
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto DateOfBirthLabel;
                    }

                    DateOfAdmissionsLabel:
                    try
                    {
                        Console.Write("Date Of Admission 'dd/MM/yyyy': ");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfAdmissions))
                        {
                            student.DateOfAdmissions = dateOfAdmissions;
                        }
                        else
                        {
                            // If the issue occurs in something else, then the exception is thrown by the Person class itself
                            // But here it Throws new exception and send it to catch clause but with this issue.
                            throw new ArgumentException("Write in this format dd/MM/yyyy eg. 06/09/2003");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto DateOfAdmissionsLabel;
                    }


                    // Adding Newly Made student into List/Database of Teachers
                    students.Add(student);
                }
                else if (choice == 3)
                {
                    Staff staff = new Staff();

                    FirstNameLabel:
                    try
                    {
                        Console.Write("Add First Name: ");
                        staff.FirstName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto FirstNameLabel;
                    }


                    LastNameLabel:
                    try
                    {
                        Console.Write("Add Last Name: ");
                        staff.LastName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto LastNameLabel;
                    }

                    FatherNameLabel:
                    try
                    {
                        Console.Write("Add Father Name: ");
                        staff.FatherName = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto FatherNameLabel;
                    }

                    GenderLabel:
                    try
                    {
                        Console.Write("Add Gender (m = Male, f = Female): ");

                        try
                        {
                            staff.setGender(Convert.ToChar(Console.ReadLine()));

                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Just Type 1 Character", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto GenderLabel;
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GenderLabel;
                    }

                    NumberLabel:
                    try
                    {
                        Console.Write("Add Number: ");
                        staff.PhoneNumber = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto NumberLabel;
                    }


                    EmailLabel:
                    try
                    {
                        Console.Write("Add Email: ");
                        staff.Email = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto EmailLabel;
                    }

                    // Taking Blood Group Input
                    BloodGroupLabel:
                    try
                    {
                        Console.Write("Add Blood Type (A+, A-, B+, B-, AB+, AB-, O+, O-): ");
                        staff.setBloodType(Console.ReadLine());
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto BloodGroupLabel;
                    }

                    AddressLabel:
                    try
                    {
                        Console.Write("Add Address: ");
                        staff.Address = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto AddressLabel;
                    }

                    GuardianNameLabel:
                    try
                    {
                        Console.Write("Add Guardian Name: ");
                        staff.Address = Console.ReadLine();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto GuardianNameLabel;
                    }

                    DateOfBirthLabel:
                    try
                    {
                        Console.Write("Date Of Birth 'dd/MM/yyyy': ");
                        string input = Console.ReadLine();

                        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                        {
                            staff.DateOfBirth = dateOfBirth;
                        }
                        else
                        {
                            // Handle invalid input or display an error message
                            MessageBox.Show("Write in this format dd/MM/yyyy eg. 06/09/2003", "Wrong Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto DateOfBirthLabel;
                        }

                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ParamName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto DateOfBirthLabel;
                    }


                    // Adding Newly Made teacher into List/Database of Teachers
                    staffs.Add(staff);
                }
                else if(choice == 4)
                {
                    int counter = 1;
                    foreach(Teacher teacher in teachers)
                    {
                        Console.WriteLine(counter + ". First Name: " + teacher.FirstName + " " + teacher.LastName);
                        counter++;
                    }
                }
                else if (choice == 5)
                {
                    int counter = 1;
                    foreach (Student student in students)
                    {
                        Console.WriteLine(counter + ". Name: " + student.FirstName + " " + student.LastName);
                        counter++;
                    }
                }
                else if (choice == 6)
                {
                    int counter = 1;
                    foreach (Staff staff in staffs)
                    {
                        Console.WriteLine(counter + ". Name: " + staff.FirstName + " " + staff.LastName);
                        counter++;
                    }
                }
                else if (choice == 7)
                    Console.WriteLine("ThankYou For Using Our Services. See You!");
                else
                    Console.WriteLine("Invalid Option.");

            } while (choice != 7);
        }
    }
}

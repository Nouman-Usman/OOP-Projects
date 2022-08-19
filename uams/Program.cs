using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;
using uams.UI;

namespace uams
{
    public class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            if (SubjectDL.readFromFile(subjectPath))
            {
                Console.WriteLine("Subject Data Loaded Successfully");
            }
            if (DegreeProgramDL.readFromFile(degreePath))
            {
                Console.WriteLine("DegreeProgram Data Loaded Successfully");
            }
            if (StudentDL.readFromFile(studentPath))
            {
                Console.WriteLine("Student Data Loaded Successfully");
            }
            MiscUL.clearScreen();
            while (true) 
            {
                int option = MiscUL.Menu();
                MiscUL.clearScreen();
                if (option == 1)
                {
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Student newStudent = StudentUL.takeInputForStudent();
                        StudentDL.setIntoStudentList(newStudent);
                        StudentDL.storeintoFile(studentPath, newStudent);
                    }

                }
                else if (option == 2)
                {
                    DegreeProgram newDegreeProgram = DegreeProgramUL.takeInputForDegree(subjectPath);
                    DegreeProgramDL.setIntoDegreeList(newDegreeProgram);
                    DegreeProgramDL.storeintoFile(degreePath, newDegreeProgram);
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUL.printStudents();
                }
                else if (option == 4)
                {
                    StudentUL.viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    string degreeName;
                    Console.Write("Enter Degree Name: ");
                    degreeName = Console.ReadLine();
                    StudentUL.viewStudentInDegree(degreeName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student registerStudent = StudentDL.studentPresent(name);
                    if (registerStudent != null)
                    {
                        SubjectUL.viewSubjects(registerStudent);
                        SubjectUL.registerSubjects(registerStudent);
                    }
                 
                }
                else if (option == 7)
                {
                    StudentUL.calculateFeeForAll();
                }
                else if(option == 8)
                {
                  Environment.Exit(0);
                }
                MiscUL.clearScreen();

            }

        }
    }
}

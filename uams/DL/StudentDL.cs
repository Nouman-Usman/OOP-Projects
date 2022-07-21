using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using System.IO;

namespace uams.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();

        public static void setIntoStudentList(Student s)
        {
            studentList.Add(s);
        }

        public static Student studentPresent(string name)
        {
            foreach (Student registerStudent in studentList)
            {
                if (name == registerStudent.getName() && registerStudent.regDegree != null)
                {
                    return registerStudent;
                }
            }
            return null;
        }

        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach (Student s in studentList)
            {
                s.calculateMerit();

            }
            sortedStudentList = studentList.OrderByDescending(o => o.getMerit()).ToList();
            return sortedStudentList;
        }

        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.preferences)
                {
                    if (d.getSeat() > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        int seats = d.getSeat();
                        seats--;
                        d.setSeats(seats);
                        break;
                        
                    }
                }
            }
        }
        public static void storeintoFile(string path, Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for(int x = 0; x < s.preferences.Count - 1; x++)
            {
                degreeNames = degreeNames + s.preferences[x].getDegreeName() + ";";
            }
            degreeNames = degreeNames + s.preferences[s.preferences.Count - 1].getDegreeName();
            f.WriteLine(s.getName() + "," + s.getAge() + "," + s.getFSCMarks() + "," + s.getECATMarks() + "," + degreeNames);
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double fscMarks = double.Parse(splittedRecord[2]);
                    double ecatMarks = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();

                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d = DegreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                    }
                    Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

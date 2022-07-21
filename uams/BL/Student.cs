using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class Student
    {
        private string name;
        private int age;
        private double fscMarks;
        private double ecatMarks;
        private double merit;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubject;
        public DegreeProgram regDegree;
        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubject = new List<Subject>();
            
        }
        public string getName() 
        {
            return name;
        }
        public int getAge()
        {
            return age;
        }
        public double getFSCMarks()
        {
            return fscMarks;
        }
        public double getECATMarks()
        {
            return ecatMarks;
        }
        public double getMerit()
        {
            return merit;
        }
        public void calculateMerit()
        {
            merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F)) * 100;
         
        }
        public bool regStudentSubject(Subject s)
        {
            int studentCreditHour = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExist(s) && studentCreditHour + s.getCreditHours() <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public int getCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regSubject)
            {
                count = count + sub.getCreditHours();
            }
            return count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regSubject)
                {
                    fee += sub.getSubjectFees();
                }
            }
            return fee;
        }

        
    }
}

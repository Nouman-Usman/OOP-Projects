using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class DegreeProgram
    {
        private string degreeName;
        private float degreeDuration;
        public List<Subject> subjects;
        private int seats;
        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public string getDegreeName()
        {
            return degreeName;
        }
        public float getDegreeDuration()
        {
            return degreeDuration;
        }
        public int getSeat()
        {
            return seats;
        }
        public void setSeats(int seats)
        {
            this.seats = seats;
        }

        public bool isSubjectExist(Subject sub)
        {
            foreach (Subject s in subjects)
            {
                if (s.getCode() == sub.getCode())
                {
                    return true;
                }
            }
            return false;
        }
        public bool addSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if(creditHours + s.getCreditHours() <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int calculateCreditHours()
        {
            int count = 0;
            for (int x = 0; x < subjects.Count; x++)
            {
                count += subjects[x].getCreditHours();
            }
            return count;
        }
    }
}

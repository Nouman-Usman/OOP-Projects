using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    class DegreeProgramUL
    {
        public static DegreeProgram takeInputForDegree(string subjectPath)
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.Write("Enter Degree Name: ");
            degreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            degreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            seats = int.Parse(Console.ReadLine());
            Console.Write("How many Subjects to Enter? ");
            int count = int.Parse(Console.ReadLine());
            DegreeProgram newDegreePrgram = new DegreeProgram(degreeName, degreeDuration, seats);
            for (int x = 0; x < count; x++)
            {
                Subject newSubject = SubjectUL.takeInputForSubject();
                if (newDegreePrgram.addSubject(newSubject))
                {
                    if (!(SubjectDL.subjectList.Contains(newSubject)))
                    {
                        SubjectDL.setSubjectIntoList(newSubject);
                        SubjectDL.storeintoFile(subjectPath, newSubject);
                    }
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    x--;
                }
            }
            return newDegreePrgram;

        }
        public static void viewDegreePrograms()
        {
            foreach (DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.getDegreeName());
            }
        }
    }
}

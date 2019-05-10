using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool isWeighted) : base(name,isWeighted)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            float count = Students.Count;
            float above = 0;

            if (count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            foreach (Student student in Students)
            {
                above += (student.AverageGrade > averageGrade) ? 1 : 0;                
            }
           
            int gradePercentileGroup =(int) Math.Floor(above * 5 / count);        
            
            switch (gradePercentileGroup)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
            }
            return 'F';
        }
    }
}

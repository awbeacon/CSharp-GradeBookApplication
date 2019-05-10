using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            base.Type = Enums.GradeBookType.Ranked;
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

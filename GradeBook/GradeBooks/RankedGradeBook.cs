using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var sortedStudents = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            var twentyPercentIndex = (int) Math.Round(0.2 * Students.Count);
            var fortyPercentIndex = (int) Math.Round(0.4 * Students.Count);
            var sixtyPercentIndex = (int) Math.Round(0.6 * Students.Count);
            var eightyPercentIndex = (int) Math.Round(0.8 * Students.Count);

            if (averageGrade > sortedStudents[twentyPercentIndex])
                return 'A';
            else if (averageGrade > sortedStudents[fortyPercentIndex])
                return 'B';
            else if (averageGrade > sortedStudents[sixtyPercentIndex])
                return 'C';
            else if (averageGrade > sortedStudents[eightyPercentIndex])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
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
    }
}

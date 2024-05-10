namespace StudentManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentManager
    {
        private readonly List<Student> list = new List<Student>();

        private int GenerateId()
        {
            var max = 1;

            if (this.list == null || this.list.Count <= 0) return max;
            max = this.list[0].Id;
            max = this.list.Select(sv => sv.Id).Concat(new[] { max }).Max();
            max++;

            return max;
        }

        public void AddStudent()
        {
            var student = new Student
            {
                Id             = this.GenerateId(),
                Name           = Validation.GetString("Name: ", "Try again!!!"),
                Sex            = Validation.GetBool("Sex: ", "Try again!!!"),
                Age            = Validation.GetInt("Age: ", "Try again from 18 to 26!!!", "", 18, 26),
                MathScore      = Validation.GetDouble("Math: ", "Try again from 0 -> 10!!!", 0, 10),
                PhysicalScore  = Validation.GetDouble("Physical: ", "Try again from 0 -> 10!!!", 0, 10),
                ChemistryScore = Validation.GetDouble("Chemistry: ", "Try again from 0 -> 10!!!", 0, 10),
            };
            this.Medium(student);
            this.AcademicPerformance(student);
            this.list.Add(student);
        }

        private void AcademicPerformance(Student sv)
        {
            sv.Performance = sv.MediumScore >= 8 ? "Excellent" :
                sv.MediumScore >= 6.5            ? "Good" :
                sv.MediumScore >= 5              ? "Mid" :
                                                   "Poor";
        }

        private void Medium(Student sv)
        {
            var medium = (sv.MathScore + sv.PhysicalScore + sv.ChemistryScore) / 3;
            sv.MediumScore = Math.Round(medium, 2, MidpointRounding.AwayFromZero);
        }

        public void ShowStudent()
        {
            if (this.list?.Count > 0)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,5} {4,5} {5,5} {6,5} {7,10} {8,10}",
                    "ID", "Name", "Sex", "Age", "Math", "Physical", "Chemistry", "Medium", "Performance");

                foreach (var student in this.list)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,5} {4,5} {5,5} {6,5} {7,10} {8,10}",
                        student.Id, student.Name, student.Sex, student.Age, student.MathScore,
                        student.PhysicalScore, student.ChemistryScore, student.MediumScore, student.Performance);
                }
            }
            else
            {
                Console.WriteLine("List is empty!!!");
            }
        }
    }
}
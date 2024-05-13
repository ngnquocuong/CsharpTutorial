namespace StudentManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentManager
    {
        public StudentManager()
        {
            this.list.Add(new Student
            {
                Id             = this.GenerateId(),
                Name           = "John Doe",
                Sex            = true, // Male
                Age            = 20,
                MathScore      = 8.5,
                PhysicalScore  = 7.0,
                ChemistryScore = 9.0
            });

            this.list.Add(new Student
            {
                Id             = this.GenerateId(),
                Name           = "Jane Doe",
                Sex            = false, // Female
                Age            = 21,
                MathScore      = 7.0,
                PhysicalScore  = 8.0,
                ChemistryScore = 8.5
            });

            this.list.Add(new Student
            {
                Id             = this.GenerateId(),
                Name           = "Alex Smith",
                Sex            = true, // Male
                Age            = 19,
                MathScore      = 9.0,
                PhysicalScore  = 8.5,
                ChemistryScore = 7.0
            });

            this.list.Add(new Student
            {
                Id             = this.GenerateId(),
                Name           = "Emily Johnson",
                Sex            = false, // Female
                Age            = 22,
                MathScore      = 6.5,
                PhysicalScore  = 7.5,
                ChemistryScore = 8.0
            });

            this.list.Add(new Student
            {
                Id             = this.GenerateId(),
                Name           = "Michael Brown",
                Sex            = true, // Male
                Age            = 20,
                MathScore      = 8.0,
                PhysicalScore  = 9.0,
                ChemistryScore = 8.5,
            });

            // Calculate MediumScore and AcademicPerformance for each student
            foreach (var student in this.list)
            {
                this.Medium(student);
                this.AcademicPerformance(student);
            }
        }

        private readonly List<Student> list = new List<Student>();

        private int GenerateId() => this.list.Count > 0 ? this.list.Max(sv => sv.Id) + 1 : 1;

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
            Console.WriteLine("Add student successfully!!!");
        }

        public void UpdateStudent()
        {
            this.CheckNullStudent("List is empty to update!!!");

            Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,5} {4,5} {5,5} {6,5} {7,10} {8,10}", "ID", "Name", "Sex", "Age", "Math", "Physical", "Chemistry", "Medium", "Performance");

            this.ShowListStudent();

            var newId           = Validation.GetInt("Student ID to update: ", "Try again!!!", "", 1, list.Count);
            var studentToUpdate = this.list.FirstOrDefault(student => student.Id == newId);

            if (studentToUpdate == null)
            {
                Console.WriteLine("Student with the provided ID does not exist!");

                return;
            }

            Console.WriteLine("Enter new information:");
            studentToUpdate.Name           = Validation.GetString("New name: ", "Try again!!!");
            studentToUpdate.Sex            = Validation.GetBool("New sex (True for Male, False for Female): ", "Try again!!!");
            studentToUpdate.Age            = Validation.GetInt("New age: ", "Try again!!!", "", 18, 26);
            studentToUpdate.MathScore      = Validation.GetDouble("New math score: ", "Try again!!!", 0, 10);
            studentToUpdate.PhysicalScore  = Validation.GetDouble("New physical score: ", "Try again!!!", 0, 10);
            studentToUpdate.ChemistryScore = Validation.GetDouble("New chemistry score: ", "Try again!!!", 0, 10);

            Console.WriteLine($"Updated student information:\n{studentToUpdate.Id,-5} {studentToUpdate.Name,-20} {studentToUpdate.Sex,-5} {studentToUpdate.Age,5} {studentToUpdate.MathScore,5} {studentToUpdate.PhysicalScore,5} {studentToUpdate.ChemistryScore,5} {studentToUpdate.MediumScore,10} {studentToUpdate.Performance,10}");
            Console.WriteLine("Update successfully!!!");
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

        public void ShowListStudent()
        {
            this.CheckNullStudent("List is empty!!!");

            Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,5} {4,5} {5,5} {6,5} {7,10} {8,10}",
                "ID", "Name", "Sex", "Age", "Math", "Physical", "Chemistry", "Medium", "Performance");

            foreach (var student in this.list)
            {
                Console.WriteLine($"{student.Id,-5} {student.Name,-20} {student.Sex,-5} " + $"{student.Age,5} {student.MathScore,5} {student.PhysicalScore,5} " + $"{student.ChemistryScore,5} {student.MediumScore,10} {student.Performance,10}");
            }
        }

        public void DeleteStudent()
        {
            this.CheckNullStudent("List is empty!!!");
            this.ShowListStudent();
            var id              = Validation.GetInt("Choose student ID to delete: ", $"Please input a number from 1 to {this.list.Count}!!!", "", 1, this.list.Count);
            var studentToRemove = this.list.FirstOrDefault(student => student.Id == id);
            var message         = studentToRemove != null ? $"Student with ID {id} has been deleted." : $"Student with ID {id} does not exist.";
            this.list.Remove(studentToRemove);
            Console.WriteLine(message);
            this.ShowListStudent();
            Console.WriteLine("Delete successfully!!!");
        }

        public void SearchStudentByName()
        {
            this.CheckNullStudent("No student to search!!!");

            var name  = Validation.GetString("Search student name: ", "Try again!!!");
            var found = false;
            foreach (var student in this.list)
            {
                if (student.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) < 0) continue;
                Console.WriteLine($"{student.Id,-5} {student.Name,-20} {student.Sex,-5} " + $"{student.Age,5} {student.MathScore,5} {student.PhysicalScore,5} " + $"{student.ChemistryScore,5} {student.MediumScore,10} {student.Performance,10}");
                found = true;
            }

            if (!found)
            {
                Console.WriteLine($"No student found with the name '{name}'.");
            }
        }

        private void CheckNullStudent(string mess)
        {
            if (this.list.Count != 0) return;
            Console.WriteLine(mess);
        }

        public void SortStudentByName()
        {
            this.CheckNullStudent("No student to sort!!!");
            this.list.Sort((student, student1) => String.Compare(student.Performance, student1.Performance, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Students sorted by name:");
            this.ShowListStudent();
        }

        public void SortStudentByGPA()
        {
            this.CheckNullStudent("No student to sort!!!");

            this.list.Sort((student1, student2) => student1.MediumScore.CompareTo(student2.MediumScore));

            Console.WriteLine("Students sorted by GPA:");
            this.ShowListStudent();
        }

        public void SortStudentById()
        {
            this.CheckNullStudent("No student to sort!!!");

            this.list.Sort((student1, student2) => student1.Id.CompareTo(student2.Id));

            Console.WriteLine("Students sorted by ID:");
            this.ShowListStudent();
        }
    }
}
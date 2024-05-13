namespace StudentManager
{
    using System;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var manager = new StudentManager();
            while (true)
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY SINH VIEN C#");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Add student.                                  **");
                Console.WriteLine("**  2. Update student by ID.                         **");
                Console.WriteLine("**  3. Delete student by ID.                         **");
                Console.WriteLine("**  4. Search student by name.                       **");
                Console.WriteLine("**  5. Sort student by grade( GPA).                  **");
                Console.WriteLine("**  6. Sort student by name.                         **");
                Console.WriteLine("**  7. Sort student by ID.                           **");
                Console.WriteLine("**  8. Show student list.                            **");
                Console.WriteLine("**  0. Exit                                          **");
                Console.WriteLine("*******************************************************");
                switch (Validation.GetInt("Choose 0 to 8: ", "Choose an integer from 0 to 8 ", "Try again!!!", 0, 8))
                {
                    case 1:
                        manager.AddStudent();

                        break;
                    case 2:
                        manager.UpdateStudent();

                        break;
                    case 3:
                        manager.DeleteStudent();

                        break;
                    case 4:
                        manager.SearchStudentByName();

                        break;
                    case 5:
                        manager.SortStudentByGPA();

                        break;
                    case 6:
                        manager.SortStudentByName();

                        break;
                    case 7:
                        manager.SortStudentById();

                        break;
                    case 8:
                        manager.ShowListStudent();

                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}
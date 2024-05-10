namespace StudentManager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var manager = new StudentManager();
            while (true)
                switch (Validation.GetInt("Choose 1 to 9: ", "Choose an integer from 1 to 8 ", "Try again!!!", 1, 9))
                {
                    case 1:
                        manager.AddStudent();

                        break;
                    case 2:
                    case 3:
                        manager.DeleteStudent();

                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        manager.ShowStudent();

                        break;
                    case 9:
                        return;
                }
        }
    }
}
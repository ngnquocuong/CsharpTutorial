namespace StudentManager
{
    using System;

    public static class Validation
    {
        public static int GetInt(string messageInfo, string messageErrorOutOfRange, string messageErrorInvalidNumber, int min, int max)
        {
            if (min > max) throw new ArgumentException("Min must be less than or equal to max.");
            while (true)
            {
                Console.Write(messageInfo);
                if (int.TryParse(Console.ReadLine(), out var number) && number >= min && number <= max)
                {
                    return number;
                }
                Console.WriteLine(number < min || number > max ? messageErrorOutOfRange : messageErrorInvalidNumber);
            }
        }

        public static string GetString(string messageInfo, string messageError)
        {
            while (true)
            {
                Console.Write(messageInfo);
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine(messageError);
            }
        }

        public static double GetDouble(string messageInfo, string messageError, double min, double max)
        {
            if (min > max) throw new ArgumentException("Min must be less than or equal to max.");

            while (true)
            {
                Console.Write(messageInfo);
                if (double.TryParse(Console.ReadLine(), out var number) && number >= min && number <= max)
                {
                    return number;
                }
                Console.WriteLine("Input must be a valid double between {0} and {1}.", min, max);
            }
        }

        public static bool GetBool(string messageInfo, string messageError)
        {
            while (true)
            {
                Console.Write(messageInfo);
                var input = Console.ReadLine();
                if (input?.ToLower() == "true" || input?.ToLower() == "false")
                {
                    return bool.Parse(input);
                }
                Console.WriteLine(messageError);
            }
        }
    }
}
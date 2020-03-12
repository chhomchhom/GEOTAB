using System;

namespace ConsoleApp1
{
    class Program
    {
        static string[] results = new string[50];
        static char key;
        static Tuple<string, string> names;
        static ConsolePrinter printer = new ConsolePrinter();
        static readonly string INSTRUCTION_MESSAGE = "Press ? to get instructions.";
        static readonly string GET_CATEGORIES_MESSAGE = "Press c to get categories";
        static readonly string GET_RANDOM_JOKES_MESSAGE = "Press r to get random jokes";
        static readonly string RANDOM_NAME_MESSAGE = "\nWant to use a random name? y/n";
        static readonly string SPECIFY_CATEGORY_MESSAGE = "\nWant to specify a category? y/n";
        static readonly string AMOUNT_OF_JOKES_MESSAGE = "\nHow many jokes do you want? (1-9)";
        static readonly string ENTER_CATEGORY_MESSAGE = "Enter a category;";
        static readonly string QUIT_INSTRUCTION = "Press q to quit program";
        static readonly string PROGRAM_DONE_MESSAGE = "\nProgram shutdown";

        static void Main(string[] args)
        {
            printer.Value(INSTRUCTION_MESSAGE).ToString();
            new JsonFeed();
            if (Console.ReadLine() == "?")
            {
                while (key != 'q')
                {
                    printer.Value(GET_CATEGORIES_MESSAGE).ToString();
                    printer.Value(GET_RANDOM_JOKES_MESSAGE).ToString();
                    printer.Value(QUIT_INSTRUCTION).ToString();
                    GetEnteredKey(Console.ReadKey());
                    if (key == 'c')
                    {
                        getCategories();
                        PrintResults();
                    }
                    if (key == 'r')
                    {
                        printer.Value(RANDOM_NAME_MESSAGE).ToString();
                        GetEnteredKey(Console.ReadKey());
                        if (key == 'y')
                            GetNames();
                        printer.Value(SPECIFY_CATEGORY_MESSAGE).ToString();
                        GetEnteredKey(Console.ReadKey());
                        HowManyJokes();
                    }
                    names = null;
                }
                printer.Value(PROGRAM_DONE_MESSAGE).ToString();
            }
        }

        private static void HowManyJokes()
        {
            printer.Value(AMOUNT_OF_JOKES_MESSAGE).ToString();
            int numberOfJokes = Int32.Parse(Console.ReadLine());
            string category = null;
            if (key == 'y')
            {
                printer.Value(ENTER_CATEGORY_MESSAGE).ToString();
                category = Console.ReadLine();
            }
            for (int i = 0; i < numberOfJokes; i++)
            {
                GetRandomJokes(category);
                PrintResults();
            }
        }

        private static void PrintResults()
        {
            printer.Value("[" + string.Join(",", results) + "]").ToString();
        }

        private static void GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
                case ConsoleKey.N:
                    key = 'n';
                    break;
                case ConsoleKey.Q:
                    key = 'q';
                    break;
            }
        }

        private static void GetRandomJokes(string category)
        {
            new JsonFeed();
            results = JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
        }

        private static void getCategories()
        {
            new JsonFeed();
            results = JsonFeed.GetCategories();
        }

        private static void GetNames()
        {
            new JsonFeed();
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}

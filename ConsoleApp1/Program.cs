using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] terms = { "apple", "banana", "orange", "pear", "grape", "watermelon" };
            string[] terms = { "gros", "gras", "graisse", "agressif", "go", "ros", "gro" };
            IAmTheTest test = new Test1();
            string[] suggestions = test.GetSuggestions("gros", terms, 2);
            //string[] suggestions = test.GetSuggestions("app", terms, 3);

            foreach (string suggestion in suggestions)
            {
                Console.WriteLine(suggestion);
                Console.ReadLine();
            }
        }
    }
}

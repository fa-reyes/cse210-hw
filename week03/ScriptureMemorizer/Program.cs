using System;

// I added a new file and class to store the scriptures 
class Program
{
    static void Main(string[] args)
    {
        Library myLibrary = new Library();

        Reference ref1 = new Reference("John", 3, 16);
        Scripture s1 = new Scripture(ref1, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        myLibrary.AddScripture(s1);

        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture s2 = new Scripture(ref2, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        myLibrary.AddScripture(s2);

        Reference ref3 = new Reference("Philippians", 4, 13);
        Scripture s3 = new Scripture(ref3, "I can do all things through Christ which strengtheneth me.");
        myLibrary.AddScripture(s3);

        Scripture currentScripture = myLibrary.GetRandomScripture();

        string userInput = "";

        while (userInput.ToLower() != "quit" && currentScripture.IsCompletelyHidden() == false)
        {
            Console.Clear();

            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                currentScripture.HideRandomWords(3);
            }
        }
        Console.Clear();

        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine("\nGood Job!");
    }
}
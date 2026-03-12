using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator myPrompt = new PromptGenerator();
        string userChoice = "";

        while (userChoice != "6")
        {
            // Added a new fifth choice for the user to add their own prompt/question to the list

            Console.WriteLine("1. Write\n2. Display\n3. Save\n4. Load\n5. Add\n6. Quit");
            Console.Write("What would you like to do? ");
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Entry anEntry = new Entry();
                anEntry._promptText = myPrompt.GetRandomPrompt();

                Console.WriteLine(anEntry._promptText);
                Console.Write("> ");
                anEntry._entryText = Console.ReadLine();
                
                theJournal.AddEntry(anEntry);
            }

            else if (userChoice == "2")
            {
                theJournal.DisplayAll();
            }

            else if (userChoice == "3") // Journals are now saved as .csv files for Excel compatibility.
            {
                Console.WriteLine("What is the filename? (e.g., journal.csv):");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }

            else if (userChoice == "4")
            {
                Console.WriteLine("What is the filename? (e.g., journal.csv):");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }

            else if (userChoice == "5") // This is the new fifth option I added.
            {
                Console.WriteLine("Write your own prompt:");
                string customPrompt = Console.ReadLine();

                myPrompt.AddUserPrompt(customPrompt);
                Console.WriteLine("Prompt added successfully!");
                Console.WriteLine("That's a really nice prompt! Adding your own questions makes the journal feel more personal!\n");
            }
        }   
    }
}
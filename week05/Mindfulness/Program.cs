using System;
// Exceeding requirements:
// Added a 'totalSessions' counter to track how many activities the user completes in a single run.
// Implemented logic in ReflectingActivity to ensure prompts and questions are not repeated until all have been used.
class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        int totalSessions = 0; // Counter that increments by 1 each time the user completes a mindfulness activity.
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                totalSessions++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                totalSessions++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                totalSessions++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                Console.WriteLine($"Total sessions completed this time: {totalSessions}"); 
                Console.WriteLine("Stay mindful. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
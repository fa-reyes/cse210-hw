using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();

        int percentage = int.Parse(userInput);
        string letter = "";
        string sign = "";


        if (percentage >= 90)
        {
            letter = "A";
        } 
        
        else if (percentage >= 80)
        {
            letter = "B";
        }

        else if (percentage >= 70)
        {
            letter = "C";
        }

        else if (percentage >= 60)
        {
            letter = "D";
        }

        else if (percentage < 60)
        {
            letter = "F";
        }

        else
        {
            Console.WriteLine("Enter a valid number.");
        }

        if (!(letter == "A" || letter == "F"))
        {
            int precisePercentage = percentage % 10;
            if (precisePercentage >= 7)
            {

                sign = "+";
            }

            else if (precisePercentage < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");


        if (percentage >= 60)
        {
            Console.WriteLine($"You passed the course!");
        }

        else
        {
            Console.WriteLine($"You failed. Try harder next time, you can do it!");
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {

        string playAgain;
        do
        {
            Random random = new Random();
            int num = random.Next(1,101);

            int userGuess = -1;
            int numberOfGuesses = 0;

            while (userGuess != num)
            {
                Console.Write("Guess a number from 1 to 100: ");
                userGuess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                if (userGuess < num)
                {
                    Console.WriteLine("Go higher!");
                }
                else if (userGuess > num)
                {
                    Console.WriteLine("Go lower!");
                }
                else if (userGuess == num)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} attempts.");
                }

                else
                {
                    Console.WriteLine("Enter a valid number.");
                }
            }

            Console.Write("Do you want to play again? Yes/No: ");
            playAgain = Console.ReadLine().ToLower();
            
        } while (playAgain == "yes");
        Console.WriteLine("Thanks for playing!");

    }
}
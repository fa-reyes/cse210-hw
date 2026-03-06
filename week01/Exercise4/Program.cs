using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumbers = -1;
        int numSum = 0;
        double numAv = 0;
        int largeNum = int.MinValue;
        int smallNum = int.MaxValue;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (userNumbers != 0)
        {
            Console.Write("Enter number: ");
            userNumbers = int.Parse(Console.ReadLine());

            if (userNumbers != 0)
            {
                numbers.Add(userNumbers);
                numSum = numSum + userNumbers;

                if (largeNum < userNumbers)
                {
                    largeNum = userNumbers;
                }

                if (userNumbers > 0)
                {
                    if (smallNum > userNumbers)
                    {
                        smallNum = userNumbers;
                    }
                }
            }
        }

        if (numbers.Count() > 0)
        {
            numAv = (double)numSum / numbers.Count;

            Console.WriteLine($"The sum is: {numSum}");
            Console.WriteLine($"The average is: {numAv:F2}");
            Console.WriteLine($"The largest number is: {largeNum}");
            Console.WriteLine($"The smallest positive number is: {smallNum}");

            numbers.Sort();

            foreach (int num in numbers)
            {
                Console.WriteLine($"The sorted list is: {num}");
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }

        
    }
}
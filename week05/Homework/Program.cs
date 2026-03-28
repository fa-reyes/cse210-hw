using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment as1 = new Assignment("Fabian Reyes", "Multiplication");
        Console.WriteLine(as1.GetSummary());

        MathAssignment m1 = new MathAssignment("Fabian Reyes", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(m1.GetHomeworkList());

        WritingAssignment w1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(w1.GetWritingInformation());
    }
}
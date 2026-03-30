public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _unusedPrompts = new List<string>(); // New variables and Lists added to not repeat prompts
    private List<string> _unusedQuestions = new List<string>(); // New variables and Lists added to not repeat prompts

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string> {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What is your favorite thing about this experience?",
            "What did you learn about yourself through this experience?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:");
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt() // Here is where the new "unusedPrompts" is used to not repeat prompts.
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        Random random = new Random();
        int index = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        
        _unusedPrompts.RemoveAt(index);
        
        return prompt;
    }

    public string GetRadomQuestion() // Here is where the new "unusedQuestions" is used to not repeat prompts.
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        Random random = new Random();
        int index = random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        
        _unusedQuestions.RemoveAt(index);
        
        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"\n --- {GetRandomPrompt()} --- ");
    }

    public void DisplayQuestions()
    {
        Console.Write($"\n> {GetRadomQuestion()} ");
        ShowSpinner(10);
    }
}
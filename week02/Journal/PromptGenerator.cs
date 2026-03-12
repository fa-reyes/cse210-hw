public class PromptGenerator
{
    List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
        
    Random _random = new Random();
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // This is the new method I added in the Program.cs in the menu for the user. 
    // Adds the user's input to the _prompts list (Menu option 5)
    public void AddUserPrompt(string newPrompt) 
    {
        _prompts.Add(newPrompt);
    }
}
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (type == "4")
        {
            _goals.Add(new NegativeGoal(name, description, points));
        }
    }

    public void RecordEvent() // Negative Goal logic added here
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish/fail? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Goal selectedGoal = _goals[index];

        if (!(selectedGoal is NegativeGoal) && selectedGoal.IsComplete())
        {
            Console.WriteLine("This goal is already completed.");
            return;
        }

        selectedGoal.RecordEvent();

        int pointsEarned = selectedGoal.GetPoints();

        if (selectedGoal is NegativeGoal)
        {
            _score -= pointsEarned;
            Console.WriteLine($"⚠️ Bad habit recorded. You lost {pointsEarned} points.");
        }
        else
        {
            if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete())
            {
                int bonusAmount = checklist.GetBonus();
                pointsEarned += bonusAmount;
                Console.WriteLine($"⭐ ¡BONUS COMPLETED! You earned {bonusAmount} extra points.");
            }

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }

        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split(":");
            string type = parts[0];
            string details = parts[1];

            string[] data = details.Split(",");

            if (type == "SimpleGoal")
            {
                SimpleGoal simple = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                if (bool.Parse(data[3])) 
                {
                    simple.RecordEvent();
                }
                _goals.Add(simple);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal eternal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                _goals.Add(eternal);
            }
            else if (type == "ChecklistGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int current = int.Parse(data[5]);

                ChecklistGoal checklist = new ChecklistGoal(name, desc, points, target, bonus);
                
                for (int j = 0; j < current; j++)
                {
                    checklist.RecordEvent();
                }
                _goals.Add(checklist);
            }
            else if (type == "NegativeGoal")
            {
                string name = data[0];
                string desc = data[1];
                int points = int.Parse(data[2]);

                NegativeGoal negative = new NegativeGoal(name, desc, points);
                _goals.Add(negative);
            }
        }
    }
}
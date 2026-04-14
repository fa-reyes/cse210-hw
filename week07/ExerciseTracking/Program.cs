using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("14 Apr 2026", 30, 4.8));
        activities.Add(new Cycling("14 Apr 2026", 30, 20.0));
        activities.Add(new Swimming("14 Apr 2026", 30, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
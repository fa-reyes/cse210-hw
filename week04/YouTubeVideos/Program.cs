using System;

class Program
{
    static void Main(string[] args)
    {
        Video v1 = new Video("C# Basic Tutorial", "JohnDev", 690);
        Comment c1 = new Comment("Davo Clark", "It's very helpful, thank you!!");
        Comment c2 = new Comment("PedroSilva9", "Does any one else feel like he's better at teaching than some teachers.");
        Comment c3 = new Comment("SorrowSprite1", "Best C# Course for Beginners so far");
        v1.AddComment(c1);
        v1.AddComment(c2);
        v1.AddComment(c3);

        Video v2 = new Video("Easy Breakfast recipes you should know!", "Cook with me", 580);
        Comment c4 = new Comment("Sarah Smith", "I tried this recipe last night and my family loved it!");
        Comment c5 = new Comment("HealthyEats", "Is there a vegan substitute for the butter in this one?");
        Comment c6 = new Comment("Chef_Gordon_Fan", "The secret is definitely in the seasoning. Amazing tips.");
        v2.AddComment(c4);
        v2.AddComment(c5);
        v2.AddComment(c6);

        Video v3 = new Video("New iphone is on the market!", "Apple News", 500);
        Comment c7 = new Comment("GadgetGeek", "The battery life on this new model is actually impressive.");
        Comment c8 = new Comment("TechSupport_Sam", "I think the previous version had a better keyboard layout.");
        Comment c9 = new Comment("Jenny_Vlogs", "The camera quality is top-notch for this price point.");
        v3.AddComment(c7);
        v3.AddComment(c8);
        v3.AddComment(c9);

        List<Video> videoList = new List<Video>();
        videoList.Add(v1);
        videoList.Add(v2);
        videoList.Add(v3);

        Console.WriteLine("- - - Youtube Video Tracker - - -\n");

        foreach (Video video in videoList)
        {
            video.DisplayInfo();
        }
    }
}
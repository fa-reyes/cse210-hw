public class Library // This class manages a collection of scriptures and provides a random one
{
    private List<Scripture> _scriptures = new List<Scripture>();

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        Random rnd = new Random();
        int index = rnd.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
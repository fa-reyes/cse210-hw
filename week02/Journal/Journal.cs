public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    public void DisplayAll()
    {
        foreach (Entry anEntry in _entries)
        {
            anEntry.Display();
        }
    }

    public void SaveToFile(string filename) // This is how the journal is saved to a .csv file.
    {
        Console.WriteLine("Saving to: " + Path.GetFullPath(filename));

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("sep=,");
            outputFile.WriteLine("\"Date\",\"Prompt\",\"EntryText\"");

            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"\"{entry._date}\",\"{entry._promptText}\",\"{entry._entryText}\"");
            }
        }
    }

    public  void LoadFromFile(string filename) // This is how the journal loads the .csv file.
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                if (line == "sep=," || line == "\"Date\",\"Prompt\",\"EntryText\"") 
                {
                    continue; 
                }

                string[] parts = line.Split("\",\"");

                Entry newEntry = new Entry();

                newEntry._date = parts[0].Trim('"');
                newEntry._promptText = parts[1].Trim('"');
                newEntry._entryText = parts[2].Trim('"');

                _entries.Add(newEntry);
            }
        }

        else
        {
            Console.WriteLine("\nError: The file was not found. Please make sure the name is correct or save a file first.");
        }
    }

}
public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitText = text.Split(' ');

        foreach (string item in splitText)
        {
            _words.Add(new Word(item));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> availableWords = new List<Word>();

        foreach (Word currentWord in _words)
        {
            if (currentWord.IsHidden() == false)
            {
                availableWords.Add(currentWord);
            }
        }

        if (availableWords.Count == 0)
        {
            return;
        }

        int hiddenCount = 0;
        while (hiddenCount < numberToHide && availableWords.Count > 0)
        {
            int randomIndex = random.Next(availableWords.Count);
            Word wordToHide = availableWords[randomIndex];
            wordToHide.Hide();

            availableWords.RemoveAt(randomIndex);
            hiddenCount ++;
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText() + " ";
        
        foreach (Word currentWord in _words)
        {
            scriptureText = scriptureText + currentWord.GetDisplayText() + " ";
        }

        return scriptureText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word wordToCheck in _words)
        {
            if (wordToCheck.IsHidden() == false)
            {
                return false;
            }
        }

        return true;
    }
}
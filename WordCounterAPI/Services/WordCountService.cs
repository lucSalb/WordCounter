using WordCounterAPI.Classes;
using WordCounterAPI.Interfaces;

namespace WordCounterAPI.Services
{
    public class WordCountService : IWordCountService
    {
        public List<FoundWord> CountWords(string content)
        {
            List<FoundWord> foundWords = new List<FoundWord>();
            var wordCounter = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var cleanText = TextCleaner(content);
            var words = cleanText.Split(" ",StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (wordCounter.ContainsKey(word)) wordCounter[word]++;
                else wordCounter.Add(word, 1);
            }
            foreach (var dict in wordCounter.Keys) 
            {
                foundWords.Add(new FoundWord()
                {
                    word = PrettyWordDisplay(dict),
                    numberOfTimes = wordCounter[dict]
                });
            }

            return foundWords.OrderByDescending(fw => fw.numberOfTimes).ToList();
        }
        private string TextCleaner(string text)
        {
            return text.ToUpper()
                       .Replace(",", "")
                       .Replace(".", "")
                       .Replace("(", "")
                       .Replace(")", "")
                       .Replace("\r\n", "");
            
        }
        public string PrettyWordDisplay(string word)
        {
            if (word == null || word == "") return word;
            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
    }
}

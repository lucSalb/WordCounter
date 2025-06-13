using WordCounterAPI.Classes;

namespace WordCounterAPI.Interfaces
{
    public interface IWordCountService
    {
        public List<FoundWord> CountWords(string content);
    }
}

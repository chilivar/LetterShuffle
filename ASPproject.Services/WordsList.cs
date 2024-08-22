using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPproject.Models;

namespace ASPproject.Services 
{
    public class WordsList : IFillList
    {
        private List<Words> _wordList;
         
        public IEnumerable<Words> GetAllWords()
        {
            return _wordList;
        }

        public void ShuffleWord()
        {
            string[] words = { "ключ", "подвал", "машина" };

            Random rnd = new Random();
            int randomIndex = rnd.Next(words.Length);

            string firstWords = words[randomIndex];
            string secondWords = Shuffle(firstWords);

            Words wordPair = new Words
            {
                mainWord = firstWords,
                remadeWord = secondWords
            };

            _wordList.Add(wordPair);
        }

        static string Shuffle(string word)
        {
            Random random = new Random();
            return new string(word.ToCharArray().OrderBy(c => random.Next()).ToArray());
        }


    }
}

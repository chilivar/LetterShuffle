using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPproject.Models;
using System;
using System.IO;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Hosting.Server;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ASPproject.Contexts;

namespace ASPproject.Pages.Game
{
    public class GamePageModel : PageModel
    {

        private readonly UserContext _context;

        public GamePageModel(UserContext context)
        {
            _context = context;
        }
        
        public List<WordPair> WordList { get; private set; } = new List<WordPair>();

        [BindProperty]
        public string Answer { get; set; }

        [BindProperty]
        public string CorrectAnswer { get; set; }

        [BindProperty]
        public int NumberAnswer { get; set; }

        public int Id = 1;


        public string Message { get; private set; } = "";

        public void ReadNumberFromFile()
        {
            
             NumberAnswer = _context.users.Where(u => u.id == Id).Select(u => u.correct_answer).FirstOrDefault();
            
        }



        public void OnGet()
        {
            ShuffleWord();
            ReadNumberFromFile();
        }

        public IActionResult OnPostSubmit()
        {


            var user = _context.users.Where(u => u.id == Id).FirstOrDefault();

            bool IsCorrect;

            Answer = string.IsNullOrEmpty(Answer) ? "Нет ответа" : Answer;

            if (CorrectAnswer == Answer.ToLower())
            {
                
                Answer = Answer;
                CorrectAnswer = CorrectAnswer;
                NumberAnswer = user.correct_answer++;
                _context.SaveChanges();
                
            }
            else
            {
                if(NumberAnswer != 0)
                {
                    
                    Answer = Answer;
                    CorrectAnswer = CorrectAnswer;
                    NumberAnswer = user.correct_answer--;
                    _context.SaveChanges();
                    
                }
                else
                {
                    
                    Answer = Answer;
                    CorrectAnswer = CorrectAnswer;
                    user.correct_answer = 0;
                    NumberAnswer = user.correct_answer;
                    _context.SaveChanges();
                    
                }
            }
            return RedirectToPage("/Game/ResponsePage", new { answer = Answer, correctAnswer = CorrectAnswer });
        }

        public void ShuffleWord()
        {

            Random rnd = new Random();
            var randomWord = _context.words
                                   .OrderBy(w => Guid.NewGuid()) 
                                   .Select(w => w.word)
                                   .FirstOrDefault();

            string firstWord = randomWord;
            string secondWord = Shuffle(firstWord);
            while(secondWord == firstWord)
            {
                secondWord = Shuffle(firstWord);
            }

            WordPair wordPair = new WordPair
            {
                mainWord = firstWord,
                remadeWord = secondWord
            };
            
            WordList.Add(wordPair);
        }

        static string Shuffle(string word)
        {
            Random random = new Random();
            return new string(word.ToCharArray().OrderBy(c => random.Next()).ToArray());
        }
    }
}

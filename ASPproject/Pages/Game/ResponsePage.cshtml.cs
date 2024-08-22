using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPproject.Pages.Game
{
    public class ResponsePageModel : PageModel
    {
        
        public string Answer { get; private set; }
        public string CorrectAnswer { get; private set; }
        public bool IsCorrect { get; set; }

        public void OnGet(string answer, string correctAnswer)
        {
            
            Answer = answer;
            CorrectAnswer = correctAnswer;
            IsCorrect = correctAnswer.ToLower() == answer.ToLower();
        }
    }
}

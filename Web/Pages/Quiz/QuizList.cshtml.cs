using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz
{
    public class QuizListModel : PageModel
    {

        private readonly IQuizUserService _userService;

        private readonly ILogger _logger;

        public List<BackendLab01.Quiz> Quizzes { get; set; }

        
        public QuizListModel(IQuizUserService userService, ILogger<QuizModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public void OnGet()
        {
            Quizzes = _userService.GetAllQuizzes();
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BackendLab01.Pages;

public class Summary : PageModel
{

    private readonly IQuizUserService _userService;

    private readonly ILogger _logger;

    public int result;
    public Summary(IQuizUserService userService, ILogger<QuizModel> logger)
    {
        _userService = userService;
        _logger = logger;
    }
    public void OnGet(int quizId, int userId)
    {
        result = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, userId);
    }

}
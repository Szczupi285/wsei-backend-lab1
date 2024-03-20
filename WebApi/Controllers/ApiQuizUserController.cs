using ApplicationCore.Exceptions;
using BackendLab01;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/users/quizzes")]
    public class ApiQuizUserController : ControllerBase
    {
        private IQuizUserService _userService;

        public ApiQuizUserController(IQuizUserService quizUserService)
        {
            _userService = quizUserService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDTO> FindQuizById(int id)
        {
            var quiz = _userService.FindQuizById(id);
            return quiz is null ? NotFound() : QuizDTO.Of(quiz);
        }
        [HttpPost]
        [Route("{quizId}/items/{itemId}/answers")]
        public ActionResult SaveAnswer(int quizId, int itemId, AnswerDTO answer)
        {
            try
            {
                _userService.SaveUserAnswerForQuiz(quizId, 1, itemId, answer.Answer);
                return Ok();
            }
            catch(DuplicateAnswerException ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
           
        }
        [HttpGet]
        [Route("{quizId}/answers")]
        public ActionResult<object> ReturnFeedback(int quizId)
        {
            int correct = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, 1);
            return new
            {
                CorrectAnswers = correct,
                QuizId = quizId,
                userId = 1
            };

        }
    }
}

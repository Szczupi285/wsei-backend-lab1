using ApplicationCore.Exceptions;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public ApiQuizUserController(IQuizUserService quizUserService, IMapper mapper)
        {
            _userService = quizUserService;
            _mapper = mapper;
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
            catch (DuplicateAnswerException ex)
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
        [Route("{quizId}/answers/{userId}")]
        [HttpGet]
        public ActionResult<object> GetQuizFeedback(int quizId, int userId)
        {
            var feedback = _userService.GetUserAnswersForQuiz(quizId, userId);
            return new
            {
                quizId = quizId,
                userId = userId,
                totalQuestions = _userService.FindQuizById(quizId)?.Items.Count ?? 0,
                answers = feedback.Select(a =>
                    new
                    {
                        question = a.QuizItem.Question,
                        answer = a.Answer,
                        isCorrect = a.IsCorrect()
                    }
                ).AsEnumerable()
            };

        }
    }
}

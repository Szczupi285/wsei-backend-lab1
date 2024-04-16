using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Mappers;
using Infrastructure.EF;
using BackendLab01;

namespace Infrastructure.Services
{
    public class QuizUserServiceEF : IQuizUserService
    {
        private QuizDbContext _context;

        public QuizUserServiceEF(QuizDbContext context)
        {
            _context = context;
        }

        public Quiz CreateAndGetQuizRandom(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quiz> FindAllQuizzes()
        {
            return _context
                .Quizzes
                .AsNoTracking()
                .Include(q => q.Items)
                .ThenInclude(i => i.IncorrectAnswers)
                .Select(QuizMapper.FromEntityToQuiz)
                .ToList();
        }

        public Quiz? FindQuizById(int id)
        {
            var entity = _context
                .Quizzes
                .AsNoTracking()
                .Include(q => q.Items)
                .ThenInclude(i => i.IncorrectAnswers)
                .FirstOrDefault(e => e.Id == id);
            return entity is null ? null : QuizMapper.FromEntityToQuiz(entity);
        }

        public List<Quiz> GetAllQuizzes()
        {
            throw new NotImplementedException();
        }

        public IQueryable<QuizItemUserAnswer> GetUserAnswersForQuiz(int quizId, int userId)
        {
            throw new NotImplementedException();
        }

        public QuizItemUserAnswer SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
        {
            var quizzEntity = _context.Quizzes.FirstOrDefault(q => q.Id == quizId);
            if (quizzEntity is null)
            {
                throw new QuizNotFoundException($"Quiz with id {quizId} not found");
            }
            var item = quizzEntity.Items.FirstOrDefault(q => q.Id == quizItemId); // pobierz encję elementu quizu o quizItemId 
            if (item is null)
            {
                throw new QuizItemNotFoundException($"Quiz item with id {quizId} not found");
            }
            QuizItemUserAnswerEntity entity = new QuizItemUserAnswerEntity()
            {
                UserId = userId,
                QuizId = quizId,                
                QuizItemId = quizItemId,
                UserAnswer = answer
            };        
        
            var savedEntity = _context.Add(entity).Entity;
            _context.SaveChanges();
               return QuizMapper.FromEntityToQuizItemUserAnswer(entity);
        }

        List<QuizItemUserAnswer> IQuizUserService.GetUserAnswersForQuiz(int quizId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

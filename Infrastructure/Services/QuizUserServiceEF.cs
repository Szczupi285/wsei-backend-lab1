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
using System.Runtime.InteropServices;

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
            var items = _context.UserAnswers.Where(u => u.UserId == userId && u.QuizId == quizId).ToList();
            List<QuizItemUserAnswer> usa = new List<QuizItemUserAnswer>();
            foreach(var item in items)
            {
                usa.Add(QuizMapper.FromEntityToQuizItemUserAnswer(item));
            }
            return usa.AsQueryable();
            
        }

        public QuizItemUserAnswer SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
        {
            QuizItemUserAnswerEntity entity = new QuizItemUserAnswerEntity()
            {
                UserId = userId,
                QuizItemId = quizItemId,
                QuizId = quizId,
                UserAnswer = answer
            };
            try
            {
                var saved = _context.UserAnswers.Add(entity).Entity;
                _context.SaveChanges();
                return new QuizItemUserAnswer(QuizMapper.FromEntityToQuizItem(saved.QuizItem), saved.UserId, saved.QuizId, saved.UserAnswer);
               
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException.Message.StartsWith("The INSERT"))
                {
                    throw new QuizNotFoundException("Quiz, quiz item or user not found. Can't save!");
                }
                if (e.InnerException.Message.StartsWith("Violation of"))
                {
                    throw new QuizAnswerItemAlreadyExistsException(quizId, quizItemId, userId);
                }
                throw new Exception(e.Message);
            }
        }

        List<QuizItemUserAnswer> IQuizUserService.GetUserAnswersForQuiz(int quizId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

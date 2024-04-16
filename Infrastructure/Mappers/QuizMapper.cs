using BackendLab01;
using Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class QuizMapper
    {
        public static QuizItem FromEntityToQuizItem(QuizItemEntity entity)
        {
            return new QuizItem(
                entity.Id,
                entity.Question,
                entity.IncorrectAnswers.Select(e => e.Answer).ToList(),
                entity.CorrectAnswer);
        }

        public static Quiz FromEntityToQuiz(QuizEntity entity)
        {
            List<QuizItem> items = new List<QuizItem>();
            foreach(var i in entity.Items)
                items.Add(FromEntityToQuizItem(i));
            return new Quiz(
                entity.Id,
                items,
                entity.Title
                );
        }

        

        public static QuizItemUserAnswer FromEntityToQuizItemUserAnswer(QuizItemUserAnswerEntity entity)
        {
            return new QuizItemUserAnswer(
                FromEntityToQuizItem(entity.QuizItem),
                entity.UserId,
                entity.QuizId,
                entity.UserAnswer);
            
        }
    }
}

using ApplicationCore.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class DuplicateAnswerException : QuizExceptions
    {
        private int Id;
        private int QuizId;
        private int ItemId;
        public DuplicateAnswerException(int userId, int quizId, int itemId) : base($"User with Id:{userId} answered the same answer with Id:{itemId} on quiz with Id:{quizId} twice")
        {
            Id= userId;
            QuizId = quizId;
            ItemId= itemId;
        }
    }
}

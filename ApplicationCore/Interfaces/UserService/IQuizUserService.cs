﻿using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public interface IQuizUserService
{
    Quiz CreateAndGetQuizRandom(int count);

    public List<Quiz> GetAllQuizzes();
    
    Quiz? FindQuizById(int id);

    QuizItemUserAnswer SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer);

    List<QuizItemUserAnswer> GetUserAnswersForQuiz(int quizId, int userId);

    int CountCorrectAnswersForQuizFilledByUser(int quizId, int userId)
    {
        return GetUserAnswersForQuiz(quizId, userId)
            .Count(e => e.IsCorrect());
    }
}
﻿using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Criteria;
using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class QuizUserService : IQuizUserService
{
    private readonly IGenericRepository<Quiz, int> quizRepository;
    private readonly IGenericRepository<QuizItem, int> itemRepository;
    private readonly IGenericRepository<QuizItemUserAnswer, string> answerRepository;

    public QuizUserService(IGenericRepository<Quiz, int> quizRepository, IGenericRepository<QuizItemUserAnswer, string> answerRepository, IGenericRepository<QuizItem, int> itemRepository)
    {
        this.quizRepository = quizRepository;
        this.answerRepository = answerRepository;
        this.itemRepository = itemRepository;
    }
    public List<Quiz> GetAllQuizzes()
    {
        return quizRepository.FindAll();
    }
    public Quiz CreateAndGetQuizRandom(int count)
    {
        throw new NotImplementedException();
    }

    public Quiz? FindQuizById(int id)
    {
        return quizRepository.FindById(id);
    }

    public QuizItemUserAnswer SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
    {
        var quiz = quizRepository.FindById(quizId);
        var item = quiz.Items.FirstOrDefault(x => x.Id == quizItemId);
        var userAnswer = new QuizItemUserAnswer(quizItem: item, userId: userId, answer: answer, quizId: quizId);
        if (answerRepository.FindById(userAnswer.Id) is null)
        {
            answerRepository.Add(userAnswer);
            return userAnswer;
        }
        throw new DuplicateAnswerException(userId, quizId, item.Id);
    }


    public List<QuizItemUserAnswer> GetUserAnswersForQuiz(int quizId, int userId)
    {
        // return answerRepository.FindAll()
        //     .Where(x => x.QuizId == quizId)
        //     .Where(x => x. UserId == userId)
        //     .ToList();
        return answerRepository.FindBySpecification(new QuizItemsForQuizIdFilledByUser(quizId, userId)).ToList();
    }
    int IQuizUserService.CountCorrectAnswersForQuizFilledByUser(int quizId, int userId)
    {
        return GetUserAnswersForQuiz(quizId, userId).Count(e => e.IsCorrect());
    }

    void IQuizUserService.SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
    {
        throw new NotImplementedException();
    }
}
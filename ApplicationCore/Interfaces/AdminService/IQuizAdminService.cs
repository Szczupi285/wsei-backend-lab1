﻿namespace BackendLab01;

public interface IQuizAdminService
{
    public QuizItem AddQuizItem(string question, List<string> incorrectAnswers, string correctAnswer, int points);
    public void UpdateQuizItem(int id, string question, List<string> incorrectAnswers, string correctAnswer, int points);
    public Quiz AddQuiz(string title, List<QuizItem> items);
    public Quiz AddQuiz(Quiz quiz);
    public List<QuizItem> FindAllQuizItems();
    public List<Quiz> FindAllQuizzes();
    public void UpdateQuiz(Quiz quiz);
    public void AddQuizItemToQuiz(int quizId, QuizItem item);
}
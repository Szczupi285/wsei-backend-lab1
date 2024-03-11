using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            List<QuizItem> questions11 = new List<QuizItem>();
            List<QuizItem> questions21 = new List<QuizItem>();
            List<string> incorrectAnswers11 = new List<string>
            {
                "incorrect11",
                "incorrect12",
                "incorrect13"

            };
            List<string> incorrectAnswers12 = new List<string>
            {
                "incorrect21",
                "incorrect22",
                "incorrect23"

            };
            List<string> incorrectAnswers13 = new List<string>
            {
                "incorrect31",
                "incorrect32",
                "incorrect33"

            };
            List<string> incorrectAnswers21 = new List<string>
            {
                "incorr11",
                "incorr12",
                "incorr13"

            };
            List<string> incorrectAnswers22 = new List<string>
            {
                "incorr21",
                "incorr22",
                "incorr23"

            };
            List<string> incorrectAnswers23 = new List<string>
            {
                "incorr31",
                "incorr32",
                "incorr33"

            };
            var quizItem11 = new QuizItem(1, "question1", incorrectAnswers11, "goodAnswer11");
            var quizItem12 = new QuizItem(2, "question2", incorrectAnswers12, "goodAnswer12");
            var quizItem13 = new QuizItem(3, "question3", incorrectAnswers13, "goodAnswer13");
            var quizItem21 = new QuizItem(1, "question1", incorrectAnswers21, "goodAnswer21");
            var quizItem22 = new QuizItem(2, "question2", incorrectAnswers22, "goodAnswer22");
            var quizItem23 = new QuizItem(3, "question3", incorrectAnswers23, "goodAnswer23");

            questions11.Add(quizItem11);
            questions11.Add(quizItem12);
            questions11.Add(quizItem13);

            questions21.Add(quizItem21);
            questions21.Add(quizItem22);
            questions21.Add(quizItem23);

            var quiz1 = new Quiz(1, questions11, "title1");
            var quiz2 = new Quiz(2, questions21, "title2");

            quizRepo.Add(quiz1);
            quizRepo.Add(quiz2);

            quizItemRepo.Add(quizItem11);
            quizItemRepo.Add(quizItem12);
            quizItemRepo.Add(quizItem13);
            quizItemRepo.Add(quizItem21);
            quizItemRepo.Add(quizItem22);
            quizItemRepo.Add(quizItem23);
        }
    }
}
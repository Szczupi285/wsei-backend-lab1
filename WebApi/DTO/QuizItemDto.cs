using BackendLab01;

namespace WebApi.DTO
{
    public class QuizItemDto
    {
        private static Random rand = new Random();
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }

        public static QuizItemDto Of(QuizItem item)
        {
            var options = new List<string>(item.IncorrectAnswers)
            {
                item.CorrectAnswer,
            };
            options.Sort((a, b) => 1 - rand.Next(maxValue: 2));
            return new QuizItemDto
            {
                Id = item.Id,
                Question = item.Question,
                Options = options
                
            };
        }
        
    }
}

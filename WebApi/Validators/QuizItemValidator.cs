using BackendLab01;
using FluentValidation;

namespace WebApi.Validators
{
    public class QuizItemValidator : AbstractValidator<QuizItem>
    {
        public QuizItemValidator()
        {
            RuleFor(q => q.Question)
                .MaximumLength(200).WithMessage("Pytanie za dlugie, max 200 znakow")
                .MinimumLength(5)
                .Must(q => q.EndsWith("?")).WithMessage("brak pytajnika na koncu");

            RuleForEach(q => q.IncorrectAnswers)
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(q => new { q.CorrectAnswer, q.IncorrectAnswers })
                .Must(p => !p.IncorrectAnswers.Contains(p.CorrectAnswer))
                .WithMessage("poprawna odpowiedz nie moze wystepowac w liscie niepoprawnych");
        }
    }
}
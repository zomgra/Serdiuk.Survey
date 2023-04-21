using FluentResults;
using MediatR;

namespace Serdiuk.Survey.Application.Questions.SubmitAnswer
{
    public class SubmitAnswerCommand : IRequest<Result>
    {
        public int AnswerId { get; set; }
    }
}

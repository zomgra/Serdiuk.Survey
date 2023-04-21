using FluentResults;
using MediatR;

namespace Serdiuk.Survey.Application.Surveys.GetById
{
    public class GetSurveyByIdQuery : IRequest<Result<Domain.Survey>>
    {
        public int SurveyId { get; set; }
    }
}

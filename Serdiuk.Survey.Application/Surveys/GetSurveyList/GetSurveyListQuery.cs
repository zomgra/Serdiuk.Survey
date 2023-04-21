using FluentResults;
using MediatR;

namespace Serdiuk.Survey.Application.Surveys.GetSurveyList
{
    public class GetSurveyListQuery : IRequest<Result<IEnumerable<Domain.Survey>>>
    {
        public int PageNumber { get; set; }
    }
}

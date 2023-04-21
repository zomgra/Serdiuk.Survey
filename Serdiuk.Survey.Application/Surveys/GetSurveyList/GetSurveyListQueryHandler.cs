using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Survey.Application.Common.Helpers;
using Serdiuk.Survey.Application.Common.Interfaces;

namespace Serdiuk.Survey.Application.Surveys.GetSurveyList
{
    public class GetSurveyListQueryHandler : IRequestHandler<GetSurveyListQuery, Result<IEnumerable<Domain.Survey>>>
    {
        private readonly IAppDbContext _context;
        private readonly int _pageSize = PagingParameters.MaxPageSize;

        public GetSurveyListQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Domain.Survey>>> Handle(GetSurveyListQuery request, CancellationToken cancellationToken)
        {

            var surveys = await _context.Surveys
                .Skip(_pageSize * (request.PageNumber - 1))
                .Take(_pageSize)
                .Include(n => n.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync(cancellationToken);

            if (!surveys.Any())
            {
                return Result.Fail("No surveys found");
            }

            return surveys.ToResult<IEnumerable<Domain.Survey>>();
        }
    }
}

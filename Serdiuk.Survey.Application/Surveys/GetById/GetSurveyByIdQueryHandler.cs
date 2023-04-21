using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Survey.Application.Common.Interfaces;

namespace Serdiuk.Survey.Application.Surveys.GetById
{
    public class GetSurveyByIdQueryHandler : IRequestHandler<GetSurveyByIdQuery, Result<Domain.Survey>>
    {
        private readonly IAppDbContext _context;

        public GetSurveyByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Domain.Survey>> Handle(GetSurveyByIdQuery request, CancellationToken cancellationToken)
        {
            var survey = await _context.Surveys.Include(s=>s.Questions).ThenInclude(q=>q.Answers).FirstOrDefaultAsync(s=>s.Id==request.SurveyId , cancellationToken);

            if (survey == null)
                return Result.Fail("Survey is not found");

            return survey.ToResult();
        }
    }
}

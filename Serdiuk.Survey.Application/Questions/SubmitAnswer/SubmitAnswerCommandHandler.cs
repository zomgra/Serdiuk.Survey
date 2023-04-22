using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Survey.Application.Common.Interfaces;
using Serdiuk.Survey.Domain;

namespace Serdiuk.Survey.Application.Questions.SubmitAnswer
{
    public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, Result>
    {
        private readonly IAppDbContext _context;

        public SubmitAnswerCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _context.Answers.FirstOrDefaultAsync(a => a.Id == request.AnswerId, cancellationToken);
            var survey = _context.Surveys
                .FirstOrDefault(s => s.Questions.Any(q => q.Answers.Any(a => a.Id == request.AnswerId)));

            if (survey == null || survey.EndDate < DateTime.UtcNow)
                return Result.Fail("Survey expired");

            if (answer == null)
                return Result.Fail("Answer not found, try again");

            answer.Apply();

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}

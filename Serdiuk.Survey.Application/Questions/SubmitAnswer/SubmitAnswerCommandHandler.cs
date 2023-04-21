using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Survey.Application.Common.Interfaces;

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

            if(answer == null)
                return Result.Fail("Answer not found, try again");

            answer.Apply();

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}

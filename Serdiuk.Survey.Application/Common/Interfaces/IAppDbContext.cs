using Microsoft.EntityFrameworkCore;
using Serdiuk.Survey.Domain;

namespace Serdiuk.Survey.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Domain.Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

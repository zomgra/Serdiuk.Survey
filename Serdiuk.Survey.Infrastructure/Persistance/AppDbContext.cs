using Microsoft.EntityFrameworkCore;
using Serdiuk.Survey.Domain;
using Serdiuk.Survey.Application.Common.Interfaces;

namespace Serdiuk.Survey.Infrastructure.Persistance
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}

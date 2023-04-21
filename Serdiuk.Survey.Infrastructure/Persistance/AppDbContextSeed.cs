using Microsoft.Extensions.DependencyInjection;
using Serdiuk.Survey.Domain;

namespace Serdiuk.Survey.Infrastructure.Persistance
{
    public class AppDbContextSeed
    {
        public static void Initialize(IServiceProvider provider)
        {
            var context = provider.GetService<AppDbContext>();
            var survey = new Domain.Survey()
            {
                Title = "Feedback Survey",
                Description = "Please take a moment to provide us with feedback on our services",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                Questions = new List<Question>
                {
                    new Question("How would you rate your overall satisfaction with our services?")
                    {
                        Answers = new List<Answer>
                        {
                            new Answer { Value = "Very satisfied" },
                            new Answer { Value = "Somewhat satisfied" },
                            new Answer { Value = "Neither satisfied nor dissatisfied" },
                            new Answer { Value = "Somewhat dissatisfied" },
                            new Answer { Value = "Very dissatisfied" }
                        }
                    },
                    new Question("How easy was it to find the information you were looking for?")
                    {
                        Answers = new List<Answer>
                        {
                            new Answer { Value = "Very easy" },
                            new Answer { Value = "Somewhat easy" },
                            new Answer { Value = "Neither easy nor difficult" },
                            new Answer { Value = "Somewhat difficult" },
                            new Answer { Value = "Very difficult" }
                        }
                    },
                    new Question("Do you have any suggestions for improving our services?")
                    {
                        Answers = new List<Answer>
                        {
                            new Answer { Value = "Yes" },
                            new Answer { Value = "No" }
                        }
                    }
                }
            };

            if (!context.Surveys.Any())
            {
                context.Add(survey);
                context.SaveChanges();
            }
        }
    }
}

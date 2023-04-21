namespace Serdiuk.Survey.Domain
{
    public class Question
    {
        public Question(string test)
        {
            Text = test;
        }

        public Question(int id, string text, QuestionType type)
        {
            Id = id;
            Text = text;
            Type = type;
        }

        public int Id { get; set; }
        /// <summary>
        /// Content question
        /// </summary>
        public string Text { get; init; }
        /// <summary>
        /// Type of question
        /// </summary>
        // TODO : Change types
        public QuestionType Type { get; set; }
        /// <summary>
        /// Possible answer
        /// </summary>
        public List<Answer> Answers { get; set; }
    }
}

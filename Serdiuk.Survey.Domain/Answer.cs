namespace Serdiuk.Survey.Domain
{
    public class Answer
    {
        /// <summary>
        /// Identifier answer
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Answer content
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Count of responses
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Accept one answer
        /// </summary>
        public void Apply()
        {
            Count++;
        }
    }
}

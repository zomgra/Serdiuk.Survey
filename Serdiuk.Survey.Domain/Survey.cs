namespace Serdiuk.Survey.Domain
{
    /// <summary>
    /// Survey
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Identifier survey
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of survey
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Date start survey
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Date end survey
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Questions of survey
        /// </summary>
        public List<Question> Questions { get; set; }
        /// <summary>
        /// Flag, user is anonymous 
        /// </summary>
        public bool IsAnonymous { get; set; }
    }
}

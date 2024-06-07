namespace VolkanKarakulakPortfolio.Models
{
    public class EducationContent
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime PublisedDate { get; set; }
        public string Description { get; set; } = "";
        public List<Tag>? Tags { get; set; }
        public enum ContentType
        {
            Article,
            Note,
        }
    }
}

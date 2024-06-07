namespace VolkanKarakulakPortfolio.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<EducationContent>? educationContents { get; set; }
    }
}

namespace Kisisel_Blog_Sitesi.Models
{
    public class EducationContentTag
    {
        public int EducationContentId { get; set; }
        public EducationContent? EducationContent { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}

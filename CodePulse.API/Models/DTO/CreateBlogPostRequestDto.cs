namespace CodePulse.API.Models.DTO
{
    public class CreateBlogPostRequestDto    {
        public String Title { get; set; }
        public String ShortDesc { get; set; }
        public String Content { get; set; }
        public String FeaturedImageUrl { get; set; }
        public String UrlHandle { get; set; }
        public String Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsVisible { get; set; }
        public Guid[] Categories { get; set; }
    }
}

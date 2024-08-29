﻿namespace CodePulse.API.Models.DTO
{
    public class BlogImageDto
    {
        public Guid Id { get; set; }
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String Title { get; set; }
        public String Url { get; set; }
        public DateTime DataCreated { get; set; }
    }
}

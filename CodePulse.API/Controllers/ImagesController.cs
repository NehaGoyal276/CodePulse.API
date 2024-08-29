﻿using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository) 
        {
            this.imageRepository = imageRepository;
        }
        //POST: //{apibaseurl}/api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
         [FromForm] string fileName, [FromForm] string title )
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                // File upload
                var blogImage = new BlogImage
                {

                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DataCreated = DateTime.Now
                };

                blogImage = await imageRepository.Upload(file, blogImage);

                //Convert Domain Model ti DTO
                var response = new BlogImageDto
                {
                    Id = blogImage.Id,
                    Title = blogImage.Title,
                    DataCreated  = blogImage.DataCreated,
                    FileExtension = blogImage.FileExtension,
                    Url = blogImage.Url
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower())) {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if(file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File Size can not be more than 10 mb");
            }
        }

    }
}

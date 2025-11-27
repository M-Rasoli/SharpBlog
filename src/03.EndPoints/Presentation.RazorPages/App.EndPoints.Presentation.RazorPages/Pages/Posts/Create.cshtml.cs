using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.EndPoints.Presentation.RazorPages.Session;
using App.Infrastructure.FileService.Contracts;
using App.Infrastructure.FileService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace App.EndPoints.Presentation.RazorPages.Pages.Posts
{
    public class CreatePostModel
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile Image { get; set; }
    }
    public class CreateModel(IPostAppService postAppService 
        ,ICategoryAppService categoryAppService 
        ,IFileService fileService) : PageModel
    {
        [BindProperty]
        public CreatePostModel Model { get; set; }
        public List<GetCategoriesDto> Categories { get; set; }
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            Categories = categoryAppService.GetCategoriesByAuthorId(LoggedInUser.UserId);
            return Page();
        }

        public IActionResult OnPost()
        {
            string image = null;
            
            if (Model.Image != null)
            {
                var extension = Path.GetExtension(Model.Image.FileName).ToLower();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

                if (!allowedExtensions.Contains(extension))
                {
                    Message = "فقط فایل‌های JPG یا PNG مجاز هستند.";
                    Categories = categoryAppService.GetCategoriesByAuthorId(LoggedInUser.UserId);
                    return Page();
                }

                if (Model.Image.Length > 2 * 1024 * 1024)
                {
                    Message = "حجم فایل نباید بیشتر از ۲ مگابایت باشد.";
                    Categories = categoryAppService.GetCategoriesByAuthorId(LoggedInUser.UserId);
                    return Page();
                }
                image = fileService.Upload(Model.Image, "PostsImage");
            }

            CreatePostDto newPost = new CreatePostDto()
            {
                Title = Model.Title,
                Text = Model.Text,
                AuthorId = LoggedInUser.UserId,
                CategoryId = Model.CategoryId,
                ImgUrl = image
            };

            var result = postAppService.Create(newPost);
            if (result.IsSuccess)
            {
                return RedirectToPage("/Authors/Posts");
            }
            else
            {
                Message = result.Message;
                Categories = categoryAppService.GetCategoriesByAuthorId(LoggedInUser.UserId);
                return Page();
            }

        }
    }
}

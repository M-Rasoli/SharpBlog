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
    public class EditPostModel
    {
        public int Id { get; set; }              
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ExistingImageUrl { get; set; }  
        public IFormFile Image { get; set; }
    }
    public class EditModel(IPostAppService postAppService
        , ICategoryAppService categoryAppService,
        IFileService fileService) 
        : PageModel
    {
        [BindProperty]
        public EditPostModel Model { get; set; }
        public List<GetCategoriesDto> Categories { get; set; }
        public string Message { get; set; }
        public IActionResult OnGet(int id)
        {
            var result = postAppService.GetPostById(id);
            if (result == null)
            {
                return NotFound();
            }

            Model = new EditPostModel()
            {
                Id = result.Id,
                Category = result.Category,
                Title = result.Title,
                Text = result.Text,
                ExistingImageUrl = result.ImgUrl
            };
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

            UpdatePostDto post = new UpdatePostDto()
            {
                Id = Model.Id,
                Title = Model.Title,
                Text = Model.Text,
                CategoryId = Model.CategoryId ,
                ImgUrl = image ?? Model.ExistingImageUrl
            };
            var result = postAppService.Update(post);
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

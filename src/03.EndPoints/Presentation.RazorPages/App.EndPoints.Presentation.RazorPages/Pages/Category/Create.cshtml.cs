using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.EndPoints.Presentation.RazorPages.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Category
{
    public class CreateCategoryModel
    {
        public string Title { get; set; }
    }
    public class CreateModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public CreateCategoryModel Model { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            CreateCategoryDto category = new CreateCategoryDto()
            {
                Title = Model.Title,
                AuthorId = LoggedInUser.UserId
            };
            var result = categoryAppService.Create(category);
            if (result.IsSuccess)
            {
                return RedirectToPage("/Authors/Categories");
            }
            else
            {
                Message = result.Message;
                return Page();
            }
        }
    }
}

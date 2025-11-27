using App.Domain.AppService.CategoryAgg;
using App.Domain.AppService.PostAgg;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.EndPoints.Presentation.RazorPages.Pages.Posts;
using App.EndPoints.Presentation.RazorPages.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace App.EndPoints.Presentation.RazorPages.Pages.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class EditModel(ICategoryAppService categoryAppService) : PageModel
    {
        [BindProperty]
        public EditCategoryViewModel Model { get; set; }
        public string Message { get; set; }
        public IActionResult OnGet(int id)
        {
            var result = categoryAppService.GetCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }

            Model = new EditCategoryViewModel()
            {
                Id = result.Data.Id,
                Title = result.Data.Title,
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            UpdateCategoryDto category = new UpdateCategoryDto()
            {
                Id = Model.Id,
                Title = Model.Title,
            };
            var result = categoryAppService.Update(category);
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

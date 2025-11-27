using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.EndPoints.Presentation.RazorPages.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Authors
{
    public class CategoriesModel(ICategoryAppService categoryAppService) : PageModel
    {
        public List<GetCategoriesDto> Categories { get; set; }
        public IActionResult OnGet()
        {
            Categories = categoryAppService.GetCategoriesByAuthorId(LoggedInUser.UserId);
            return Page();
        }
    }
}

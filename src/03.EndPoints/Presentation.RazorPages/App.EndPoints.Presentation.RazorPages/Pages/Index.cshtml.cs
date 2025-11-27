using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages
{
    public class IndexModel(IPostAppService postAppService, ICategoryAppService categoryAppService) : PageModel
    {
        public List<GetPostForFeedsDto> Feeds { get; set; }
        public List<GetCategoriesDto> Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? CategoryFilter { get; set; }
        public IActionResult OnGet()
        {
            Feeds = postAppService.GetFeedPosts(CategoryFilter);
            Categories = categoryAppService.GetAll();
            return Page();
        }
    }
}

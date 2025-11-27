using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Posts
{
    public class WithDetailsModel(IPostAppService postAppService) : PageModel
    {
        public GetPostForFeedsDto Post { get; set; }
        public IActionResult OnGet(int Id)
        {
            Post = postAppService.GetPostById(Id);
            return Page();
        }
    }
}

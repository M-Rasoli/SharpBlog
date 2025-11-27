using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.EndPoints.Presentation.RazorPages.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Authors
{
    public class PostsModel(IPostAppService postAppService) : PageModel
    {
        public List<GetPostsByAuthorId> Posts { get; set; }
        public IActionResult OnGet()
        {
            Posts = postAppService.GetPostsByAuthorId(LoggedInUser.UserId);
            return Page();
        }
    }
}

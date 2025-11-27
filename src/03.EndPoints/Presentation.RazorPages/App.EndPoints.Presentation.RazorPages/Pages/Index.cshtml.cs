using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages
{
    public class IndexModel(IPostAppService postAppService) : PageModel
    {
        public List<GetPostForFeedsDto> Feeds { get; set; }
        public void OnGet()
        {
            Feeds = postAppService.GetFeedPosts();
        }
    }
}

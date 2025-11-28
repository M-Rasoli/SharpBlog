using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Authors
{
    public class PostCommentsModel(ICommentAppService commentAppService) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public List<GetCommentsDto> Comments { get; set; } = new List<GetCommentsDto>();
        public string PostTitle { get; set; }
        [BindProperty]
        public CommentStatusEnum Status { get; set; }
        public int PostId { get; set; }


        public void OnGet(int Id)
        {
            this.Id = Id;
            PostTitle = "jsj";
            Comments = commentAppService.GetCommentsByPostIdForAuthor(Id);
        }

        public IActionResult OnPostChangeStatus(int cmId)
        {
            var result = commentAppService.ChangeStatus(cmId, Status); 
            return RedirectToPage(new { Id });
        }
    }
}

using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Comments
{
    public class ListModel(ICommentAppService commentAppService) : PageModel
    {
        public List<GetCommentsDto> Comments { get; set; } = new();
        public int PostId { get; set; }
        public void OnGet(int Id)
        {
            PostId = Id;
            Comments = commentAppService.GetCommentsByPostId(Id);
        }
    }
}


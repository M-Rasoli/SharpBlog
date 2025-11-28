using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.EndPoints.Presentation.RazorPages.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Comments
{
    public class CreateCommentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Rate { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
    }
    public class CreateModel(ICommentAppService commentAppService) : PageModel
    {
        [BindProperty] 
        public CreateCommentViewModel Model { get; set; } = new CreateCommentViewModel();

        public string Message { get; set; }
        public void OnGet(int Id)
        {
            Model.PostId = Id;
        }

        public IActionResult OnPost()
        {
            if (!EmailValidation.IsEmailValid(Model.Email))
            {
                Message = "فرمت ورودی ایمیل نامعتبر است.";
                return Page();
            }

            CreateCommentDto comment = new CreateCommentDto()
            {
                FirstName = Model.FirstName,
                LastName = Model.LastName,
                Email = Model.Email,
                CommentText = Model.CommentText,
                PostId = Model.PostId,
                Rate = Model.Rate
            };

            var result = commentAppService.Create(comment);
            if (result.IsSuccess)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Message = result.Message;
                return Page();
            }

        }
    }
}

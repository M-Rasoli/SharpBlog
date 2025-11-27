using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Account
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel(IAuthorAppService authorAppService) : PageModel
    {
        [BindProperty]
        public RegisterViewModel Model { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            RegisterAuthorDto newAuthor = new RegisterAuthorDto()
            {
                UserName = Model.UserName,
                Password = Model.Password
            };
            var result = authorAppService.Register(newAuthor);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage("/Account/Login");
            }
            else
            {
                Message = result.Message;
                return Page();
            }
        }
    }
}

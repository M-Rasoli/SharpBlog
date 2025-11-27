using App.Domain.Core.AuthorAgg.Contracts;
using App.EndPoints.Presentation.RazorPages.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.RazorPages.Pages.Account
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginModel(IAuthorAppService authorAppService) : PageModel
    {
        [BindProperty]
        public LoginViewModel Model { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var result = authorAppService.Login(Model.UserName, Model.Password);

            if (result.IsSuccess)
            {

                LoggedInUser.UserId = result.Data.Id;
                LoggedInUser.UserName = result.Data.UserName;

                return RedirectToPage("/Authors/Index");
            }
            else
            {
                Message = result.Message;
            }

            return Page();

        }
    }
}

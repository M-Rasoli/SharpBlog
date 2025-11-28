using System.Text.RegularExpressions;

namespace App.EndPoints.Presentation.RazorPages.Tools
{
    public static class EmailValidation
    {
        public static bool IsEmailValid(string emailAddress)
        {
            // Source - https://stackoverflow.com/a
            // Posted by Parimal Raj, modified by community. See post 'Timeline' for change history
            // Retrieved 2025-11-28, License - CC BY-SA 3.0
            if (string.IsNullOrWhiteSpace(emailAddress))
                return false;

            bool isEmail = Regex.IsMatch(emailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
    }
}

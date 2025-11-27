using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.AuthorAgg.Dtos
{
    public class LoginUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

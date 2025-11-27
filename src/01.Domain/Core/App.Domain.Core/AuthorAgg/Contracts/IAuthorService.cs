using App.Domain.Core.AuthorAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.AuthorAgg.Contracts
{
    public interface IAuthorService
    {
        public int Register(RegisterAuthorDto user);
        public LoginUserDto? Login(string userName);
        public bool IsUserNameExist(string userName);
    }
}

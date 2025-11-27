using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;

namespace App.Domain.Service.AuthorAgg
{
    public class AuthorService(IAuthorRepository authorRepository):IAuthorService
    {
        public int Register(RegisterAuthorDto user)
        {
            return authorRepository.Register(user);
        }

        public LoginUserDto? Login(string userName)
        {
            return authorRepository.Login(userName);
        }

        public bool IsUserNameExist(string userName)
        {
            return authorRepository.IsUserNameExist(userName);
        }
    }
}

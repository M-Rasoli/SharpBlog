using App.Domain.Core._Common.Entities;
using App.Domain.Core.AuthorAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.AuthorAgg.Contracts
{
    public interface IAuthorAppService
    {
        public Result<bool> Register(RegisterAuthorDto user);
        public Result<LoginUserDto> Login(string userName, string password);
    }
}

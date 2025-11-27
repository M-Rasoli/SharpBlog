using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;
using App.Domain.Core.AuthorAgg.Entities;
using App.Infrastructure.EfCore.Persistence;

namespace App.Infrastructure.EfCore.Repositories.AuthorAgg
{
    public class AuthorRepository(AppDbContext _context) : IAuthorRepository
    {
        public bool IsUserNameExist(string userName)
        {
            return _context.Authors.Any(u => u.UserName.ToLower() == userName.ToLower());
        }

        public LoginUserDto? Login(string userName)
        {
            return _context.Authors.Where(u => u.UserName.ToLower() == userName.ToLower())
                .Select(x => new LoginUserDto()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password

                }).FirstOrDefault();
        }

        public int Register(RegisterAuthorDto user)
        {
            Author newUser = new Author()
            {
                UserName = user.UserName,
                Password = user.Password
            };

            _context.Authors.Add(newUser);
            return _context.SaveChanges();
        }
    }
}

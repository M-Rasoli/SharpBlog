using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.AuthorAgg.Dtos;

namespace App.Domain.AppService.AuthorAgg
{
    public class AuthorAppService(IAuthorService authorService) : IAuthorAppService
    {
        public Result<LoginUserDto> Login(string userName, string password)
        {
            var user = authorService.Login(userName);
            if (user is null)
            {
                return Result<LoginUserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }

            if (user.Password != password)
            {
                return Result<LoginUserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                return Result<LoginUserDto>.Success(message: "خوش آمدید", user);
            }
        }

        public Result<bool> Register(RegisterAuthorDto user)
        {
            if (user.UserName == null ||
                user.Password == null)
            {
                return Result<bool>.Failure(message: "فیلد های اجباری باید کامل شوند.");
            }
            if (authorService.IsUserNameExist(user.UserName))
            {
                return Result<bool>.Failure(message: "نام کاربری قبلا استفاده شده است.");
            }

            if (user.Password.Length < 3)
            {
                return Result<bool>.Failure(message: "رمز عبور حداقل باید شامل 3 کاراکتر باشد.");
            }

            var result = authorService.Register(user);
            if (result > 0)
            {
                return Result<bool>.Success(message: "ثبت نام با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده لحظاتی بعد تلاش کنید.");
            }
        }
    }
}

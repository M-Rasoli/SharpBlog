using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.AppService.CategoryAgg
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId)
        {
            return categoryService.GetCategoriesByAuthorId(authorId);
        }

        public Result<bool> Create(CreateCategoryDto createCategory)
        {
            if (string.IsNullOrWhiteSpace(createCategory.Title))
            {
                return Result<bool>.Failure(message:"عنوان نمیتواند خالی باشد.");
            }
            var result = categoryService.Create(createCategory);
            if (result > 0)
            {
                return Result<bool>.Success(message: "دسته بندی با موفقیت ایجاد شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");

            }
        }
    }
}

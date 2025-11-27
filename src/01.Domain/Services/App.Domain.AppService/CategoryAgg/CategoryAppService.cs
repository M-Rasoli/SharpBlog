using App.Domain.Core._Common.Entities;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace App.Domain.AppService.CategoryAgg
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        private ICategoryAppService _categoryAppServiceImplementation;

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

        public Result<bool> Update(UpdateCategoryDto updateCategory)
        {
            if (string.IsNullOrWhiteSpace(updateCategory.Title))
            {
                return Result<bool>.Failure(message: "فیلذ های اجباری نمیتوانند خالی باشند.");
            }

            var result = categoryService.Update(updateCategory);
            if (result > 0)
            {
                return Result<bool>.Success(message: "تغییرات با موفقیت اعمال شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");
            }
        }

        public Result<GetCategoriesDto> GetCategoryById(int categoryId)
        {
            var result = categoryService.GetCategoryById(categoryId);
            if (result is not null)
            {
                return Result<GetCategoriesDto>.Success(message: "", result);
            }
            else
            {
                return Result<GetCategoriesDto>.Failure(message: "دسنه بندی با ایدی مورد نظر پیدا نشد.");
            }
        }

        public Result<bool> Delete(int categoryId)
        {
            var result = categoryService.Delete(categoryId);
            if (result > 0)
            {
                return Result<bool>.Success(message: "دسته بندی با موفقیت حذف شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");
            }
        }

        public List<GetCategoriesDto> GetAll()
        {
            return categoryService.GetAll();
        }
    }
}

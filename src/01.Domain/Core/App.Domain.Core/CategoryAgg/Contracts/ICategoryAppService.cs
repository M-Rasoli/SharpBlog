using App.Domain.Core.CategoryAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;

namespace App.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryAppService
    {
        List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId);
        Result<bool> Create(CreateCategoryDto createCategory);
        Result<bool> Update(UpdateCategoryDto updateCategory);
        Result<GetCategoriesDto> GetCategoryById(int categoryId);
        Result<bool> Delete(int categoryId);
        List<GetCategoriesDto> GetAll();
    }
}

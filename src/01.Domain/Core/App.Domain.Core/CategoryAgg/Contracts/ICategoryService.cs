using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryService
    {
        List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId);
        List<GetCategoriesDto> GetAll();
        int Create(CreateCategoryDto createCategory);
        GetCategoriesDto GetCategoryById(int categoryId);
        int Update(UpdateCategoryDto updateCategory);
        int Delete(int categoryId);
    }
}

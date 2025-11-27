using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId);
        GetCategoriesDto GetCategoryById(int categoryId);
        int Create (CreateCategoryDto createCategory);
        int Update(UpdateCategoryDto updateCategory);
        int Delete(int categoryId);
        List<GetCategoriesDto> GetAll();
    }
}

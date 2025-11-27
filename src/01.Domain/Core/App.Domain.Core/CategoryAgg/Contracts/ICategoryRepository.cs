using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId);
        int Create (CreateCategoryDto createCategory);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;

namespace App.Domain.Service.CategoryAgg
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId)
        {
            return categoryRepository.GetCategoriesByAuthorId(authorId);
        }

        public int Create(CreateCategoryDto createCategory)
        {
            return categoryRepository.Create(createCategory);
        }
    }
}

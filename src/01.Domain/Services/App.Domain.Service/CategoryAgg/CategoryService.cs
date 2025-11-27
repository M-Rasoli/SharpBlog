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

        public List<GetCategoriesDto> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public int Create(CreateCategoryDto createCategory)
        {
            return categoryRepository.Create(createCategory);
        }

        public GetCategoriesDto GetCategoryById(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }

        public int Update(UpdateCategoryDto updateCategory)
        {
            return categoryRepository.Update(updateCategory);
        }

        public int Delete(int categoryId)
        {
            return categoryRepository.Delete(categoryId);
        }

        public GetCategoriesDto GetCategoriesById(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }
    }
}

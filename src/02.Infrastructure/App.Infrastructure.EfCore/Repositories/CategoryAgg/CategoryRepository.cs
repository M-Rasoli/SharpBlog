using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.EfCore.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public List<GetCategoriesDto> GetCategoriesByAuthorId(int authorId)
        {
            return _context.Categories
                .Where(c => c.AuthorId == authorId)
                .Select(x => new GetCategoriesDto()
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }

        public GetCategoriesDto GetCategoryById(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId)
                .Select(x => new GetCategoriesDto()
                {
                    Id = x.Id,
                    Title = x.Title
                }).FirstOrDefault();
        }

        public int Create(CreateCategoryDto createCategory)
        {
            Category category = new Category()
            {
                Title = createCategory.Title,
                AuthorId = createCategory.AuthorId
            };
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public int Update(UpdateCategoryDto updateCategory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == updateCategory.Id);
            if (category is null)
            {
                return 0;
            }
            else
            {
                category.Title = updateCategory.Title;
                return _context.SaveChanges();
            }
        }

        public int Delete(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId)
                .ExecuteDelete();
        }

        public List<GetCategoriesDto> GetAll()
        {
            return _context.Categories
                .Select(x => new GetCategoriesDto()
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }
    }
}

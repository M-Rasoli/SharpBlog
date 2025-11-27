using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infrastructure.EfCore.Persistence;

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
    }
}

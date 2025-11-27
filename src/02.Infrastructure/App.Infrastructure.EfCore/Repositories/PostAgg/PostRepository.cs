using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;
using App.Domain.Core.PostAgg.Entities;
using App.Infrastructure.EfCore.Persistence;
using MaktabGram.Framework;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EfCore.Repositories.PostAgg
{
    public class PostRepository(AppDbContext _context) : IPostRepository
    {
        public List<GetPostForFeedsDto> GetFeedPosts()
        {
            return _context.Posts.AsNoTracking()
                .OrderByDescending(p => p.CreatedAt)
                .Select(x => new GetPostForFeedsDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    ImgUrl = x.ImgUrl,
                    CreatedAt = x.CreatedAt,
                    CreatedAtShamsi = x.CreatedAtShamsi,
                    Category = x.Category.Title

                }).ToList();
        }

        public int Create(CreatePostDto createPost)
        {
            Post newPost = new Post()
            {
                AuthorId = createPost.AuthorId,
                CategoryId = createPost.CategoryId,
                Title = createPost.Title,
                Text = createPost.Text,
                ImgUrl = createPost.ImgUrl ?? null,
                CreatedAt = DateTime.Now,
                CreatedAtShamsi = DateTime.Now.ToPersianString("yyyy/MM/dd")
            };
            _context.Posts.Add(newPost);
            return _context.SaveChanges();

        }

        public List<GetPostsByAuthorId> GetPostsByAuthorId(int authorId)
        {
            return _context.Posts.Where(p => p.AuthorId == authorId)
                .Select(x => new GetPostsByAuthorId()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    ImgUrl = x.ImgUrl,
                    CreatedAt = x.CreatedAt,
                    CreatedAtShamsi = x.CreatedAtShamsi,
                    Category = x.Category.Title

                }).ToList();

        }

        public GetPostForFeedsDto GetPostById(int postId)
        {
            return _context.Posts
                .Where(p => p.Id == postId)
                .Select(x => new GetPostForFeedsDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    ImgUrl = x.ImgUrl,
                    Category = x.Category.Title

                }).FirstOrDefault();
        }

        public int Update(UpdatePostDto updatePost)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == updatePost.Id);
            if (post is null)
            {
                return 0;
            }
            else
            {
                post.Title = updatePost.Title;
                post.Text = updatePost.Text;
                post.CategoryId = updatePost.CategoryId;
                post.ImgUrl = updatePost.ImgUrl ?? post.ImgUrl;
                return _context.SaveChanges();
            }
        }
    }
}

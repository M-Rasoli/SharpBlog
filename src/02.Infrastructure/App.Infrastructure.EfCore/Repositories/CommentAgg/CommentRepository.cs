using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Dtos;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Entities;
using App.Domain.Core.CommentAgg.Enums;
using App.Infrastructure.EfCore.Persistence;

namespace App.Infrastructure.EfCore.Repositories.CommentAgg
{
    public class CommentRepository(AppDbContext _context) : ICommentRepository
    {
        public int Create(CreateCommentDto createComment)
        {
            Comment comment = new Comment()
            {
                PostId = createComment.PostId,
                FirstName = createComment.FirstName,
                LastName = createComment.LastName,
                Email = createComment.Email,
                Rate = createComment.Rate,
                CommentText = createComment.CommentText,
                Status = CommentStatusEnum.Pending,
                CreatedAt = DateTime.Now
            };
            _context.Comments.Add(comment);
            return _context.SaveChanges();
        }

        public int ChangeStatus(int commentId, CommentStatusEnum status)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null)
            {
                return 0;
            }
            else
            {
                comment.Status = status;
                return _context.SaveChanges();
            }
        }

        public List<GetCommentsDto> GetCommentsByPostId(int postId)
        {
            return _context.Comments
                .Where(c => c.PostId == postId && c.Status == CommentStatusEnum.Confirmed)
                .Select(x => new GetCommentsDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    CommentText = x.CommentText,
                    Rate = x.Rate,
                    PostId = x.PostId,
                    CreatedAt = x.CreatedAt,
                    PostTitle = x.Post.Title,
                    Status = x.Status
                }).ToList();
        }

        public List<GetCommentsDto> GetCommentsByPostIdForAuthor(int postId)
        {
            return _context.Comments
                .Where(c => c.PostId == postId)
                .Select(x => new GetCommentsDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    CommentText = x.CommentText,
                    Rate = x.Rate,
                    PostId = x.PostId,
                    CreatedAt = x.CreatedAt,
                    PostTitle = x.Post.Title,
                    Status = x.Status
                }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enums;

namespace App.Domain.Service.CommentAgg
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        public int Create(CreateCommentDto createComment)
        {
            return commentRepository.Create(createComment);
        }

        public int ChangeStatus(int commentId, CommentStatusEnum status)
        {
            return commentRepository.ChangeStatus(commentId, status);
        }

        public List<GetCommentsDto> GetCommentsByPostId(int postId)
        {
            return commentRepository.GetCommentsByPostId(postId);
        }

        public List<GetCommentsDto> GetCommentsByPostIdForAuthor(int postId)
        {
            return commentRepository.GetCommentsByPostIdForAuthor(postId);
        }
    }
}

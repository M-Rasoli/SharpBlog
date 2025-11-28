using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enums;

namespace App.Domain.Core.CommentAgg.Contracts
{
    public interface ICommentRepository
    {
        int Create(CreateCommentDto createComment);
        int ChangeStatus(int commentId , CommentStatusEnum status);
        List<GetCommentsDto> GetCommentsByPostId(int postId);
        List<GetCommentsDto> GetCommentsByPostIdForAuthor(int postId);
    }
}

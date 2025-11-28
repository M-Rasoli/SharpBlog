using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.CommentAgg.Contracts
{
    public interface ICommentService
    {
        int Create(CreateCommentDto createComment);
        int ChangeStatus(int commentId, CommentStatusEnum status);
        List<GetCommentsDto> GetCommentsByPostId(int postId);
        List<GetCommentsDto> GetCommentsByPostIdForAuthor(int postId);
    }
}

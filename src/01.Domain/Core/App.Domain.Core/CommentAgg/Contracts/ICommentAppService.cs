using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;

namespace App.Domain.Core.CommentAgg.Contracts
{
    public interface ICommentAppService
    {
        Result<bool> Create(CreateCommentDto createComment);
        Result<bool> ChangeStatus(int commentId, CommentStatusEnum status);
        List<GetCommentsDto> GetCommentsByPostId(int postId);
        List<GetCommentsDto> GetCommentsByPostIdForAuthor(int postId);
    }
    
}

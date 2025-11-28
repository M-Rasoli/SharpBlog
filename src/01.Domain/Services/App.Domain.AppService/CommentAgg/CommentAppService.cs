using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.CommentAgg.Dtos;
using App.Domain.Core.CommentAgg.Enums;

namespace App.Domain.AppService.CommentAgg
{
    public class CommentAppService(ICommentService commentService) : ICommentAppService
    {
        public Result<bool> Create(CreateCommentDto createComment)
        {
            if (string.IsNullOrWhiteSpace(createComment.FirstName)
                || string.IsNullOrWhiteSpace(createComment.LastName)
                || string.IsNullOrWhiteSpace(createComment.Email)
                || string.IsNullOrWhiteSpace(createComment.CommentText))
            {
                return Result<bool>.Failure(message: "فیلد های اجباری نمی توانند خالی باشند.");
            }

            if (createComment.Rate < 0 || createComment.Rate > 5)
            {
                return Result<bool>.Failure(message:"امتیاز باید بیان اعداد 1 تا 5 باشد.");
            }

            var result = commentService.Create(createComment);
            if (result > 0)
            {
                return Result<bool>.Success(message:"کامنت با موفقیت ثبت شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");
            }
        }

        public Result<bool> ChangeStatus(int commentId, CommentStatusEnum status)
        {
            var result = commentService.ChangeStatus(commentId, status);

            if (result > 0)
            {
                return Result<bool>.Success(message: "تغییرات با موفقیت اعمال شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");
            }

        }

        public List<GetCommentsDto> GetCommentsByPostId(int postId)
        {
            return commentService.GetCommentsByPostId(postId);
        }

        public List<GetCommentsDto> GetCommentsByPostIdForAuthor(int postId)
        {
            return commentService.GetCommentsByPostIdForAuthor(postId);
        }
    }
}

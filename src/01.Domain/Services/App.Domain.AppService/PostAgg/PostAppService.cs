using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;

namespace App.Domain.AppService.PostAgg
{
    public class PostAppService(IPostService postService) : IPostAppService
    {
        public List<GetPostForFeedsDto> GetFeedPosts()
        {
            return postService.GetFeedPosts();
        }

        public Result<bool> Create(CreatePostDto createPost)
        {
            var result = postService.Create(createPost);
            if (result > 0)
            {
                return Result<bool>.Success(message: "پست با موفقیت ایجاد شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");
            }
        }

        public List<GetPostsByAuthorId> GetPostsByAuthorId(int authorId)
        {
            return postService.GetPostsByAuthorId(authorId);
        }

        public GetPostForFeedsDto GetPostById(int postId)
        {
            return postService.GetPostById(postId);
        }

        public Result<bool> Update(UpdatePostDto updatePost)
        {
            if (string.IsNullOrWhiteSpace(updatePost.Title)
                || string.IsNullOrWhiteSpace(updatePost.Text)
                || updatePost.CategoryId == 0)
            {
                return Result<bool>.Failure(message: "فیلد های اجباری نمی توانند خالی باشند.");
            }
            var result = postService.Update(updatePost);
            if (result > 0)
            {
                return Result<bool>.Success(message: "تغییرات با موفقیت اعمال شد.");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده است لحظاتی بعد تلاش کنید.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.PostAgg.Dtos;

namespace App.Domain.Core.PostAgg.Contracts
{
    public interface IPostAppService
    {
        List<GetPostForFeedsDto> GetFeedPosts();
        Result<bool> Create(CreatePostDto createPost);
        List<GetPostsByAuthorId> GetPostsByAuthorId(int authorId);
        GetPostForFeedsDto GetPostById(int postId);
        Result<bool> Update(UpdatePostDto updatePost);
    }
}

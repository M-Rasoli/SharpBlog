using App.Domain.Core.PostAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.PostAgg.Contracts
{
    public interface IPostService
    {
        List<GetPostForFeedsDto> GetFeedPosts(string categoryFilter);
        int Create(CreatePostDto createPost);
        List<GetPostsByAuthorId> GetPostsByAuthorId(int authorId);
        GetPostForFeedsDto GetPostById(int postId);
        int Update(UpdatePostDto updatePost);
        int Delete(int postId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Core.PostAgg.Dtos;

namespace App.Domain.Service.PostAgg
{
    public class PostService(IPostRepository postRepository): IPostService
    {
        public List<GetPostForFeedsDto> GetFeedPosts()
        {
            return postRepository.GetFeedPosts();
        }

        public int Create(CreatePostDto createPost)
        {
            return postRepository.Create(createPost);
        }

        public List<GetPostsByAuthorId> GetPostsByAuthorId(int authorId)
        {
            return postRepository.GetPostsByAuthorId(authorId);
        }

        public GetPostForFeedsDto GetPostById(int postId)
        {
            return postRepository.GetPostById(postId);
        }

        public int Update(UpdatePostDto updatePost)
        {
            return postRepository.Update(updatePost);
        }
    }
}

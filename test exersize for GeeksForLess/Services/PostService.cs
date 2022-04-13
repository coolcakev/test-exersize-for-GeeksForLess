using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Entity;
using test_exersize_for_GeeksForLess.Models.PostModels;

namespace test_exersize_for_GeeksForLess.Services
{
    public interface IPostService
    {
        Task<Post> Create(CreatePostModel model);
        Task Update(UpdatePostModel model);
    }
    public class PostService : IPostService
    {
        private readonly ApplicationContext _repository;

        public PostService(ApplicationContext repository)
        {
            _repository = repository;
        }

        public async Task<Post> Create(CreatePostModel model)
        {
            if (model.TopicId < 0)
                return null;

            var post = new Post
            {
                Body = model.Body,
                CreateDateTime = DateTime.Now,
                UserId = model.UserId,
                TopicId = model.TopicId

            };
            _repository.Posts.Add(post);
            await _repository.SaveChangesAsync();
            return post;
        }

        public async Task Update(UpdatePostModel model)
        {
            if (model.PostId < 0)
                return;

            var post = _repository.Posts.SingleOrDefault(post => post.Id == model.PostId);

            if (post == null)
                return;

            post.Body = model.Body;
            _repository.Update(post);
            await _repository.SaveChangesAsync();
        }
    }
}

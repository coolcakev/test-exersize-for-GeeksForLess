using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Entity;
using test_exersize_for_GeeksForLess.Models.TopicModels;

namespace test_exersize_for_GeeksForLess.Services
{
    public interface ITopicService
    {

        Task FillIndexTopicModel(IndexTopicModel model);
        Task<Topic> Create(CreateTopicModel model);
    }
    public class TopicService : ITopicService
    {
        private readonly ApplicationContext _reposetory;

        public TopicService(ApplicationContext reposetory)
        {
            _reposetory = reposetory;
        }

        public async Task<Topic> Create(CreateTopicModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Body))
                return null;

            if (string.IsNullOrWhiteSpace(model.Body))
                return null;

            var topic = new Topic
            {
                Body = model.Body,
                Title = model.Title,
                UserId = model.UserId

            };

            _reposetory.Topics.Add(topic);
            await _reposetory.SaveChangesAsync();
            return topic;
        }

        public async Task FillIndexTopicModel(IndexTopicModel model)
        {
            model.Topic = _reposetory.Topics.Include(x=>x.Posts).SingleOrDefault(x=>x.Id==model.TopicId);            
        }
    }
}

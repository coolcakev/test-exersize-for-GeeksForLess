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
        Task<bool> Update(UpdateTopicModel model);
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
                UserId = model.UserId,
                CreationDate=DateTime.Now
                
            };

            _reposetory.Topics.Add(topic);
            await _reposetory.SaveChangesAsync();
            return topic;
        }

        public async Task FillIndexTopicModel(IndexTopicModel model)
        {
            model.Topic = _reposetory.Topics.Include(x=>x.Posts).ThenInclude(x=>x.User).SingleOrDefault(x=>x.Id==model.TopicId);            
        }

        public async Task<bool> Update(UpdateTopicModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Body))
                return false;

            if (string.IsNullOrWhiteSpace(model.Title))
                return false;

            var topic = _reposetory.Topics.Include(x=>x.Posts).SingleOrDefault(x=>x.Id==model.TopicId);

            if (topic == null)
                return false;

            topic.Title = model.Title;
            topic.Body = model.Body;

            _reposetory.Update(topic);
            await _reposetory.SaveChangesAsync();

            return true;
        }
    }
}

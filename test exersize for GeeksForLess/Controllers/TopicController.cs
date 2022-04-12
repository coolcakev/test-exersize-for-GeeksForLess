using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Models.TopicModels;
using test_exersize_for_GeeksForLess.Services;

namespace test_exersize_for_GeeksForLess.Controllers
{
    [Route("[controller]/[action]")]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult Index(int topicId)
        {
            var model = new IndexTopicModel();
            model.TopicId = topicId;
            _topicService.FillIndexTopicModel(model);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTopicModel model)
        {

            model.UserId = int.Parse(User.FindFirst(x => x.Type == "UserId").Value);
            var topic = await _topicService.Create(model);
            if (topic==null)
                return NotFound();

            var responceModel = new ResponceCreateTopicModel();
            responceModel.Topic = topic;
            responceModel.CurrentUrlTopic = Url.Action("Index",new { topicId = topic.Id});
            return Ok(responceModel);
        }
    }
}

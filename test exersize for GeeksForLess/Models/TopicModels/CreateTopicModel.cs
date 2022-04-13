using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Entity;

namespace test_exersize_for_GeeksForLess.Models.TopicModels
{
    public class CreateTopicModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }

    }
    public class ResponceCreateTopicModel
    {
        public Topic Topic { get; set; }
        public string CurrentUrlTopic { get; set; }
        public string CreationDate { get; set; }


    }

}

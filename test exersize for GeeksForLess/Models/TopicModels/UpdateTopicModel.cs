using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_exersize_for_GeeksForLess.Models.TopicModels
{
    public class UpdateTopicModel
    {
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}

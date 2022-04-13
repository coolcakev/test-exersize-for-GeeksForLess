using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Entity;

namespace test_exersize_for_GeeksForLess.Models.PostModels
{
    public class CreatePostModel
    {
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
    }
    public class ResponseCreatePostModel
    {
        public Post Post { get; set; }
        public string CreationDate { get; set; }
    }
}

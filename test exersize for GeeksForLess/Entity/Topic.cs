using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_exersize_for_GeeksForLess.Entity
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

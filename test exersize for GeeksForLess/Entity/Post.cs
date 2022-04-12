using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_exersize_for_GeeksForLess.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string  Body { get; set; }
        public DateTime  CreateDateTime { get; set; }
    }
}

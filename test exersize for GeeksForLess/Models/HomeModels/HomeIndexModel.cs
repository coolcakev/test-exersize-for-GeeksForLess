using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Entity;

namespace test_exersize_for_GeeksForLess.Models.HomeModels
{
    public class HomeIndexModel
    {
        public IEnumerable<Topic> Topics { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Models.PostModels;
using test_exersize_for_GeeksForLess.Services;

namespace test_exersize_for_GeeksForLess.Controllers
{
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePostModel model)
        {
            model.UserId = int.Parse(User.FindFirst(x=>x.Type== "UserId").Value);
           var post=await _postService.Create(model);
            var responceModel = new ResponseCreatePostModel()
            {
                Post=post,
                CreationDate=post.CreateDateTime.ToString("dd/MM/yyyy, H:mm")
            };
            return Ok(responceModel);
          
        }
        [HttpPost]
        public IActionResult Update([FromBody] UpdatePostModel model)
        {          
            _postService.Update(model);
            return Ok();
        }
    }
}

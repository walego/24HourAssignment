using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _24Hour.Models;
using _24Hour.Services;
using Microsoft.AspNet.Identity;

namespace _24HourAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        //this will allow us to use out post service in our methods
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
        //Post a post
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePostService();
            if (!service.CreatePost(post))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //Get All
        public IHttpActionResult GetAll()
        {
            PostService service = CreatePostService();
            var posts = service.GetPosts();
            return Ok(posts);
        }
        //Get By AuthorId
        public IHttpActionResult GetById(int id)
        {
            PostService service = CreatePostService();
            var post = service.GetPostById(id);
            return Ok(post);
        }
    }
}

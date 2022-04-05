using _24Hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourAPI.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
       private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new LikeService(userId);
            return noteService;
        }
    }
}

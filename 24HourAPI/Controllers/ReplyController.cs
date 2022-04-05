using _24Hour.Models;
using _24Hour.Services;
<<<<<<< HEAD
=======
using Microsoft.AspNet.Identity;
>>>>>>> 02315e90a9cd32aa3d0c04a9a07c1380e629e072
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourAPI.Controllers
{
    public class ReplyController : ApiController
    {

        public IHttpActionResult Get()
        {
<<<<<<< HEAD
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReply();
            return Ok(reply);
        }

        private ReplyService CreateReplyService()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
=======
            ReplyService replyService = CreateReply();
            var reply = replyService.GetReply();
            return Ok(reply);
        }
        public IHttpActionResult Get(int id)
        {
            ReplyService replyService= CreateReply();
>>>>>>> 02315e90a9cd32aa3d0c04a9a07c1380e629e072
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD
            var service = CreateReplyService();
=======
            var service = CreateReply();
>>>>>>> 02315e90a9cd32aa3d0c04a9a07c1380e629e072

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }
<<<<<<< HEAD
=======

        private ReplyService CreateReply()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

>>>>>>> 02315e90a9cd32aa3d0c04a9a07c1380e629e072
    }
}


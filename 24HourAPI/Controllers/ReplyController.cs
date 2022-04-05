using _24Hour.Models;
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
    public class ReplyController : ApiController
    {

        public IHttpActionResult Get()
        {
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

            
            var reply = replyService.GetReply();
            return Ok(reply);
        }
       
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var service = CreateReplyService();

            


            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }



        private ReplyService CreateReply()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

    }
}
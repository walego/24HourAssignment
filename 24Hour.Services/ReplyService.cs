using _24Hour.Models;
using _24Hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace _24Hour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate reply)
        {
            var entity = new Data.Reply()
            {
                ReplyId = reply.ReplyId,
                Text = reply.Text,
                AuthorId = _userId,
                CommentId = reply.CommentId

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListAll> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                        e => new ReplyListAll()
                        {
                            ReplyId = e.ReplyId,
                            Text = e.Text,
                            CommentId = e.CommentId
                        }

                        );
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == id && e.AuthorId == _userId);
                return
                     new ReplyDetail
                     {
                         ReplyId = entity.ReplyId,
                         Text = entity.Text,
                         CommentId = entity.CommentId
                     };
            }
        }
    }
}

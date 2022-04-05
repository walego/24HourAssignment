﻿using _24Hour.Data;
using _24Hour.Models;
using _24HourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorId = _userId,
                Text = model.Text,



            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.AuthorId == _userId)
                    .Select(e => new CommentListItem
                    {
                        CommentId = e.CommentId,
                        Text = e.Text,
                    }
                    );
                return query.ToArray();
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == model.CommentId && e.AuthorId == _userId);
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public CommentDetail GetCommentsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == id && e.AuthorId == _userId);
                return new CommentDetail
                {
                    CommentId = entity.CommentId,
                    Text = entity.Text,
                };
            }
        }
        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == commentId && e.AuthorId == _userId);
                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
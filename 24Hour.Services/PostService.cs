using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24Hour.Data;
using _24Hour.Models;
using _24HourAPI.Models;

namespace _24Hour.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = model.Title,
                Text = model.Text
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(e => e.AuthorId == _userId).Select(e => new PostListItem
                {
                    UserId = e.UserId,
                    Title = e.Title,

                }
                );
                return query.ToArray();

            }
        }
        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.UserId == id && e.AuthorId == _userId);
                return
                    new PostDetail
                    {
                        UserId = entity.UserId,
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }
    }
}
using _24Hour.Data;
using _24Hour.Models.Likes;
using _24HourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                OwnerId = _userId,
                PostId = model.PostId,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    internal class Post
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        //public virtual List<Comment> Comments { get; set; }
        //public virtual List<Like> Likes { get; set; }
        public Guid AuthorId { get; set; }
    }
}

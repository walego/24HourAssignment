using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        [Range(1, 100, ErrorMessage = "Please Choose A Number Between 1 & 100.")]
        [MaxLength(100, ErrorMessage = "There Are To Many Characters In This Field.")]
        [Display(Name = "Comment")]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        public virtual List<Reply> Replys { get; set; } = new List<Reply>();

        [ForeignKey(nameof(PostId))]
        public virtual Post PostId { get; set; }

        [ForeignKey(nameof(Post))]
        public virtual Post Post { get; set; }
 
    }
}
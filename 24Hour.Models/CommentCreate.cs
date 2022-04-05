using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter At Least Two Characters.")]
        [MaxLength(100, ErrorMessage = "Too Many Characters!")]
        public string Text { get; set; }
        [MaxLength(8000)]
        public Guid AuthorId { get; set; }
    }
}
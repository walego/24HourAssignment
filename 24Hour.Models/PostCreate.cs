using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter atleast 2 characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string Title { get; set; }
        [MaxLength(5000, ErrorMessage = "There are too many characters in this field")]
        public string Text { get; set; }
    }
}

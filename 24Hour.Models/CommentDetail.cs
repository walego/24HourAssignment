using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Content { get; set; }
    }
}
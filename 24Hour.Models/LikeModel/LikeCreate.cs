using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Likes
{
    public class LikeCreate
    {
        [Required]
        public int PostId { get; set; }
    }

    //boom
}

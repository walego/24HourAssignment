﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post LikedPost { get; set; }
    }
}

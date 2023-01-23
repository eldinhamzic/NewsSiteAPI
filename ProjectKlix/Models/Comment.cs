using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectKlix.Models
{
    public partial class Comment
    {

        [Key]
        public int Id { get; set; }
        public string Text { get; set; } 
        public int UserId { get; set; }
        public int NewsId { get; set; }

      
    }
}

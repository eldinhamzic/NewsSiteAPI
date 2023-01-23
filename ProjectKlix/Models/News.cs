using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProjectKlix.Models;

namespace ProjectKlix.Models
{
    public class News
    {

        [Key]
        public int NewsId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Photo { get; set; } 
        public DateTime DateAndTime { get; set; }
        public string Content { get; set; } 
     

        public virtual Author? Author { get; set; }
      
        
    }
}

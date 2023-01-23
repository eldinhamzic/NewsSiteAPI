using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectKlix.Models
{
    public partial class Author
    {
     
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } 
        public string Code { get; set; } 

        
    }
}

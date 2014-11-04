using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Browar.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
       
        // Klucze obce
        public int UserId { get; set; }
        public User User { get; set; }

        public int PiwoId { get; set; }
        public Piwo Piwo { get; set; }
    }
}
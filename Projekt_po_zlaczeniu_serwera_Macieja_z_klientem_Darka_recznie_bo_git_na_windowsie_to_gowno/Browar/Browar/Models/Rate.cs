using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Browar.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rate
    {
        public int Id { get; set; }
        [Required]
        public int Value { get; set; }

        // Klucze obce
        public int UserId { get; set; }
        public User User { get; set; }

        public int PiwoId { get; set; }
        public Piwo Piwo { get; set; }
    }
}
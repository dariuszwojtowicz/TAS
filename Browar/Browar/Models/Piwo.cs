using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Browar.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Piwo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Power { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }

        // Foreign Key
        public int BrowarniaId { get; set; }
        // Navigation property
        public Browarnia Browarnia { get; set; }
    }
}
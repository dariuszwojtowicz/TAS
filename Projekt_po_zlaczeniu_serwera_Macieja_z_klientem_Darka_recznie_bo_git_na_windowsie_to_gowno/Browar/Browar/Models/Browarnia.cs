using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Browar.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Browarnia
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }     
    }
}
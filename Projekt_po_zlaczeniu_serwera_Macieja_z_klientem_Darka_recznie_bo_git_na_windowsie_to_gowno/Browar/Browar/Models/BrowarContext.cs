﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Browar.Models
{
    public class BrowarContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BrowarContext() : base("name=BrowarContext")
        {
        }

        public System.Data.Entity.DbSet<Browar.Models.Browarnia> Browarnias { get; set; }

        public System.Data.Entity.DbSet<Browar.Models.Piwo> Piwoes { get; set; }

        public System.Data.Entity.DbSet<Browar.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Browar.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Browar.Models.Rate> Rates { get; set; }
    
    }
}

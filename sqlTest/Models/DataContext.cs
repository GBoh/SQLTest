using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sqlTest.Models {
    public class DataContext : DbContext {
        public IDbSet<Movie> Movies { get; set; }
    }
}
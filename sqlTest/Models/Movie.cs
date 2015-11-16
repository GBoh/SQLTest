using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sqlTest.Models {
    public class Movie {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie must have a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must include a director")]
        public string Director { get; set; }

        public string Description { get; set; }

    }
}
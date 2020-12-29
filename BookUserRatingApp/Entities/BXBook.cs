namespace BookUserRatingApp.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BXBook
    {
        [Key]
        [StringLength(13)]
        public string ISBN { get; set; }

        [StringLength(255)]
        public string BookTitle { get; set; }

        [StringLength(255)]
        public string BookAuthor { get; set; }

        public int? YearOfPublication { get; set; }

        [StringLength(255)]
        public string Publisher { get; set; }

        [StringLength(255)]
        public string ImageURLS { get; set; }

        [StringLength(255)]
        public string ImageURLM { get; set; }

        [StringLength(255)]
        public string ImageURLL { get; set; }
    }
}

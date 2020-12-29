namespace BookUserRatingApp.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [MaxLength(50)]
        public byte[] State { get; set; }

        [MaxLength(50)]
        public byte[] Country { get; set; }

        public int? Age { get; set; }
    }
}

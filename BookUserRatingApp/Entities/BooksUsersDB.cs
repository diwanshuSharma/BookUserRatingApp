using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookUserRatingApp.Entities
{
    public partial class BooksUsersDB : DbContext
    {
        public BooksUsersDB()
            : base("name=BooksUsersDB")
        {
        }

        public virtual DbSet<BXBookRating> BXBookRatings { get; set; }
        public virtual DbSet<BXBook> BXBooks { get; set; }
        public virtual DbSet<BXUser> BXUsers { get; set; }
}

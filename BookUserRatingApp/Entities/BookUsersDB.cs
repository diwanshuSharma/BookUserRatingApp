using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookUserRatingApp.Entities
{
    public partial class BookUsersDB : DbContext
    {
        public BookUsersDB()
            : base("name=BookUsersDB")
        {
        }

        public virtual DbSet<BXBookRating> BXBookRatings { get; set; }
        public virtual DbSet<BXBook> BXBooks { get; set; }
        public virtual DbSet<BXUser> BXUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BXBookRating>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.BookTitle)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.BookAuthor)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.Publisher)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.ImageURLS)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.ImageURLM)
                .IsUnicode(false);

            modelBuilder.Entity<BXBook>()
                .Property(e => e.ImageURLL)
                .IsUnicode(false);

            modelBuilder.Entity<BXUser>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<BXUser>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<BXUser>()
                .Property(e => e.Country)
                .IsUnicode(false);
        }
    }
}

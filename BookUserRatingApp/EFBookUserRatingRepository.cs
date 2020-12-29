using System;
using System.Collections.Generic;
using System.Text;
using BookUserRatingApp.Entities;
using System.Linq;

namespace BookUserRatingRepository
{
    class EFBookUserRatingRepository : IBookUserRatingRepository
    {
        public List<BXBook> GetAllBooks()
        {
            var db = new BookUsersDB();
            return db.BXBooks.ToList();
        }

        public List<BXBookRating> GetAllBooksRatedByUser(int id)
        {
            var db = new BookUsersDB();
            return db.BXBookRatings.Where(x => x.UserID == id).Select(x => x).ToList();
        }

        public List<BXUser> GetAllUser()
        {
            var db = new BookUsersDB();
            return db.BXUsers.ToList();
        }

        public List<BXBookRating> GetTopRatedBooks()
        {
            var db = new BookUsersDB();
            return db.BXBookRatings.OrderByDescending(x => x.BookRating).Take(10).Select(x => x).ToList();
        }
    }
}

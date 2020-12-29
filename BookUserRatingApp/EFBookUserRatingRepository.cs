using System;
using System.Collections.Generic;
using System.Text;
using UserBooks;
using BookUserRatingApp.Entities;

namespace BookUserRatingRepository
{
    class EFBookUserRatingRepository : IBookUserRatingRepository
    {
        public List<BXBook> GetAllBooks()
        {
            var db = new BooksUsersDB();
            var books = db.BXBooks;
        }

        public List<BXBookRating> GetAllBooksRatedByUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<BXUser> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public List<BXBookRating> GetTopRatedBooks()
        {
            throw new NotImplementedException();
        }
    }
}

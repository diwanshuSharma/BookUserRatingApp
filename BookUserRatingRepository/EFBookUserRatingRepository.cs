using System;
using System.Collections.Generic;
using System.Text;
using UserBooks;

namespace BookUserRatingRepository
{
    class EFBookUserRatingRepository : IBookUserRatingRepository
    {
        public List<BXBook> GetAllBooks()
        {
            throw new NotImplementedException();
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

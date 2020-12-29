using System;
using System.Collections.Generic;
using System.Text;
using UserBooks;

namespace BookUserRatingRepository
{
    interface IBookUserRatingRepository
    {
        List<BXBook> GetAllBooks();
        List<BXUser> GetAllUser();
        List<BXBookRating> GetTopRatedBooks();
        List<BXBookRating> GetAllBooksRatedByUser(int id);
    }
}

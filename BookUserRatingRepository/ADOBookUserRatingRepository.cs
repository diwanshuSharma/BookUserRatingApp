using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using UserBooks;

namespace BookUserRatingRepository
{
    public class ADOBookUserRatingRepository : IBookUserRatingRepository
    {
        DbProviderFactory factory;
        IDbConnection connection = null;

        private void GetConection(out IDbConnection connection) {
            string provider = ConfigurationManager.ConnectionStrings["default"].;
            
        }

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

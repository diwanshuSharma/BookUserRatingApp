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
        
        private static void GetConection(out IDbConnection connection, out DbProviderFactory factory) {
            
            string provider = ConfigurationManager.ConnectionStrings["default"].ProviderName;
            factory = DbProviderFactories.GetFactory(provider);
            
            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            
        }

        public List<BXBook> GetAllBooks()
        {
            IDbConnection connection = null;
            DbProviderFactory factory;
            GetConection(out connection, out factory);

            using (connection)
            {
               
                string sqlSelect = "select * from BXBooks";

                IDbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = sqlSelect;
                connection.Open();

                IDataReader reader = command.ExecuteReader();

                List<BXBook> books = new List<BXBook>();

                while (reader.Read())
                {
                    BXBook book = new BXBook();

                    book.ISBN = reader["ISBN"].ToString();
                    book.BookTitle = reader["BookTitle"].ToString();
                    book.BookAuthor = reader["BookAuthor"].ToString();
                    book.YearOfPublication = Int32.Parse(reader["YearOfPublication"].ToString());
                    book.Publisher = reader["Publisher"].ToString();
                    book.ImageURLL = reader["ImageURLL"].ToString();
                    book.ImageURLM = reader["ImageURLM"].ToString();
                    book.ImageURLL = reader["ImageURLL"].ToString();

                    books.Add(book);

                }

                return books;
            }
        }

        public List<BXBookRating> GetAllBooksRatedByUser(int id)
        {
            IDbConnection connection;
            DbProviderFactory factory;
            GetConection(out connection, out factory);

            string sqlSelect = "SELECT * FROM BXBookRatings WHERE UserID = @id";

            IDbCommand command = factory.CreateCommand();
            command.CommandText = sqlSelect;
            command.Connection = connection;

            // setting up 'id' parameter
            DbParameter parameter = factory.CreateParameter();
            parameter.Value = id;
            parameter.ParameterName = "@id";
            command.Parameters.Add(parameter);

            List<BXBookRating> ratings = new List<BXBookRating>();

            using (connection)
            {

                connection.Open();
                IDataReader reader = command.ExecuteReader();

                if (reader.FieldCount != 0)
                {
                    while (reader.Read())
                    {
                        BXBookRating rating = new BXBookRating();

                        rating.Userid = Convert.ToInt32(reader[0].ToString());
                        rating.ISBN = reader[1].ToString();
                        rating.BookRating = Convert.ToInt32(reader[2].ToString());
                        ratings.Add(rating);
                    }
                }
            }

            return ratings;
        }

        public List<BXUser> GetAllUser()
        {
            IDbConnection connection;
            DbProviderFactory factory;
            GetConection(out connection, out factory);

            string sqlSelect = "SELECT * FROM BXUsers";

            IDbCommand command = factory.CreateCommand();
            command.CommandText = sqlSelect;
            command.Connection = connection;

            List<BXUser> users = new List<BXUser>();

            using (connection)
            {
                connection.Open();
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BXUser user = new BXUser();

                    user.UserID = Int32.Parse(reader[0].ToString());
                   
                    user.Location = reader[1].ToString();
                   
                    string tempAge = reader[2].ToString();

                    // -1 define : if age is null
                    if (tempAge.Length == 0 || tempAge == null)
                        user.Age = -1;
                    else
                        user.Age = Int32.Parse(tempAge);

                    users.Add(user);
                }
            }

            return users;
        }

        public List<BXBookRating> GetTopRatedBooks()
        {
            IDbConnection connection;
            DbProviderFactory factory;
            GetConection(out connection, out factory);

            string sqlSelect = "SELECT top 10 * " +
                "from BXBookRatings " +
                "order by BookRating desc";

            IDbCommand command = factory.CreateCommand();
            command.CommandText = sqlSelect;
            command.Connection = connection;

            List<BXBookRating> ratings = new List<BXBookRating>();

            using (connection)
            {
                connection.Open();
                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BXBookRating rating = new BXBookRating();

                    rating.Userid = Int32.Parse(reader[0].ToString());
                    rating.ISBN = reader[1].ToString();
                    rating.BookRating = Int32.Parse(reader[2].ToString());

                    ratings.Add(rating);
                }
            }

            return ratings;
        }
    }
}

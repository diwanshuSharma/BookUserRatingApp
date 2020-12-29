using BookUserRatingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBooks;

namespace BookUserRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ADOBookUserRatingRepository ADO = new ADOBookUserRatingRepository();

            while (true)
            {

                Console.WriteLine("\n\n\n------------------------------------");
                Console.WriteLine("Choose from the options : ");
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. Show books rated by user");
                Console.WriteLine("3. Show all users");
                Console.WriteLine("4. Show top rated books");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                int e = int.Parse(Console.ReadLine());

                switch (e)
                {
                    case 1: ShowAllBooks(ADO); break;
                    case 2: ShowAllBooksRatedByUser(ADO); break;
                    case 3: ShowAllUser(ADO); break;
                    case 4: ShowTopRatedBooks(ADO); break;
                    case 5: return;
                }
            }

            Console.ReadLine();

        }

        private static void ShowAllBooks(in ADOBookUserRatingRepository ADO)
        {
            List<BXBook> books = ADO.GetAllBooks();

            foreach (var book in books)
            {
                Console.WriteLine($"\n{book.ISBN}\t" +
                    $"{book.BookTitle}\t" +
                $"{book.BookAuthor}\t" +
                $"{book.Publisher}\t" +
                $"{book.YearOfPublication}\t"
                );
            }
        }

        private static void ShowAllBooksRatedByUser(in ADOBookUserRatingRepository ADO)
        {
            Console.Write("User ID : ");
            int id = Int32.Parse(Console.ReadLine());

            List<BXBookRating> records = ADO.GetAllBooksRatedByUser(id);

            if (records.Count != 0)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("UserID\tISBN\tBookRating");
                Console.WriteLine("----------------------------------");
                foreach (var row in records)
                {
                    Console.WriteLine($"\n{row.Userid}\t" +
                            $"{row.ISBN}\t" +
                            $"{row.BookRating}"
                        );
                }
                Console.WriteLine("----------------------------------");
            }
            else
                Console.WriteLine("No record Found !!!");
            
        }

        private static void ShowAllUser(in ADOBookUserRatingRepository ADO)
        {
            List<BXUser> records = ADO.GetAllUser();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("UserID\tAge\tLocation");
            Console.WriteLine("-------------------------------------");
            foreach (var row in records)
            {
                Console.WriteLine($"\n{row.UserID}\t" +
                        $"{row.Age}\t" +
                        $"{row.Location}"
                    );
            }
            Console.WriteLine("-------------------------------------");
        }

        private static void ShowTopRatedBooks(in ADOBookUserRatingRepository ADO)
        {
            List<BXBookRating> records = ADO.GetTopRatedBooks();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("UserID\tISBN\t\tBookRating");
            Console.WriteLine("-------------------------------------");
            foreach (var row in records)
            {
                Console.WriteLine($"\n{row.Userid}\t" +
                        $"{row.ISBN}\t" +
                        $"{row.BookRating}"
                    );
            }
            Console.WriteLine("-------------------------------------");

        }
    }
}

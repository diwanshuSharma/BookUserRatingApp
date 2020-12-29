using BookUserRatingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookUserRatingApp.Entities;

namespace BookUserRatingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ADOBookUserRatingRepository ADO = new ADOBookUserRatingRepository();
            EFBookUserRatingRepository EF = new EFBookUserRatingRepository();

            int choice = 0;

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
                    case 1:
                        Console.WriteLine("1. ADO (or)\n 2. EF ");
                        Console.Write("Choice : ");
                        choice = Int32.Parse(Console.ReadLine());
                        if(choice == 1)
                        ShowAllBooks(ADO); 
                        else if(choice == 2)
                            ShowAllBooks(EF);
                        break;

                    case 2:
                        Console.WriteLine("1. ADO (or)\n 2. EF ");
                        Console.Write("Choice : ");
                        choice = Int32.Parse(Console.ReadLine());
                        if (choice == 1) 
                            ShowAllBooksRatedByUser(ADO);
                        else if (choice == 2)
                            ShowAllBooksRatedByUser(EF);
                        break;
                    case 3:
                        Console.WriteLine("1. ADO (or)\n 2. EF ");
                        Console.Write("Choice : ");
                        choice = Int32.Parse(Console.ReadLine());
                        if (choice == 1) 
                            ShowAllUser(ADO);
                        else if (choice == 2)
                            ShowAllUser(EF);
                        break;
                    case 4:
                        Console.WriteLine("1. ADO (or)\n 2. EF ");
                        Console.Write("Choice : ");
                        choice = Int32.Parse(Console.ReadLine());
                        if (choice == 1) 
                            ShowTopRatedBooks(ADO);
                        else if (choice == 2)
                            ShowTopRatedBooks(EF);
                        break;
                    case 5: return;
                }
            }

            
            //Console.ReadLine();

        }

        private static void ShowAllBooks(in IBookUserRatingRepository Repository)
        {
            List<BXBook> books = Repository.GetAllBooks();

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

        private static void ShowAllBooksRatedByUser(in IBookUserRatingRepository Repository)
        {
            Console.Write("User ID : ");
            int id = Int32.Parse(Console.ReadLine());

            List<BXBookRating> records = Repository.GetAllBooksRatedByUser(id);

            if (records.Count != 0)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("UserID\tISBN\tBookRating");
                Console.WriteLine("----------------------------------");
                foreach (var row in records)
                {
                    Console.WriteLine($"\n{row.UserID}\t" +
                            $"{row.ISBN}\t" +
                            $"{row.BookRating}"
                        );
                }
                Console.WriteLine("----------------------------------");
            }
            else
                Console.WriteLine("No record Found !!!");
            
        }

        private static void ShowAllUser(in IBookUserRatingRepository Repository)
        {
            List<BXUser> records = Repository.GetAllUser();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("UserID\tAge\tCity\tState\tCountry");
            Console.WriteLine("-------------------------------------");
            foreach (var row in records)
            {
                Console.WriteLine($"\n{row.UserID}\t" +
                        $"{row.Age}\t" +
                        $"{row.City}\t"+
                        $"{row.State}\t"+
                        $"{row.Country}"
                    );
            }
            Console.WriteLine("-------------------------------------");
        }

        private static void ShowTopRatedBooks(in IBookUserRatingRepository Repository)
        {
            List<BXBookRating> records = Repository.GetTopRatedBooks();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("UserID\tISBN\t\tBookRating");
            Console.WriteLine("-------------------------------------");
            foreach (var row in records)
            {
                Console.WriteLine($"\n{row.UserID}\t" +
                        $"{row.ISBN}\t" +
                        $"{row.BookRating}"
                    );
            }
            Console.WriteLine("-------------------------------------");

        }
    }
}

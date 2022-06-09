/* OUTLINE
do
{ 
1.Display the entire list of books.  Format it nicely. // display method
  a.Display Book Number, Book Title, Author, Status and Due Date 
2.	Search for a book //search method
  a.	By Author
  b.	By Title keyword
3.	Select a Book from the list //select method
  a.	If not a valid book, display error and prompt user for another choice or display the list.
  b.   If it’s already checked out, let them know.
  c.   If not, check it out to them and set the due date to 2 weeks from today.
4.	Return a book (we can decide how that works/questions to ask) //return a book method
  a.Ask which book they want to return
  b.	If book isn’t checked out, give error
  c.	If book is checked out: 
          i.update status 
          ii.	clear out due date. 
5.	Exit – Hit enter to exit
) while (continueRunning = true) 
*/

// TO DO:
// consistant spacing/line breaks
// export book list to txt file
// fix selection from search results list
// after burning, list is empty unless searching w/ no results

using System;
using System.Collections.Generic;
using System.Linq;
// using System.IO;

namespace LibraryTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> libraryBooks = buildLibrary();
            bool continueRunning = true;
            bool burnedDown = false;
            Console.WriteLine("Welcome to the C Sharts Library!");
            while (continueRunning)
            {
                Console.WriteLine("Please Enter Your Selection:\n");
                Console.WriteLine("1. Display The List of Books");
                Console.WriteLine("2. Search by Title or Author");
                Console.WriteLine("3. Select a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("or hit 'enter' to quit.");
                string response = Console.ReadLine();
                if (response == "1")
                {
                    displayList(libraryBooks);
                }
                else if (response == "2")
                {
                    searchBook(libraryBooks);
                }
                else if (response == "3")
                {
                    // check for redundancies
                    displayList(libraryBooks);
                    selectBook(libraryBooks);
                }
                else if (response == "4")
                {
                    returnBook(libraryBooks);
                }
                else if (response == "light a match")
                {
                    burnBooks(libraryBooks);
                    burnedDown = true;
                    break;
                }
                else if (String.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Goodbye!");
                    // save book list
                    continueRunning = false;

                }
                else
                {
                    Console.WriteLine("Invalid Selection.\n");
                }
            }
            while (burnedDown == true)
            {
                Console.WriteLine("Please Enter Your Selection:\n");
                Console.WriteLine("1. Display The List of Books");
                Console.WriteLine("or hit 'enter' to quit.");
                string response = Console.ReadLine();
                if (response == "1")
                {
                    displayList(libraryBooks);
                }
                else if (String.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Goodbye!");
                    // save book list
                    continueRunning = false;
                    break;

                }
                else
                {
                    Console.WriteLine("Invalid Selection.\n");
                }
            }
        }
        public static List<Book> buildLibrary()
        {
            var booksList = new List<Book>();
            Book newBook = null;
            newBook = new Book(1, "A Time to Kill", "John Grisham", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(2, "East of Eden", "John Steinbeck", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(3, "Number the Stars", "Lois Lowry", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(4, "The Fault in our Stars", "John Green", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(5, "Green Eggs and Ham", "Dr. Seuss", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(6, "In Cold Blood", "Truman Capote", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(7, "Band of Brothers", "Stephen E. Ambrose", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(8, "The Dark Tower", "Stephen King", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(9, "Charlottes Web", "E.B. White", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(10, "Gone with the Wind", "Margaret Mitchel", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(11, "The Grapes of Wrath", "John Steinbeck", false, new DateTime());
            booksList.Add(newBook);
            newBook = new Book(12, "A Farewell to Arms", "Ernest Hemingway", false, new DateTime());
            booksList.Add(newBook);
            return booksList;
        }
        public class Book
        {
            public int BookNum { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool CheckedOutStatus { get; set; }
            public DateTime? DueDate { get; set; }
            public Book(int newBookNum, string newTitle, string newAuthor, bool newStatus, DateTime newDate)
            {
                BookNum = newBookNum;
                Title = newTitle;
                Author = newAuthor;
                CheckedOutStatus = newStatus;
                DueDate = newDate;
            }
        }
        public static void saveList(List<Book> myBooks)
        {
            // File.WriteAllLines("SavedLists.txt", myBooks);
        }
        public static void burnBooks(List<Book> myBooks)
        {
            myBooks.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string textToEnter = @"

               (  .      )
           )           (              )
                 .  '   .   '  .  '  .
        (    , )       (.   )  (   ',    )
         .' ) ( . )    ,  ( ,     )   ( .
      ). , ( .   (  ) ( , ')  .' (  ,    )
     (_,) . ), ) _) _,')  (, ) '. )  ,. (' )
   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                ";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Congratulations. You have burned every single book to a crisp.");
            Console.WriteLine("Hate to break it to you, but the C Sharts library was actually");
            Console.WriteLine("the Library of Alexandria. People are gunna be pretty mad...");
            Console.WriteLine();
        }
        public static void displayList(List<Book> myBooks)
        {
            Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", "", "Title", "Author", "Status", "Return Date"));
            Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", "", "=====", "======", "======", "==========="));
            for (int i = 0; i < myBooks.Count; i++)
            {
                int bookNum = i + 1;
                string status;

                if (myBooks[i].CheckedOutStatus == true)
                {
                    status = "Not Available";
                    Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", $"{bookNum}: ", $"{myBooks[i].Title} ", $"{myBooks[i].Author} ", $"{status}", $"{ myBooks[i].DueDate:MM/dd/yyyy}"));
                }
                else
                {
                    status = "Available";
                    Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", $"{bookNum}: ", $"{myBooks[i].Title} ", $"{myBooks[i].Author} ", $"{status}", ""));
                }
            }
            Console.WriteLine();
        }
        public static void searchBook(List<Book> myBooks)
        {
            // TO DO
            // Option to select and check out from results list
            Console.WriteLine();
            Console.WriteLine("Would you like to search Titles or Authors?");
            string titlesOrAuthors = Console.ReadLine().ToLower();
            if (titlesOrAuthors == "titles")
            {
                Console.WriteLine();
                Console.WriteLine("Enter a keyword to lookup a title:");
                string keyword = Console.ReadLine();
                List<Book> searchResult = myBooks.Where(Book => Book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                if (searchResult.Count > 0)
                {
                    Console.WriteLine("Results found:");
                    Console.WriteLine();
                    Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", "", "Title", "Author", "Status", "Return Date"));
                    Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", "", "=====", "======", "======", "==========="));
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        int bookNum = i + 1;
                        string status;

                        if (searchResult[i].CheckedOutStatus == true)
                        {
                            status = "Not Available";
                            Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", $"{bookNum}: ", $"{searchResult[i].Title} ", $"{searchResult[i].Author} ", $"{status}", $"{ searchResult[i].DueDate:MM/dd/yyyy}"));
                        }
                        else
                        {
                            status = "Available";
                            Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", $"{bookNum}: ", $"{searchResult[i].Title} ", $"{searchResult[i].Author} ", $"{status}", ""));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to check any of these / this book out (y/n)?");
                    // fix that wording^
                    string answerSearchCheckout = Console.ReadLine().ToLower();
                    // do we use string?^^
                    if (answerSearchCheckout == "y")
                    {
                        selectBook(searchResult);
                        Console.WriteLine();
                    }
                    else if (answerSearchCheckout == "n")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No matches found. Here is a list of our books:");
                    List<Book> libraryBooks = buildLibrary();
                    displayList(libraryBooks);
                }
            }
            else if (titlesOrAuthors == "authors")
            {
                Console.WriteLine("Enter a first, last, or full name to lookup an Author:");
                string keyword = Console.ReadLine();
                List<Book> searchResult = myBooks.Where(Book => Book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
                if (searchResult.Count > 0)
                {
                    Console.WriteLine("Results found:");
                    Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", "", "Title", "Author", "Status", "Return Date"));
                    Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", "", "=====", "======", "======", "==========="));
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        int bookNum = i + 1;
                        string status;

                        if (searchResult[i].CheckedOutStatus == true)
                        {
                            status = "Not Available";
                            Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", $"{bookNum}: ", $"{searchResult[i].Title} ", $"{searchResult[i].Author} ", $"{status}", $"{ searchResult[i].DueDate:MM/dd/yyyy}"));
                        }
                        else
                        {
                            status = "Available";
                            Console.WriteLine(string.Format("{0,-4}{1,-30}{2,-25}{3,-20}{4,-20}", $"{bookNum}: ", $"{searchResult[i].Title} ", $"{searchResult[i].Author} ", $"{status}", ""));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                // re-run searchBook ?
            }
        }
        public static void selectBook(List<Book> myBooks)
        {
            bool continueSelection = true;

            while (continueSelection)
            {
                try
                {
                    Console.WriteLine("Enter your choice by book number:");
                    string choice = Console.ReadLine();
                    int choiceInt;
                    bool isValidInt = int.TryParse(choice, out choiceInt);
                    if (String.IsNullOrEmpty(choice) || (isValidInt == false))
                    {
                        Console.WriteLine("Invalid Input. Returning to Main Menu.\n");
                        continueSelection = false;
                    }
                    else if (choiceInt < 0 || choiceInt > myBooks.Count)
                    {
                        Console.WriteLine("Invalid Input. Returning to Main Menu.\n");
                        continueSelection = false;
                    }
                    else if (isValidInt)
                    {
                        Book selectedBook = myBooks.Where(Book => Book.BookNum == choiceInt).FirstOrDefault();
                        if (selectedBook != null)
                        {
                            Console.WriteLine($"You've selected {selectedBook.Title}. Would you like to check it out? (y/n)");
                            string userSelection = Console.ReadLine().ToUpper();
                            if (userSelection == "Y")
                            {
                                selectedBook.DueDate = DateTime.Today.AddDays(14);
                                Console.WriteLine($"Enjoy {selectedBook.Title} it is due back {selectedBook.DueDate:MM/dd/yyyy}");
                                selectedBook.CheckedOutStatus = true;
                            }
                            else
                            {
                                Console.WriteLine("Book not checked out. \n");
                            }
                            Console.WriteLine("Would you like to check out another book? (y/n)");
                            string answer = Console.ReadLine().ToUpper();
                            if (answer != "Y")
                            {
                                continueSelection = false;
                            }
                            else if ((answer != "Y") && (answer != "N"))
                            {
                                Console.WriteLine("Invalid Response.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You did not select a valid book from our library.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return;
        }
        public static void returnBook(List<Book> myBooks)
        {
            bool continueReturns = true;
            while (continueReturns)
            {
                try
                {
                    Console.WriteLine("Enter the number of the book do you want to return?");
                    string choice = Console.ReadLine();
                    int choiceInt;

                    bool isValidInt = int.TryParse(choice, out choiceInt);

                    if (String.IsNullOrEmpty(choice) || (isValidInt == false))
                    {
                        Console.WriteLine("Invalid Input. Returning to the Main Menu\n");
                        continueReturns = false;
                    }
                    else if (choiceInt < 0 || choiceInt > myBooks.Count)
                    {
                        Console.WriteLine("Invalid Book Number. Please enter a book number from our library\n");
                        continueReturns = false;
                    }
                    else if (isValidInt)
                    {
                        Book selectedBook = myBooks.Where(Book => Book.BookNum == choiceInt).FirstOrDefault();
                        if (selectedBook != null)
                        {
                            Console.WriteLine($"You chose: {selectedBook.BookNum} {selectedBook.Title}");
                            if (selectedBook.CheckedOutStatus == false)
                            {
                                Console.WriteLine("This book is already in our library. You must've checked it out from a different branch.\n" +
                                    "Returning to the Main Menu.\n");
                                continueReturns = false;
                            }
                            else
                            {
                                Console.WriteLine("Would you like to return this book? (y/n)");
                                string ans = Console.ReadLine().ToUpper();
                                if (ans == "Y")
                                {
                                    if (selectedBook.CheckedOutStatus == true)
                                    {
                                        selectedBook.CheckedOutStatus = false;
                                        selectedBook.DueDate = null;
                                        Console.WriteLine($" { selectedBook.BookNum}. { selectedBook.Title} - Successfully Returned.");
                                    }
                                    else { Console.WriteLine("This book isn't checked out so you can't return it."); }
                                }
                                Console.WriteLine("Would you like to return another book? (y/n)");
                                ans = Console.ReadLine().ToUpper();
                                if (ans == "N")
                                {
                                    continueReturns = false;
                                }
                                else if ((ans != "Y") && (ans != "N"))
                                {
                                    Console.WriteLine("Invalid Response.");
                                }
                            }
                        }
                    }
                    else continueReturns = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
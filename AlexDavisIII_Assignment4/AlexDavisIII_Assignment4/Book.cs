using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Book
    {
        private string callNumber;
        private string bookTitle;
        private string authorName;
        private string genre;
        private int numberOfPages;
        private string publisher;

        public Book(string theNumber, string theTitle, string theAuthor, string theGenre, int thePages, string thePublisher)
        {
            theNumber = callNumber;
            theTitle = bookTitle;
            theAuthor = authorName;
            theGenre = genre;
            thePages = numberOfPages;
            thePublisher = publisher;
    
        }

        public string CallNumber
        {
            get { return callNumber; }
            set { callNumber = value;}
        }

        public string BookTitle
        {
            get { return bookTitle; }
            set { bookTitle = value; }
        }

        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public int NumberOfPages
        {
            get { return numberOfPages; }
            set { numberOfPages = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
    }


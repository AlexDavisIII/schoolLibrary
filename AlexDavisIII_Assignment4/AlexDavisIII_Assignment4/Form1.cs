//Name: Alex Davis III
//Course: CIS 199

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlexDavisIII_Assignment4
{
    public partial class Form1 : Form
    {
        private TextBox[] textboxes;
        private Label[] labels;
        private List<Book> listOfBooks; //holds references to Book Objects

        //Lists below hold specific attributes
        private List<string> listofBookElements;
        private List<string> listofCallNumbers;
        private List<string> listofAuthors;
        private List<string> listofGenre;
        private List<string> listofPublishers;
        private List<double> listofFileSize;

        private Book theBook;
        private eBook theEBook;


        public Form1()
        {
            InitializeComponent();
            textboxes = new TextBox[] { txtCallNumber, txtBookTitle, txtAuthorName, txtGenre, txtNumberOfPages, txtPublisher };
            labels = new Label[] { lblCallNumber, lblbookTitle, lblAuthorName, lblGenre, lblNumberOfPages, lblPublisher };
            listOfBooks = new List<Book>();
            listofBookElements = new List<string>();
            listofFileSize = new List<double>();
            txtFileSize.Enabled = false;
        }

        private void AddBook(string theCall, string theTitle, string theName, string theGenre, int thePages, string thePublisher)
        {
            //creates a new book object
            theBook = new Book(theCall, theTitle, theName, theGenre, thePages, thePublisher);

            theBook.CallNumber = theCall;
            theBook.BookTitle = theTitle;
            theBook.AuthorName = theName;
            theBook.Genre = theGenre;
            theBook.NumberOfPages = thePages;
            theBook.Publisher = thePublisher;

            listOfBooks.Add(theBook);
        }

        private void AddeBook(string theCall, string theTitle, string theName, string theGenre, int thePages, string thePublisher, double theSize)
        {
            theEBook = new eBook(theCall,theTitle, theName, theGenre, thePages, thePublisher, theSize);

            theEBook.CallNumber = theCall;
            theEBook.BookTitle = theTitle;
            theEBook.AuthorName = theName;
            theEBook.Genre = theGenre;
            theEBook.NumberOfPages = thePages;
            theEBook.Publisher = thePublisher;
            theEBook.Filesize = theSize;

            listOfBooks.Add(theEBook);
           
        }

        private void PopulateListBox(List<Book> aBook, ListBox aListBox)
        {
            aListBox.Items.Clear();

            
            foreach (Book book in aBook)
            {
                //adds the Author Name to the Book Catalog
                aListBox.Items.Add(book.AuthorName);


                //adds call number, author name, genre, and publisher to another list
                listofBookElements.Add(book.CallNumber);
                listofBookElements.Add(book.AuthorName);
                listofBookElements.Add(book.Genre);
                listofBookElements.Add(book.Publisher);

                //Adds everything to a designated list
                listofCallNumbers = new List<string>();
                listofCallNumbers.Add(book.CallNumber);

                listofAuthors = new List<string>();
                listofAuthors.Add(book.AuthorName);

                listofGenre = new List<string>();
                listofGenre.Add(book.Genre);

                listofPublishers = new List<string>();
                listofPublishers.Add(book.Publisher);


            }
        }

        //Adds an entire book
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chbEBook.Checked)
            {
                AddeBook(txtCallNumber.Text, txtBookTitle.Text, txtAuthorName.Text, txtGenre.Text, int.Parse(txtNumberOfPages.Text), txtPublisher.Text, double.Parse(txtFileSize.Text));
           
            }
            else
            {

                AddBook(txtCallNumber.Text, txtBookTitle.Text, txtAuthorName.Text, txtGenre.Text, int.Parse(txtNumberOfPages.Text)
                    , txtPublisher.Text);                      
            }
            PopulateListBox(listOfBooks, lstCatalog);
            DoAnother();
            txtCallNumber.Focus();
        }

        //Clears contents of Textboxes and Labels
        private void DoAnother()
        {
            foreach (TextBox text in textboxes)
            {
                text.Clear();
            }

            foreach (Label label in labels)
            {
                label.Text = "";
            }
        }


        private Book GetBookInfo(int index)
        {
            return listOfBooks[index]; //returns reference 
        }

        //outputs data into the labels of the second tab
        private void BookInfo(int Index)
        {
            lblCallNumber.Text = listOfBooks[Index].CallNumber;
            lblbookTitle.Text = listOfBooks[Index].BookTitle;
            lblAuthorName.Text = listOfBooks[Index].AuthorName;
            lblGenre.Text = listOfBooks[Index].Genre;
            lblNumberOfPages.Text = listOfBooks[Index].NumberOfPages.ToString();
            lblPublisher.Text = listOfBooks[Index].Publisher;
        }


        //outputs data into the labels of the third tab
        private void BookInfoSearch(int Index)
        {
            lblSearchCall.Text = listOfBooks[Index].CallNumber;
            lblSeachTitle.Text = listOfBooks[Index].BookTitle;
            lblSearchName.Text = listOfBooks[Index].AuthorName;
            lblSearchGenre.Text = listOfBooks[Index].Genre;
            lblSearchPages.Text = listOfBooks[Index].NumberOfPages.ToString();
            lblSearchPublisher.Text = listOfBooks[Index].Publisher;


        }

        //Displays book information for second tab
        private void lstCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BookInfo(lstCatalog.SelectedIndex);

            if (lstCatalog.SelectedIndex != -1)
            {
                lblCallNumber.Text = GetBookInfo(lstCatalog.SelectedIndex).CallNumber;
                lblAuthorName.Text = GetBookInfo(lstCatalog.SelectedIndex).AuthorName;
                lblbookTitle.Text = GetBookInfo(lstCatalog.SelectedIndex).BookTitle;
                lblGenre.Text = GetBookInfo(lstCatalog.SelectedIndex).Genre;
                lblNumberOfPages.Text = GetBookInfo(lstCatalog.SelectedIndex).NumberOfPages.ToString();
                lblPublisher.Text = GetBookInfo(lstCatalog.SelectedIndex).Publisher;


                if (GetBookInfo(lstCatalog.SelectedIndex).GetType().ToString() == "eBook")
                {
                    lblFileSize.Text = ((eBook)GetBookInfo(lstCatalog.SelectedIndex)).Filesize.ToString();
                }
                else
                {
                    lblFileSize.Text = "";
                }
            }

        }

        //checks for a duplicate call number amount
        private bool DuplicateCallNumber(string anElement)
        {
            bool isSameElement = false;

            if (listofCallNumbers.Contains(anElement, StringComparer.OrdinalIgnoreCase))
            {
                isSameElement = true;
            }
            
            return isSameElement;
        }

        //checks for a duplicate Author name
        private bool DuplicateAuthor(string anElement)
        {
            bool isSameElement = false;

            if (listofAuthors.Contains(anElement, StringComparer.OrdinalIgnoreCase))
            {
                isSameElement = true;
            }

            return isSameElement;
        }


        //is there a duplicate genre? This checks for that.
        private bool DuplicateGenre(string anElement)
        {
            bool isSameElement = false;

            if (listofGenre.Contains(anElement, StringComparer.OrdinalIgnoreCase))
            {
                isSameElement = true;
            }

            return isSameElement;
        }


        //Checks for a duplicate publisher
        private bool DuplicatePublisher(string anElement)
        {
            bool isSameElement = false;

            if (listofPublishers.Contains(anElement, StringComparer.OrdinalIgnoreCase))
            {
                isSameElement = true;
            }

            return isSameElement;
        }


        //When the button is clicked, and if there is something in the textbox, this will search through the lists,
        //output the name of the list, and display the name of the title in the listbox on the third tab
        private void btnSearch_Click(object sender, EventArgs e)
        {

            int index = cboSearch.SelectedIndex;

            if (!string.IsNullOrWhiteSpace(txtSearchBox.Text))
            {
                switch (index)
                {
                    case 0:
                        if (DuplicateCallNumber(txtSearchBox.Text))
                        {
                            lstSearchResult.Items.Add(txtSearchBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("No Matching Call Numbers");
                        }
                        break;

                    case 1:

                        if (DuplicateAuthor(txtSearchBox.Text))
                        {
                            lstSearchResult.Items.Add(txtSearchBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("No Matching Authors");
                        }
                        break;

                    case 2:

                        if (DuplicateGenre(txtSearchBox.Text))
                        {
                            lstSearchResult.Items.Add(txtSearchBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("No Matching Genres");
                        }

                        break;
                    case 3:

                        if (DuplicatePublisher(txtSearchBox.Text))
                        {
                            lstSearchResult.Items.Add(txtSearchBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("No Matching Publishers");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        //Displays results in labels in third tab
        private void lstSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BookInfoSearch(lstSearchResult.SelectedIndex);

            if (lstSearchResult.SelectedIndex != -1)
            {
                lblSearchCall.Text = GetBookInfo(lstSearchResult.SelectedIndex).CallNumber;
                lblSearchName.Text = GetBookInfo(lstSearchResult.SelectedIndex).AuthorName;
                lblSeachTitle.Text = GetBookInfo(lstSearchResult.SelectedIndex).BookTitle;
                lblSearchGenre.Text = GetBookInfo(lstSearchResult.SelectedIndex).Genre;
                lblSearchPages.Text = GetBookInfo(lstSearchResult.SelectedIndex).NumberOfPages.ToString();
                lblSearchPublisher.Text = GetBookInfo(lstSearchResult.SelectedIndex).Publisher;


                if (GetBookInfo(lstSearchResult.SelectedIndex).GetType().ToString() == "eBook")
                {
                    lblSearchFSize.Text = ((eBook)GetBookInfo(lstSearchResult.SelectedIndex)).Filesize.ToString();
                }
                else
                {
                    lblFileSize.Text = "";
                }
            }
        }

        //exits the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbEBook_CheckedChanged(object sender, EventArgs e)
        {

            if (chbEBook.Checked)
            {
                txtFileSize.Enabled = true;
            }
            else
            {
                txtFileSize.Enabled = false;
            }
        }

    }
}
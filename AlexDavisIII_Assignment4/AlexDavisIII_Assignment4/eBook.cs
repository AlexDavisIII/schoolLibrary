using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class eBook : Book
    {
        private double fileSize;

        public eBook(string theCall, string theTitle, string theName, string theGenre, int thePages, string thePublisher, double anFileSize)
            : base(theCall, theTitle, theName, theGenre, thePages, thePublisher)
        {
            fileSize = anFileSize;

        }
        public double Filesize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "File Size: " + fileSize;
        }
    }
    
   


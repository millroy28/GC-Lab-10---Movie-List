using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_10_Movie_List
{
    class Movie
    {
        //private fields
        private string title;
        private string category;

        //public properties
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        //constructors
        public Movie()
        {
            title = "Movie Title";
            category = "Category";
        }
        public Movie(string _title, string _category)
        {
            title = _title;
            category = _category;
        }

        //methods
        

    }
}

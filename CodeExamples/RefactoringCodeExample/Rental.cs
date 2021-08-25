using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCodeExample
{
    /// <summary>
    /// 租赁
    /// </summary>
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public Movie Movie {
            get { return _movie; }
        }

        public int DaysRented {
            get { return _daysRented; }
        }
    }
}

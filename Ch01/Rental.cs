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

        public Movie Movie
        {
            get { return _movie; }
        }

        public int DaysRented
        {
            get { return _daysRented; }
        }

        // refacoring-step-02：Move Method 搬移函数
        public double GetCharge()
        {
            return Movie.GetCharge(DaysRented); 
            //double result = 0;
            //switch (Movie.PriceCode)
            //{
            //    case Movie.Regular:
            //        result += 2;
            //        if (DaysRented > 2)
            //        {
            //            result += (DaysRented - 2) * 1.5;
            //        };
            //        break;
            //    case Movie.NewRelease:
            //        result += DaysRented * 3;
            //        break;
            //    case Movie.Childrens:
            //        result += 1.5;
            //        if (DaysRented > 1)
            //        {
            //            result += (DaysRented - 3) * 1.5;
            //        };
            //        break;

            //}

            //return result;
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(DaysRented);
            // add bouns for a two day new release rental
            //if ((Movie.PriceCode == Movie.NewRelease) && (DaysRented > 1))
            //{
            //    return 2;
            //}
            //else
            //{
            //    return 1;
            //}
        }
    }
}

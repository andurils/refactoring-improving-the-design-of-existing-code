using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCodeExample
{
    /// <summary>
    /// 影片类
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// 普通片
        /// </summary>
        public const int Regular = 0;
        /// <summary>
        /// 新片
        /// </summary>
        public const int NewRelease = 1;
        /// <summary>
        /// 儿童片
        /// </summary>
        public const int Childrens = 2;

        // feild
        private string _title;
        private int _priceCode;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            _title = title;
            //_priceCode = priceCode;
            // Repalce Type Code with State/Stategy 
            SetPriceCode(priceCode);
        }


        public int PriceCode
        {
            //set { _priceCode = value; }
            get { return _price.GetPriceCode(); }
        }

        public string Title
        {
            get { return _title; }
        }

        

        public void SetPriceCode(int arg)
        {
            switch (arg)
            {
                case Regular: _price = new RegularPrice(); break;
                case Childrens: _price = new ChildrensPrice(); break;
                case NewRelease: _price = new NewReleasePrice(); break;
                default:
                    throw new Exception("Incorrect Price Code");
            } 
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
            //double result = 0;
            //switch (PriceCode)
            //{
            //    case Movie.Regular:
            //        result += 2;
            //        if (daysRented > 2)
            //        {
            //            result += (daysRented - 2) * 1.5;
            //        };
            //        break;
            //    case Movie.NewRelease:
            //        result += daysRented * 3;
            //        break;
            //    case Movie.Childrens:
            //        result += 1.5;
            //        if (daysRented > 1)
            //        {
            //            result += (daysRented - 3) * 1.5;
            //        };
            //        break;

            //}

            //return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            // add bouns for a two day new release rental
            if ((PriceCode == Movie.NewRelease) && (daysRented > 1))
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

    }

}

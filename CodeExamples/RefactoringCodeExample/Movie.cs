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

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }


        public int PriceCode
        {
            set { _priceCode = value; }
            get { return _priceCode; }
        }

        public string Title
        {
            get { return _title; }
        }

    }

}

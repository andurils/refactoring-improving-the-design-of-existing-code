using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCodeExample
{
    /// <summary>
    /// 顾客
    /// </summary>
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name
        {
            get { return _name; }
        }





        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + Name + "\n";
            foreach (Rental each in rentals)
            {
                double thisAmount = 0;
                // refacoring-step-01：Extract Method 提炼函数
                thisAmount = amountFor(each);

                // add frequent renter points
                frequentRenterPoints++;
                // add bouns for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NewRelease) && (each.DaysRented > 1))
                {
                    frequentRenterPoints++;
                }

                // show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;

            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points\n";

            return result;
        }

        /// <summary>
        ///  determine amounts for each line
        /// </summary>
        /// <param name="aRental"></param>
        /// <returns></returns>
        private double amountFor(Rental aRental )
        {
            double result = 0;
            switch (aRental.Movie.PriceCode)
            {
                case Movie.Regular:
                    result += 2;
                    if (aRental.DaysRented > 2)
                    {
                        result += (aRental.DaysRented - 2) * 1.5;
                    };
                    break;
                case Movie.NewRelease:
                    result += aRental.DaysRented * 3;
                    break;
                case Movie.Childrens:
                    result += 1.5;
                    if (aRental.DaysRented > 1)
                    {
                        result += (aRental.DaysRented - 3) * 1.5;
                    };
                    break;

            }

            return result;
        }
    }
}

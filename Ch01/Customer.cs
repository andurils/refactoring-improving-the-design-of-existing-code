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
                // 金额计算 determine amounts for each line
                // thisAmount = each.GetCharge();


                //// add frequent renter points
                //frequentRenterPoints++;
                //// add bouns for a two day new release rental
                //if ((each.Movie.PriceCode == Movie.NewRelease) && (each.DaysRented > 1))
                //{
                //    frequentRenterPoints++;
                //}
                // 常客积分计算   refacoring-step-03：Extract Method 提炼函数
                frequentRenterPoints = each.GetFrequentRenterPoints();

                // show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + each.GetCharge().ToString() + "\n";
                totalAmount += each.GetCharge();

            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points\n";

            return result;
        }


        //private double AmountFor(Rental aRental )
        //{

        //    return aRental.GetCharge();
        //}
    }
}

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
            int frequentRenterPoints = 0;
            List<Rental> rentals = _rentals;
            string result = "Rental Record for " + Name + "\n";
            foreach (Rental each in rentals)
            {

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
                //totalAmount += each.GetCharge();

            }

            // 去除临时变量  使用查询函数 query method 取代临时变量
            // refacoring-step-04：Replace Temp with Query 以查询取代临时变量
            // add footer lines
            //result += "Amount owed is " + totalAmount.ToString() + "\n";
            //result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points\n
            result += "Amount owed is " + GetTotalCharge().ToString() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints().ToString() + " frequent renter points\n";

            return result;
        }

        public string HtmlStatement()
        { 
            List<Rental> rentals = _rentals;
            string result = "<H1>Rental Record for <EM>" + Name + "</EM></H1><P>\n";
            foreach (Rental each in rentals)
            { 
                // show figures for this rental
                result +=   each.Movie.Title + ":" + each.GetCharge().ToString() + "<BR/>\n";  
            }

            // add footer lines 
            result += "<P> You owed <EM> " + GetTotalCharge().ToString() + "</EM></P>\n";
            result += "On this rental you earned  <EM> " + GetTotalFrequentRenterPoints().ToString() + " </EM> frequent renter points </P> \n";

            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (Rental each in _rentals)
            {
                result += each.GetCharge();
            }
            return result;
        }
        private int GetTotalFrequentRenterPoints()
        {
            var result = 0;
            foreach (Rental each in _rentals)
            {
                result += each.GetFrequentRenterPoints();
            }
            return result;
        }


        //private double AmountFor(Rental aRental )
        //{

        //    return aRental.GetCharge();
        //}
    }
}

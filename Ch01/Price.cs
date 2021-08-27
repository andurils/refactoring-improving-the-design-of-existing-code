using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCodeExample
{
    public abstract class Price
    {
        public abstract int GetPriceCode();
        // Replace Conditional with Polymorphism  以多态取代条件表达式
        public abstract double GetCharge(int daysRented);

        public int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }

    }

    public class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }
        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            };

            return result;
        }
    }
    public class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }

        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public  int GetFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1; 
        }
    }

    public class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }

        public override double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
            {
                result += (daysRented - 2) * 1.5;
            };

            return result;
        }
    }
}

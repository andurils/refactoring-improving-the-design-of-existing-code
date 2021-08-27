using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCodeExample
{
    public abstract class Price
    {
        public abstract int GetPriceCode();

        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (GetPriceCode())
            {
                case Movie.Regular:
                    result += 2;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5;
                    };
                    break;
                case Movie.NewRelease:
                    result += daysRented * 3;
                    break;
                case Movie.Childrens:
                    result += 1.5;
                    if (daysRented > 1)
                    {
                        result += (daysRented - 3) * 1.5;
                    };
                    break;

            }

            return result;
        }

    }

    public class ChildrensPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Childrens;
        }
    }
    public class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NewRelease;
        }
    }

    public class RegularPrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.Regular;
        }
    }
}

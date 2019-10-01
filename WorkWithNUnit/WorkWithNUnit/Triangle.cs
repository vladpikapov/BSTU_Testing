using System;

namespace WorkWithNUnit
{
    public class Triangle
    {
        public bool IsTriangle(double firstSide, double secondSide, double thirdSide)
        {
            return (firstSide > 0 && secondSide > 0 && thirdSide > 0 && (firstSide + secondSide > thirdSide) && (secondSide + thirdSide > firstSide) && (firstSide + thirdSide > secondSide));
        }
    }
}

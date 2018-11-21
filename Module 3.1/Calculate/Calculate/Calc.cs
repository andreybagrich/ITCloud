using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public static class Calc
    {
        public static double DoSum(int a, int b)
        {
            double rez = a + b;

            return rez;
        }

        public static double DoSubstraction(int a, int b)
        {
            double rez = a - b;

            return rez;
        }

        public static double DoDivision(int a, int b)
        {
            double rez = a / b;

            return rez;
        }

        public static double DoMultiplication(int a, int b)
        {
            double rez = a * b;

            return rez;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    class Program
    {
        public delegate double CalculateDelegate(int a, int b);

        static void Main(string[] args)
        {   
            CalculateDelegate calculateDelegate;
            calculateDelegate = Calc.DoSum;
            calculateDelegate += Calc.DoSubstraction;
            calculateDelegate += Calc.DoDivision;
            calculateDelegate += Calc.DoMultiplication;
            calculateDelegate.Invoke(13, 13);

            Delegate[] list = calculateDelegate.GetInvocationList();
        }
    }
}

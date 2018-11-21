using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money money1 = new Money() { Amount = 10};
            Money money2 = new Money() { Amount = 10};

            // 11) do operations
            // add 2 objects of Money

            var money3 = money1 + money2;

            // add 1st object of Money and double

            money1 = money1 + 10;

            // decrease 2nd object of Money by 1 

            money2--;

            // increase 1st object of Money

            money1++;

            // compare 2 objects of Money

            if (money1 > money2)
            {

            }

            // compare 2nd object of Money and string

            if (money2 > (Money)"13")
            {

            }

            // check CurrencyType of every object

            money1.CurrencyTypesMoney = CurrencyTypes.UAH;
            money2.CurrencyTypesMoney = CurrencyTypes.USD;


            // convert 1st object of Money to string

            var str = (string)money1;

        }
    }
}

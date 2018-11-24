using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU


    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType

        public decimal Amount {get; set;}
        public CurrencyTypes CurrencyTypesMoney { get; set; }

        // 3) declare parameter constructor for properties initialization

        public Money()
        { }

        public Money(decimal amount, CurrencyTypes currencyTypes)
        {
            Amount = amount;
            CurrencyTypesMoney = currencyTypes;
        }

        // 4) declare overloading of operator + to add 2 objects of Money

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(money1.Amount + money2.Amount, money1.CurrencyTypesMoney);
        }

        public static Money operator +(Money money1, double d)
        {
            money1.Amount = money1.Amount + Convert.ToDecimal(d);
            return money1;
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1

        public static Money operator --(Money money1)
        {
            money1.Amount--;
            return money1;
        }

        public static Money operator ++(Money money1)
        {
            money1.Amount++;
            return money1;
        }

        // 6) declare overloading of operator * to increase object of Money 3 times

        public static Money operator *(Money money1, int scale)
        {
            money1.Amount = money1.Amount * scale;
            return money1;
        }

        // 7) declare overloading of operator > and < to compare 2 objects of Money

        public static bool operator >(Money money1, Money money2)
        {
            return (money1.Amount > money2.Amount);
        }

        public static bool operator <(Money money1, Money money2)
        {
            return (money1.Amount < money2.Amount);
        }

        // 8) declare overloading of operator true and false to check CurrencyType of object

        public static bool operator true(Money money1)
        {
            if (money1.CurrencyTypesMoney != CurrencyTypes.None)
                return true;
            else
                return false;
        }

        public static bool operator false(Money money1)
        {
            if (money1.CurrencyTypesMoney != CurrencyTypes.None)
                return false;
            else
                return true;
        }

        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa

        public static explicit operator double(Money money1)
        {
            return (double)money1.Amount;
        }

        public static explicit operator string(Money money1)
        {
            return money1.Amount.ToString();
        }

        public static explicit operator Money(double d)
        {
            return new Money(Convert.ToDecimal(d), CurrencyTypes.UAH);
        }

        public static explicit operator Money(string str)
        {
            return new Money(decimal.Parse(str), CurrencyTypes.UAH);
        }

        /*
         * Более полный вариант
         *  public static implicit operator string(Money money)
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            return $"{money.CurrencyTypes.ToString()} {money.Amount}";
        }
          public static implicit operator Money(string value)
        {            
            // Enum.Parse - механизм приведения строки к енумке: в метод передали тип и строку, на выходе получили object который привели к нужному типу
            //string.Split() - получения массива стрингов по разделителю (пробел, запятая и т.п.)
            //value.Split()[0] вернет нам значение до пробела
            //value.Split()[1] вернет нам значение после пробела
            string strCur = value.Split()[0];
            CurrencyTypes currency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes), strCur);
            string strAmount = value.Split()[1];
            decimal amount = decimal.Parse(strAmount);
            return new Money(amount, currency);
        }
         
         */

        //public static implicit operator double(Money money1)
        //{
        //    return (double)money1.Amount;
        //}

        //public static implicit operator string(Money money1)
        //{
        //    return money1.ToString();
        //}

        //public static implicit operator Money(double d)
        //{
        //    return new Money(Convert.ToDecimal(d), CurrencyTypes.UAH);
        //}

        //public static implicit operator Money(string str)
        //{
        //    return new Money(decimal.Parse(str), CurrencyTypes.UAH);
        //}
    }
}

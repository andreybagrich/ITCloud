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

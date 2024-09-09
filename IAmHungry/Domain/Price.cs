using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Price
    {
        private string _currency;
        private double _amount;

        public string Currency
        {
            get
            {
                return _currency;
            }

            set
            {
                _currency = value;
            }
        }

        public double Amount
        {
            get
            {
                return CalculateAmount(_amount, Currency);
            }
        }


        public Price(double amount, string currency = "czk")
        {
            _currency = currency;
            _amount = CalculateAmount(amount, currency);
        }

        private double CalculateAmount(double amount, string currency)
        {
            if (currency == "czk")
            {
                return amount;
            }
            else if (currency == "eur")
            {
                return double.Round(amount / 28, 1);
            }
            else
            {
                throw new ArgumentException("Unsupported currency.");
            }
        }

        public override string ToString()
        {
            return _amount.ToString() + " " + _currency.ToUpper();
        }
    }
}

﻿namespace IAmHungry.Domain
{
    public class Price
    {
        private string _currency;
        private int? _amount;
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

        public int? Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }


        public Price(int amount, string currency = "czk")
        {
            _currency = currency;
            _amount = amount;
        }

        public override string ToString()
        {
            return _amount.ToString() + " " + _currency.ToUpper();
        }
    }
}

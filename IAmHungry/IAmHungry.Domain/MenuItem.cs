﻿
namespace IAmHungry.Domain
{
    public class MenuItem
    {
        private Price? _mealPrice;
        private Meal _mealDescription;

        public Price? MealPrice { get { return _mealPrice; } set { _mealPrice = value; } }
        public Meal MealDescription { get { return _mealDescription; } set { _mealDescription = value; } }

        public MenuItem(Meal description)
        {
            _mealDescription = description;
        }

        public MenuItem(Meal description, Price price) 
        {
            _mealDescription = description;
            _mealPrice = price;
        }
    }
}

using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;

namespace IAmHungry.Application
{
    public class MealData : IMealData
    {
        private string _descpription;
        
        public MealData(string mealDescription) 
        {
            _descpription = mealDescription;
        }

        private bool IsContainedInDescription(string substring)
        {
            return _descpription.ToLower().Contains(substring.ToLower());
        }

        private bool IsSoup()
        {
            return IsContainedInDescription(MealKind.Soup());
        }

        private bool IsVegetarian()
        {
            if (MealKind.Vege().Any(vege => IsContainedInDescription(vege)))
            {
                return true;
            }
            var meatList = MealKind.Meat().Concat(MealKind.Fish());
            return meatList.All(meat => !IsContainedInDescription(meat)) && !IsEmpty();
        }

        private bool IsEmpty()
        {
            return MealKind.NoDataAvailable().Any(line => IsContainedInDescription(line));
        }

        public Meal GetMeal()
        {
            return new Meal(_descpription, IsVegetarian(), IsSoup());
        }
    }
}

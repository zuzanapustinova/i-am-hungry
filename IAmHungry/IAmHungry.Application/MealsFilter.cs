using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;

namespace IAmHungry.Application
{
    public class MealsFilter : IMealsFilter
    {
        private Meal _meal;
        public Meal Meal
        {
            get { return _meal; }
            set { _meal = value; }
        }
        public MealsFilter(Meal meal) 
        {
            _meal = meal;
        }

        private bool IsContainedInDescription(string substring)
        {
            return Meal.Description.ToLower().Contains(substring.ToLower()) ? true : false;
        }

        public bool IsSoup()
        {
            return (IsContainedInDescription(MealKind.Soup()) ?  true : false);
        }

        public bool IsVegetarian()
        {
            foreach (var vege in MealKind.Vege()) 
            {
                if (IsContainedInDescription(vege))
                {
                    return true;
                }
            }
            var meatList = MealKind.Meat().Concat(MealKind.Fish());
            foreach (var meat in meatList)
            {
                if (IsContainedInDescription(meat))
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return true;
        }
    }
}

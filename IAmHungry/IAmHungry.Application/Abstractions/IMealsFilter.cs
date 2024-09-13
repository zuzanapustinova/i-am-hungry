using IAmHungry.Domain;

namespace IAmHungry.Application.Abstractions
{
    public interface IMealsFilter
    {
        public Meal Meal { get; }
        public bool IsSoup();
        public bool IsVegetarian();
    }
}

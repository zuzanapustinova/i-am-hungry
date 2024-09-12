namespace IAmHungry.Domain
{
    public class Meal
    {
        public string Description { get; set; }
        public Meal(string description)
        {
            Description = description;
        }

        private bool IsContainedInName(string description, string substring)
        {
            return description.ToLower().Contains(substring.ToLower()) ? true : false;
        }
    }
}

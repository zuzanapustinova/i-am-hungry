namespace IAmHungry.Domain
{
    public class Meal
    {
        public string Description { get; set; }
        public Meal(string description)
        {
            Description = description;
        }
    }
}

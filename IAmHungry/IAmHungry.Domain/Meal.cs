namespace IAmHungry.Domain
{
    public class Meal
    {
        public string Description { get; set; }
        public bool IsVegetarian { get; set; }

        public bool IsSoup { get; set; }
        public Meal(string description, bool isVegetarian, bool isSoup)
        {
            Description = description;
            IsVegetarian = isVegetarian;
            IsSoup = isSoup;
        }
    }
}

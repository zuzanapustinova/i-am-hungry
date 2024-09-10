namespace IAmHungry.Domain
{
    public class Meal
    {
        private bool _nameContains;
        public bool NameContains
        {
            get
            {
                return _nameContains;
            }
        }
        public string Description { get; set; }
        public Meal(string description, string filter = "")
        {
            Description = description;
            _nameContains = IsContainedInName(Description, filter);
        }

        private bool IsContainedInName(string description, string substring)
        {
            return description.ToLower().Contains(substring.ToLower()) ? true : false;
        }
    }
}

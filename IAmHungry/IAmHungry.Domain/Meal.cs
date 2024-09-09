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
        public string Name { get; set; }
        public Meal(string name, string filter = "")
        {
            Name = name;
            _nameContains = IsContainedInName(name, filter);
        }

        private bool IsContainedInName(string name, string substring)
        {
            return name.ToLower().Contains(substring.ToLower()) ? true : false;
        }
    }
}

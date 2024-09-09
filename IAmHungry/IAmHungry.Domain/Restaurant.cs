namespace IAmHungry.Domain
{

    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
        

        public Restaurant(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

    }
}

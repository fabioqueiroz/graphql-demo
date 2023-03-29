namespace GraphQL.Demo.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public void Update(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
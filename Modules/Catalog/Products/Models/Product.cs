namespace Catalog.Products.Models
{
    public class Product : Aggregate<Guid>
    {
        public string Name { get; private set; } = default!;
        public List<string> Category { get; private set; } = new();
        public string Description { get; private set; } = default!;
        public string ImageFile { get; private set; } = default!;
        public decimal Price { get; private set; }

        // create method

        public static Product Create(Guid Id, string name,List<string> category, string description, string imageFile, decimal price)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            Product product = new Product();
            product.Name = name;
            product.Category = category;
            product.Description = description;
            product.ImageFile = imageFile;
            product.Price = price;

            product.AddDomainEvent(new ProductCreatedEvent(product));
            return product;
        }

        public  void Update(string name, List<string> category, string description, string imageFile, decimal price)
        {

            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            //update 
            Name = name; 
            Category = category;
            Description = description;
            ImageFile = imageFile;
            Price = price;

            //rich product price changed domain event
            if(Price != price)
            {
                Price = price;
                AddDomainEvent(new ProductPriceChangedEvent(this));
            }
        }
    }
}

using System.Collections.Generic;

namespace MotivWebApp.Source.Products
{
    public class ProductRegistry : IProductRegistry
    {
        private readonly List<FinanceProduct> products;
        private readonly Random random;
        
        public ProductRegistry()
        {
            products = new List<FinanceProduct>{
                new FinanceProduct("The Pigeon Plan", "A terrible plan that can barely fly", 100, 1, "https://encrypted-tbn3.gstatic.com/licensed-image?q=tbn:ANd9GcTTQEqKVXJ_3BSoRUNYNNWY_yZ0benAi36_pVKQad6_dMD1s3nEpD-2959xE-mKVqZdeXbfMC9HcNjw1cQ"),
                new FinanceProduct("The Penguin Plan", "A plan that wobbles around from place to place, but it's good at swimming", 150, 2, "https://www.cabq.gov/artsculture/biopark/news/10-cool-facts-about-penguins/@@images/1a36b305-412d-405e-a38b-0947ce6709ba.jpeg"),
                new FinanceProduct("The Peregrin Plan", "A plan that's really, really fast", 200, 3, "https://www.thebestofexmoor.co.uk/blog/wp-content/uploads/2023/02/peregrin-falcon-in-flight.jpeg"),
                new FinanceProduct("The Pterodactyl Plan", "A plan that has literally been around since the dinosaurs", 250, 4, "https://carnegiemnh.org/wp-content/uploads/2016/04/ptero.jpg")
            };
            random = new Random();
        }

        public List<FinanceProduct> GetApprovedProducts(int score)
        {
            return products.Where(plan => plan.minimumScore <= score).ToList();
        }

        public FinanceProduct GetRandomProduct()
        {
            return products[random.Next(products.Count)];
        }

    }
}

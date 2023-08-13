namespace MotivWebApp.Source.Products
{
    public class ProductRegistry: IProductRegistry
    {
        protected List<FinanceProduct> products;

        public ProductRegistry() 
        { 
            products = new List<FinanceProduct>{
                new FinanceProduct("The Pigeon Plan", "A terrible plan that can barely fly", 100, 1),
                new FinanceProduct("The Penguin Plan", "A plan that wobbles around from place to place, but it's good at swimming", 150, 2),
                new FinanceProduct("The Peregrin Plan", "A plan that's really, really fast", 200, 3),
                new FinanceProduct("The Pterodactly Plan", "A plan that has literally been around since the dinosaurs", 250, 4)
            };
        }

        public List<FinanceProduct> GetApprovedProducts(int score)
        {
            return products.Where(plan => plan.minimumScore <= score).ToList();
        }

    }
}

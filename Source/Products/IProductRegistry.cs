namespace MotivWebApp.Source.Products
{
    public interface IProductRegistry
    {
        public List<FinanceProduct> GetApprovedProducts(int score);
    }
}

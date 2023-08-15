using MotivWebApp.Models;

namespace MotivWebApp.Services.Products
{
    public interface IProductRegistry
    {
        public List<FinanceProduct> GetApprovedProducts(int score);

        public FinanceProduct GetRandomProduct();
    }
}

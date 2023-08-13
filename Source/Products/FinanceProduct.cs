namespace MotivWebApp.Source.Products
{
    public struct FinanceProduct
    {
        public readonly string name;
        public readonly string description;
        public readonly float premium;
        public readonly int minimumScore;

        public FinanceProduct(string name, string description, float premium, int minimumScore)
        {
            this.name = name;
            this.description = description; 
            this.premium = premium;
            this.minimumScore = minimumScore;
        }
    }
}

namespace MotivWebApp.Models
{
    public class FinanceProduct
    {
        public string name;
        public string description;
        public float premium;
        public int minimumScore;
        public string url;

        public FinanceProduct(string name, string description, float premium, int minimumScore, string url)
        {
            this.name = name;
            this.description = description;
            this.premium = premium;
            this.minimumScore = minimumScore;
            this.url = url;
        }
    }
}

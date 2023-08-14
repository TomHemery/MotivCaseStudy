using MotivWebApp.Source.Products;

namespace MotivWebApp.Models
{
    public class User
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public string Username { get; private set; } = string.Empty;
        public string RegisteredDate { get; private set; } = string.Empty;
        public int RegisteredAge { get; private set; } = 0;
        
        public string Email { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string MobileNumber { get; private set; } = string.Empty;
        public string Nationality { get; private set; } = string.Empty;

        public string LargePictureURL { get; private set; } = string.Empty;
        public string SmallPictureURL { get; private set; } = string.Empty;
        public string ThumbnailURL { get; private set; } = string.Empty;

        public FinanceProduct FinancePlan { get; private set; }

        public User(dynamic jsonSpec, FinanceProduct financePlan) { 
            FirstName = jsonSpec.name.first;
            LastName = jsonSpec.name.last;

            Username = jsonSpec.login.username;
            RegisteredDate = jsonSpec.registered.date;
            RegisteredAge = jsonSpec.registered.age;

            Email = jsonSpec.email;
            PhoneNumber = jsonSpec.phone;
            MobileNumber = jsonSpec.cell;
            Nationality = jsonSpec.nat;

            LargePictureURL = jsonSpec.picture.large;
            SmallPictureURL = jsonSpec.picture.small;
            ThumbnailURL += jsonSpec.picture.thumbnail;

            FinancePlan = financePlan;
        } 
    }
}

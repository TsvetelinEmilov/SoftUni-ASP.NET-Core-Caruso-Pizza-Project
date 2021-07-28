namespace CarusoPizza.Data
{
    public class DataConstants
    {
        public class ApplicationUser
        {
            public const int FirstAndLastNameMaxLength = 30;
            public const int PhoneNumberMaxLength = 20;
        }
        public class Category
        {
            public const int NameMaxLength = 50;
        }
        public class Product
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;

            public const double PriceMinValue = 0.1;
            public const double PriceMaxValue = 100;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 200;


        }
        public class Topping
        {
            public const int NameMaxLength = 40;
        }
        public class User
        {
            public const int FirstAndLastNameMinLength = 6;
            public const int FirstAndLastNameMaxLength = 50;

            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;
        }

    }
}


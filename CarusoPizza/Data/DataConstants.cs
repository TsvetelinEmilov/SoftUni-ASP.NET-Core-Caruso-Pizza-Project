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

        public class Basket
        {
            public const int CommentMaxLength = 40;

            public const int QuantityMinValue = 1;
            public const int QuantityMaxValue = 100;
        }
        public class Order
        {
            public const int PhoneNumberMinLength = 5;
            public const int PhoneNumberMaxLength = 20;

            public const int FullNameMinLength = 2;
            public const int FullNameMaxLength = 40;

            public const string EmailRegularExpression =
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 40;

            public const int CityMinLength = 3;
            public const int CityMaxLength = 20;

            public const int DistrictMinLength = 5;
            public const int DistrictMaxLength = 30;

            public const int StreetAndNumberMinLength = 5;
            public const int StreetAndNumberMaxLength = 40;

            public const int NoteMinLength = 1;
            public const int NoteMaxLength = 100;
        }

    }
}


namespace BAS.Application.Common.Constants
{
    public static class RegexPattern
    {
        //public const string Password = "(?=(.*[0-9]))(?=.*[\\!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}";
        public const string Alphabet = @"^[a-zA-Z]+$";
        public const string AlphabetAllowEmpty = @"^[a-zA-Z]*$";
        public const string Numeric = @"^[0-9]+$";
        public const string NumericAllowEmpty = @"^[0-9]*$";
        public const string AlphaNumeric = @"^[a-zA-Z0-9]+$";
        public const string AlphaNumericAllowEmpty = @"^[a-zA-Z0-9]*$";
        public const string AlphaNumericSpace = @"^[a-zA-Z0-9 ]+$";
        public const string AlphaNumericSpaceAllowEmpty = @"^[a-zA-Z0-9 ]*$";

        public const string DefaultName = @"^[a-zA-Z0-9 .,-]+$";
        public const string DefaultUserName = @"^[a-zA-Z][a-zA-Z0-9-_.]*$";
        public const string DefaultUserPassword = @"^(?=.*?[0-9])(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^0-9A-Za-z]).{8,64}$";
        public const string DefaultPhoneLeadingZero = @"^(|[0-9]{8,16})$";
        public const string DefaultDesc = @"^$|^[a-zA-Z0-9-/,. ]*$";

        public const string DefaultBase64 = @"^(?:[A-Za-z0-9+\/]{4})*(?:[A-Za-z0-9+\/]{4}|[A-Za-z0-9+\/]{3}=|[A-Za-z0-9+\/]{2}={2})$";
    }
}

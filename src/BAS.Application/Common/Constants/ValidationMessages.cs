namespace BAS.Application.Common.Constants
{
    public static class ValidationMessages
    {
        #region General
        public const string Required = "The {0} field is required.";
        public const string Invalid = "The {0} field is invalid.";
        public const string MustBeUnique = "The {0} field must be unique.";
        #endregion

        #region Comparison
        public const string NotEqual = "The {0} field must not be equal to {1}.";
        public const string NotEqualTo = "The {0} field must not be equal to the {1} field.";
        #endregion

        #region Data Type
        public const string Email = "The {0} field must be a valid email address.";
        public const string PhoneNumber = "The {0} field must be a valid phone number.";
        public const string Url = "The {0} field must be a valid URL.";
        public const string RegexMismatch = "The {0} field does not match the required format.";
        public const string Accepted = "The {0} field must be yes, on, 1, or true.";
        public const string NotAccepted = "The {0} field must be no, off, 0, or false.";
        public const string NotSupported = "The {0} field is not supported.";
        public const string NotSupportedType = "The {0} field is not supported for type {1}.";
        public const string MustBeAlphabet = "The {0} field must contain only alphabetic characters.";
        public const string MustBeNumeric = "The {0} field must be numeric.";
        public const string MustBeNumericAllowEmpty = "The {0} field must be numeric or empty.";
        public const string MustBeAlphanumeric = "The {0} field must be alphanumeric.";
        public const string MustBeAlphaNumericSpace = "The {0} field must be alphanumeric with spaces.";
        public const string MustBeAlphaNumericSpaceAllowEmpty = "The {0} field must be alphanumeric with spaces or empty.";
        public const string MustBeAlphaNumericSymbols = "The {0} field must be alphanumeric with symbols.";
        public const string MustBeAlphaNumericSymbolsAllowEmpty = "The {0} field must be alphanumeric with symbols or empty.";
        public const string MustBeDefaultName = "The {0} field must be a valid name.";
        public const string MustBeDefaultUserName = "The {0} field must be a valid username.";
        public const string MustBeDefaultUserPassword = "The {0} field must be a valid password.";
        public const string MustBeDefaultPhoneLeadingZero = "The {0} field must be a valid phone number with leading zero.";
        public const string MustBeDefaultDesc = "The {0} field must be a valid description.";
        public const string MustBeBase64 = "The {0} field must be a valid Base64 string.";

        public const string MustBeBoolean = "The {0} field must be a boolean value.";
        public const string MustBeBooleanOrEmpty = "The {0} field must be a boolean value or empty.";
        public const string MustBeArray = "The {0} field must be an array.";
        public const string MustBeArrayOrEmpty = "The {0} field must be an array or empty.";
        public const string MustBeArrayWithMinLength = "The {0} field must be an array with a minimum length of {1}.";
        public const string MustBeArrayWithMaxLength = "The {0} field must be an array with a maximum length of {1}.";
        public const string MustBeArrayWithExactLength = "The {0} field must be an array with an exact length of {1}.";
        public const string MustBeArrayWithUniqueItems = "The {0} field must be an array with unique items.";
        public const string MustBeArrayWithItemsOfType = "The {0} field must be an array with items of type {1}.";
        public const string MustBeArrayWithItemsOfTypeOrEmpty = "The {0} field must be an array with items of type {1} or empty.";
        public const string MustBeArrayWithItemsOfTypeAndMinLength = "The {0} field must be an array with items of type {1} and a minimum length of {2}.";
        public const string MustBeArrayWithItemsOfTypeAndMaxLength = "The {0} field must be an array with items of type {1} and a maximum length of {2}.";
        #endregion

        #region Range
        public const string MinLength = "The {0} field must be at least {1} characters long.";
        public const string MaxLength = "The {0} field must not exceed {1} characters.";
        public const string NotInRange = "The {0} field must be between {1} and {2}.";
        public const string NotInRangeExclusive = "The {0} field must be greater than {1} and less than {2}.";
        public const string NotInRangeInclusive = "The {0} field must be greater than or equal to {1} and less than or equal to {2}.";
        public const string NotInRangeMin = "The {0} field must be greater than or equal to {1}.";
        public const string NotInRangeMax = "The {0} field must be less than or equal to {1}.";
        public const string NotInList = "The {0} field must be one of the following values: {1}.";
        public const string NotInListWithValues = "The {0} field must be one of the following values: {1}.";
        public const string NotInListWithValuesAndType = "The {0} field must be one of the following values: {1} (Type: {2}).";
        #endregion

        #region Validate
        public const string MustBeValidDate = "The {0} field must be a valid date.";
        public const string MustBeValidDateTime = "The {0} field must be a valid date and time.";
        public const string MustBeValidTime = "The {0} field must be a valid time.";
        public const string MustBeValidDateRange = "The {0} field must be a valid date range.";
        public const string MustBeValidDateTimeRange = "The {0} field must be a valid date and time range.";
        public const string MustBeValidTimeRange = "The {0} field must be a valid time range.";
        public const string MustBeValidEnum = "The {0} field must be a valid enum value.";
        public const string MustBeValidEnumWithType = "The {0} field must be a valid enum value of type {1}.";
        public const string MustBeValidGuid = "The {0} field must be a valid GUID.";
        public const string MustBeValidGuidOrEmpty = "The {0} field must be a valid GUID or empty.";
        public const string MustBeValidIPAddress = "The {0} field must be a valid IP address.";
        public const string MustBeValidIPv4Address = "The {0} field must be a valid IPv4 address.";
        public const string MustBeValidIPv6Address = "The {0} field must be a valid IPv6 address.";
        public const string MustBeValidMacAddress = "The {0} field must be a valid MAC address.";
        public const string MustBeValidCreditCard = "The {0} field must be a valid credit card number.";
        public const string MustBeValidSocialSecurityNumber = "The {0} field must be a valid Social Security Number (SSN).";
        public const string MustBeValidPostalCode = "The {0} field must be a valid postal code.";
        public const string MustBeValidCurrency = "The {0} field must be a valid currency value.";
        public const string MustBeValidJson = "The {0} field must be a valid JSON string.";
        public const string MustBeValidXml = "The {0} field must be a valid XML string.";
        public const string MustBeValidHtml = "The {0} field must be a valid HTML string.";
        public const string MustBeValidMarkdown = "The {0} field must be a valid Markdown string.";
        public const string MustBeValidXmlOrEmpty = "The {0} field must be a valid XML string or empty.";
        public const string MustBeValidHtmlOrEmpty = "The {0} field must be a valid HTML string or empty.";
        public const string MustBeValidMarkdownOrEmpty = "The {0} field must be a valid Markdown string or empty.";
        public const string MustBeValidImage = "The {0} field must be a valid image file.";
        public const string MustBeValidImageOrEmpty = "The {0} field must be a valid image file or empty.";
        public const string MustBeValidFile = "The {0} field must be a valid file.";
        public const string MustBeValidFileOrEmpty = "The {0} field must be a valid file or empty.";
        public const string MustBeValidFileType = "The {0} field must be a valid file type.";
        public const string MustBeValidFileTypeOrEmpty = "The {0} field must be a valid file type or empty.";
        public const string MustBeValidFileSize = "The {0} field must be a valid file size.";
        public const string MustBeValidFileSizeOrEmpty = "The {0} field must be a valid file size or empty.";
        public const string MustBeValidFileExtension = "The {0} field must be a valid file extension.";
        public const string MustBeValidFileExtensionOrEmpty = "The {0} field must be a valid file extension or empty.";
        public const string MustBeValidFileName = "The {0} field must be a valid file name.";
        public const string MustBeValidFileNameOrEmpty = "The {0} field must be a valid file name or empty.";
        public const string MustBeValidFilePath = "The {0} field must be a valid file path.";
        public const string MustBeValidFilePathOrEmpty = "The {0} field must be a valid file path or empty.";
        public const string MustBeValidDirectoryPath = "The {0} field must be a valid directory path.";
        public const string MustBeValidDirectoryPathOrEmpty = "The {0} field must be a valid directory path or empty.";
        public const string MustBeValidUrlOrEmpty = "The {0} field must be a valid URL or empty.";
        public const string MustBeValidUrl = "The {0} field must be a valid URL.";
        public const string MustBeValidUrlWithScheme = "The {0} field must be a valid URL with a scheme.";
        public const string MustBeValidUrlWithoutScheme = "The {0} field must be a valid URL without a scheme.";
        public const string MustBeValidUrlWithQuery = "The {0} field must be a valid URL with a query.";
        public const string MustBeValidUrlWithoutQuery = "The {0} field must be a valid URL without a query.";
        public const string MustBeValidMimeType = "The {0} field must be a valid MIME type.";
        public const string MustBeValidMimeTypeOrEmpty = "The {0} field must be a valid MIME type or empty.";
        public const string MustBeValidColor = "The {0} field must be a valid color value.";
        public const string MustBeValidColorOrEmpty = "The {0} field must be a valid color value or empty.";
        public const string MustBeValidColorHex = "The {0} field must be a valid hexadecimal color value.";
        public const string MustBeValidColorHexOrEmpty = "The {0} field must be a valid hexadecimal color value or empty.";
        public const string MustBeValidColorRgb = "The {0} field must be a valid RGB color value.";
        public const string MustBeValidColorRgbOrEmpty = "The {0} field must be a valid RGB color value or empty.";
        #endregion
    }
}

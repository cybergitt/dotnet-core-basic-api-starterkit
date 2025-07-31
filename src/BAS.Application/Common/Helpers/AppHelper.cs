using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace BAS.Application.Common.Helpers
{
    public static class AppHelper
    {
        public static string GenerateRandomString(int length)
        {
            return new string(Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                .Select(x =>
                {
                    var cryptoResult = new byte[16];
                    using (var cryptoProvider = RandomNumberGenerator.Create())
                        cryptoProvider.GetBytes(cryptoResult);
                    return x[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(x.Length)];
                })
                .ToArray());
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || now.Month == birthDate.Month && now.Day < birthDate.Day)
                age--;

            return age;
        }

        public static int CalculateAge2(DateTime birthDate)
        {
            //DateTime birth = new DateTime(1990, 08, 02);
            DateTime birth = birthDate;
            DateTime today = DateTime.Now;
            TimeSpan span = today - birth;
            DateTime age = DateTime.MinValue + span;

            // Make adjustment due to MinValue equalling 1/1/1int years = age.Year - 1;
            int months = age.Month - 1;
            int days = age.Day - 1;

            // You even can Print out not only how many years old they are but give months and days as well
            var ageInYMD = string.Format("{0} years, {1} months, {2} days", age.Year, months, days);
            var ageInY = string.Format("{0} years", age.Year);

            return age.Year;
        }

        public static void AddHeaderIfNotExists(HttpContext httpContext, string key, string value)
        {
            if (!httpContext.Response.Headers.ContainsKey(key))
            {
                httpContext.Response.Headers.Append(key, value);
            }
        }

        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
    }
}

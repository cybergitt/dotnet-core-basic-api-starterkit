namespace BAS.Application.Common.Setting
{
    public class DbSettings
    {
        public required string DbConnectionUrl { get; set; }
        public int MaxRetryCount { get; set; } // in numbers
        public int MaxRetryDelay { get; set; } // in seconds
    }
}

namespace BAS.Application.Common.Setting
{
    public class AppSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string DisplayName { get; set; } = string.Empty;

        public string Mail { get; set; } = string.Empty;
        public string MailName { get; set; } = string.Empty;
    }
}

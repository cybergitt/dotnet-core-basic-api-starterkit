namespace BAS.Application.Common.Setting
{
    public static class FileSettings
    {
        public const int Byte = 1;
        public const int Kilobyte = 1024;
        public const int Megabyte = 1024 * 1024;
        public const int Gigabyte = 1024 * 1024 * 1024;
        public static readonly string[] BlockedSigntures = ["4D-5A", "2F-2A", "D0-CF"];
        public static readonly string[] AllowedImagesExtensions = [".jpg", ".jpeg", ".png"];
    }
}

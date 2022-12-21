namespace YummyFood.Web
{
    public static class ServiceDirectory
    {
        public static string? ProductAPIBase { get; set; }
        public static string? IdentityAPIBase { get; set; }
        public enum ApiType 
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public enum Role
        {
            Admin,
            User
        }
    }
}

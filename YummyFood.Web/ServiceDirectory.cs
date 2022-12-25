namespace YummyFood.Web
{
    public static class ServiceDirectory
    {
        public static string? ApiGateway { get; set; }
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

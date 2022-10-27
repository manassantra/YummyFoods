namespace YummyFood.Web
{
    public static class ServiceDirectory
    {
        public static string? ProductAPIBase { get; set; }
        public enum ApiType 
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

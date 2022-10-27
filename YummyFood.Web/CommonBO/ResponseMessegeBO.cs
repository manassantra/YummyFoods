namespace YummyFood.Web.CommonBO
{
    public class ResponseMessegeBO
    {
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public string? DisplayMessage { get; set; }
        public List<string>? ErrorMesseges { get; set; }
    }
}

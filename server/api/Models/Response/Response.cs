namespace api.Models.Response
{
    public class ResponseStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }

        public object data {get; set;}
    }
}

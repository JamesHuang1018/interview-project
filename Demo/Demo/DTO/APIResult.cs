namespace Demo.DTO
{
    public class APIResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
        
        public object Payload { get; set; }
    }
}
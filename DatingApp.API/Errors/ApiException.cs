namespace DatingApp.API.Errors
{
    public class ApiException
    {
        // populate constructor with properties
        // set a default for message & detail if no info is provided
        public ApiException(int statusCode, string message = null, string details = null) {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        // type we get back from exceptions
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
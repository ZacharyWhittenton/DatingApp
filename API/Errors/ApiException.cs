namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message, string myPropDetailserty)
        {
            StatusCode = statusCode;
            Message = message;
            MyPropDetailserty = myPropDetailserty;
        }

        public int StatusCode { get; set; }

        public string Message  { get; set; }

        public string MyPropDetailserty { get; set; }
    }

}
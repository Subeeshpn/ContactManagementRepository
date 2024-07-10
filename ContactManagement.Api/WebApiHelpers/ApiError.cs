using System.Text.Json;

namespace ContactManagement.Api.WebApiHelpers
{
    public class ApiError
    {
        public ApiError() { }
        public ApiError(int errorCode, string errorMessage, string errorDetails = null) {
                
        }
        public int ErrorCode { get; set; }
        public string errorMessage { get; set; }
        public string ErrorDetails { get; set; }
        
    }
    //public override string ToString()
    //{
    //    var options = new JsonSerializerOptions()
    //    {
    //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    //    };
    //    return JsonSerializer.Serialize(this, options);
    //}
}

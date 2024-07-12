namespace CleanArchitecture.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        public BaseHttpService(IClient client)
        {
            _client = client;
        }

        protected Response<Guid> ConvertApiException<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
                return new Response<Guid> { Message = "Invalid data was submitted.", ValidationErrors = exception.Response, Success = false };
            else if (exception.StatusCode == 404)
                return new Response<Guid> { Message = "Record not found.", ValidationErrors = exception.Response, Success = false };
            else
                return new Response<Guid> { Message = "Something went wrong.", ValidationErrors = exception.Response, Success = false };
        }
    }
}

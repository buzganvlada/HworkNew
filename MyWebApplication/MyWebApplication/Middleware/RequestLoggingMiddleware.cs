namespace MyWebApplication.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request.Headers[""];
            var response = context.Response;

            //Console.WriteLine($"Request: {request.Method} {request.Path}");
            await _next(context);
            Console.WriteLine($"Response: {response.StatusCode}");
        }
    }
}

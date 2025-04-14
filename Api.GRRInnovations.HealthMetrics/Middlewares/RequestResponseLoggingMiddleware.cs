namespace Api.GRRInnovations.HealthMetrics.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log request
            _logger.LogInformation("Request {method} {url}", context.Request.Method, context.Request.Path);

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            // Log response
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            _logger.LogInformation("Response {statusCode}: {text}", context.Response.StatusCode, text);
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}

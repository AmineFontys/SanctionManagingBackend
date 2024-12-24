using System.Net;
using System.Text.Json;

namespace SanctionManagingBackend
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Ga verder met de volgende middleware
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Er is een fout opgetreden: {ex.Message}");

                // Stel de HTTP response in
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Maak een gestandaardiseerde foutmelding
                var errorResponse = new
                {
                    Message = "Er is een interne serverfout opgetreden. Probeer het later opnieuw.",
                    Detailed = ex.Message, // Optioneel: verwijder dit in productie voor beveiliging
                    StatusCode = context.Response.StatusCode
                };

                // Schrijf de response als JSON terug
                var errorJson = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(errorJson);
            }
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LibrotekoWeb.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Logowanie zapytania
            Console.WriteLine("Zapytanie odebrane:");
            Console.WriteLine($"Metoda: {context.Request.Method}");
            Console.WriteLine($"Ścieżka: {context.Request.Path}");
            Console.WriteLine($"IP: {context.Connection.RemoteIpAddress}");
            Console.WriteLine($"Nagłówki: {string.Join("; ", context.Request.Headers)}");
            foreach (var header in context.Request.Headers)
            {
                Console.WriteLine($"Nagłówek: {header.Key} = {header.Value}");
            }


            // Przekazanie do kolejnego middleware
            await _next(context);
        }
    }
}

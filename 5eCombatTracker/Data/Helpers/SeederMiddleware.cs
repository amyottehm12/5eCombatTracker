using _5eCombatTracker.Data.Seeder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _5eCombatTracker.Data.Helpers
{
    public class SeederMiddleware
    {
        private readonly RequestDelegate _next;
        private IDbSeeder _dbSeeder;

        public SeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IDbSeeder seeder)
        {
            _dbSeeder = seeder;
            _dbSeeder.Seed();
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDbSeederMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeederMiddleware>();
        }
    }
}

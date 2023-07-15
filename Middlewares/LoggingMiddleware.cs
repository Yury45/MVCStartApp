using Microsoft.AspNetCore.Http;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository;
using MVCStartApp.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IRequestRepository requestRepository)
        {
            string logUrl = $"to http://{context.Request.Host.Value + context.Request.Path}";
            Console.WriteLine(logUrl);

            var request = new Request()
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = logUrl
            };

            await requestRepository.AddRequest(request);

                await _next.Invoke(context);
        }
    }
}

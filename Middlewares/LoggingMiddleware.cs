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
        private readonly IRequestRepository _requestRepository;

        public LoggingMiddleware(RequestDelegate next, IRequestRepository requestRepository)
        {
            _next = next;
            _requestRepository = requestRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            string logUrl = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}";
            Console.WriteLine(logUrl);

            var request = new Request()
            {
                Url = logUrl
            };

            _requestRepository.AddRequest(request);

            await _next.Invoke(context);
        }
    }
}

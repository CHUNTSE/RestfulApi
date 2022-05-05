using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApi.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext Context)
        {
            try
            {
                Context.Request.EnableBuffering();

                Stream requestStream = Context.Request.Body;

                _logger.LogTrace(ReadStream(requestStream));

                Context.Request.Body.Seek(0, SeekOrigin.Begin);

                await _next(Context);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
        }

        private string ReadStream(Stream stream)
        {
            string readtext = new StreamReader(stream).ReadToEnd();

            return readtext;
        }
    }
}

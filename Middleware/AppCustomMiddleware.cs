using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSoft.Day2.Middleware
{
    public class AppCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public AppCustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            this._loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //  pre-next phase logic
            ILogger<AppCustomMiddleware> logger = _loggerFactory.CreateLogger<AppCustomMiddleware>();
            logger.LogInformation("Pre-next logging: AppCustomMiddleware");

            await _next(context);
            //  post-next phase logic
            logger.LogInformation("Post-next logging: AppCustomMiddleware");
        }
    }
}

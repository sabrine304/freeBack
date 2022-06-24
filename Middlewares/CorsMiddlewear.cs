using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudProjectWebApi.Middlewares
{
    public class CorsMiddlewear
    {
        private readonly RequestDelegate _next;

        public CorsMiddlewear(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
          //  httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
          //  httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
          //  httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,    
          //  X-CSRF-Token, X-Requested-With, Accept-Version, Content-Length,
          //  Content MD5, Date, X- Api-Version, X-File-Name");
          //httpContext.Response.Headers.Add("Access-Control-Allow-Methods",
          // "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            return _next(httpContext);
        }
    }

}


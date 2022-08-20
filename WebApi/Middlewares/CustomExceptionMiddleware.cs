using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerService loggerService;

        public CustomExceptionMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            this.next = next;
            this.loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
                var watch = Stopwatch.StartNew();// neyin ne kadar sürede olduğunu izleten bir starter mekanizmasını başlatyır
            try//controllerda sürekli try cath yazmamak için burada try yaptık diğer yerde sildik.
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                loggerService.Write(message);

                await next(context);
                watch.Stop();

                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responsed " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                loggerService.Write(message);

            }
            catch (System.Exception ex)
            {

                watch.Stop();//hata yediğinde yukarıda bu kısım durmayacağı için burada durdurduk.
                await HandleException(context,ex,watch);//Exceptinları mantıklı yazmak için bir metot oluşturduk
            }

        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType="application/json"; 
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;//Bununla 500 değerini eriştik HTPP hata 500 olan
            string message="[Error  HTTP "+ context.Request.Method+ " - "+ context.Response.StatusCode + "Error Message" + ex.Message + " in "+watch.Elapsed.TotalMilliseconds+" ms ";
            loggerService.Write(message);
            // Mesaj işlemleribi JSON'a çevirip UI tarafı için rahatlatıyoruz. Json paketini uygulamaya ekledik.
            //dotnet add package Newtonsoft.Json  ile paketi ekledik

            var result= JsonConvert.SerializeObject(new {error=ex.Message},Formatting.None);//çeviridk
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}

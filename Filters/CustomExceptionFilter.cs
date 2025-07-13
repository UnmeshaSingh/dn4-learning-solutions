using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebAPI_WEEK_4.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "logs.txt");

            File.AppendAllText(logPath, $"[{DateTime.Now}] Exception: {context.Exception.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("Something went wrong.")
            {
                StatusCode = 500
            };
        }
    }
}

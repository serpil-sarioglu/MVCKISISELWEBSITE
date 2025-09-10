using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCKISISELWEBSITE.Filters
{
    public class LogFilter :ExceptionFilterAttribute, IActionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            //actiondan çıktıktan sonra çalışır
            File.AppendAllText("log.txt", $"{DateTime.Now}\t Hata\t{context.HttpContext.Request.Path}\t {context.Exception.Message}\n");

        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            //actiondan çıktıktan sonra çalışır
            File.AppendAllText("log.txt", $"{DateTime.Now}\tÇıkış\t{context.HttpContext.Request.Path}\n");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            //
            File.AppendAllText("log.txt", $"{DateTime.Now}\tGiriş\t{context.HttpContext.Request.Path}\n");
        }
    }
}

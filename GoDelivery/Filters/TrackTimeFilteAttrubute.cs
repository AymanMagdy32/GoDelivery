using Microsoft.AspNetCore.Mvc.Filters;

namespace GoDelivery.Filters
{

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
   public class TrachTimeFilterAttrubute : ActionFilterAttribute
    {
       public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
    var startDate = context.HttpContext.Items["ActionStartDate"] = DateTime.UtcNow ; 

     await next();   // lets move on 


     var elapsed =  DateTime.UtcNow - (DateTime)startDate ;

     context.HttpContext.Response.Headers.Append( "Elapsed Time " , $"{elapsed}");   
     
     System.Console.WriteLine( "Elapsed Time " , $"{elapsed}");   ;
            
        }
    }
}
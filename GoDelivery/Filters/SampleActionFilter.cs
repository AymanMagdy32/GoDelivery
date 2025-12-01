using Microsoft.AspNetCore.Mvc.Filters;

namespace GoDelivery.Filters
{

    public class SampleActionFilter : IAsyncActionFilter
    {
        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
   System.Console.WriteLine("Hii before ");

     await next();   // lets move on 
     
   System.Console.WriteLine("Hii After  ");

            
        }
    }



}
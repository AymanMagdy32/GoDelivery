using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoDelivery.Filters
{

 public class SampleResultFilter : IAsyncResultFilter
    {

       public async Task OnResultExecutionAsync( ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if(context.Result is ObjectResult objectResult && objectResult != null )
            {

    var wrapped = new
                {
                    success = true,
                    data = objectResult.Value
                };
     

             context.Result = new JsonResult(wrapped)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
            
            await next(); 
        }
            
        }
    
    }

 

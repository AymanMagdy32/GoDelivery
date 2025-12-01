

using System.ComponentModel.DataAnnotations;

namespace GoDelivery.Validations
{
    

public static class LaunchDateValidator
    {
        
   // you can use it as an attribute 
   // as [CustomValidation(Typeof(LaunchValidation) , nameof(MustBeTodayOrFuture) )]
      public static ValidationResult? MustBeTodayOrFuture(DateTime dateTime )
        {
            
            if(dateTime.Date >= DateTime.UtcNow.Date)
                
                return ValidationResult.Success ; 

        return  new ValidationResult("Date must be today or the future "); 
        } 





    }


}

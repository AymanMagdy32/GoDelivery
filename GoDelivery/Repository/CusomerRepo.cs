using System.Globalization;
using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;

public class CustomerRepo
{
    private readonly AppDbContext _context;

 public CustomerRepo(AppDbContext context)
{
    _context = context ; 
}
    
 
// C R U D 

 public async Task<Customer?> GetCustomerByIdAsync(Guid CustomerId, CancellationToken cancellationToken )
    {
         return await _context.Customers.FindAsync([CustomerId] , cancellationToken); 
    }

          
public async Task<List<Customer>> GetPaginatedCustomersAsync(
    int pageNumber = 1,
    int pageSize = 10,
    CancellationToken cancellationToken = default)
{
    if (pageNumber <= 0)
        pageNumber = 1;

    if (pageSize <= 0)
        pageSize = 10;

    return await _context.Customers
    .AsNoTracking()
    .Include(c => c.AppUser)  
    .OrderBy(c => c.AppUser!.FullName)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync(cancellationToken);
}

 
// For  just view use nooo tracking 

     public async Task<bool> DeleteCutomerById(Guid CustomerId, CancellationToken cancellationToken )
    {
         var customerToDelete =  await _context.Customers.FindAsync([CustomerId] , cancellationToken); 
         if(customerToDelete == null )
          return false ; 

          _context.Customers.Remove(customerToDelete); 
          await _context.SaveChangesAsync(cancellationToken); 
         return true ; 
    
    }



    public async Task<Customer?> GetCustomerByEmailPhone(string email , string phone , CancellationToken cancellationToken = default )
    {
        var customer = await _context.Customers
        .AsNoTracking()
        .Include(a=>a.AppUser)
        .FirstOrDefaultAsync(
        c=>c.AppUser.Email != null 
        &&
        (c.AppUser.Email == email || c.AppUser.PhoneNumber == phone) , cancellationToken ) ; 

        return customer ; 
    }


 

 

    


}
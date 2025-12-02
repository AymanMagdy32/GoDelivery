using System.Globalization;
using System.Threading.Tasks;
using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;

public class CustomerRepo : Repository<Customer>
{

 public CustomerRepo(AppDbContext context): base(context)
    {
    }
    
 
// C R U D

public async Task<List<Customer>> GetPaginatedCustomersAsync(
    int pageNumber,
    int pageSize,
    CancellationToken ct)
{
    return await _context.Customers
        .AsNoTracking()
        .Include(a=>a.Addresses)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync(ct);
}


 
// For  just view use nooo tracking 

 
    public async Task<Customer?> GetByEmailPhone(string email , string phone , CancellationToken cancellationToken = default )
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
    

public async Task<IEnumerable<Customer>> GetWithAddressesAsync
(CancellationToken cancellationToken = default )
        {
            var Customers =  await _context.Customers                    //. overusing of no Tracking 
                                            .Include(c => c.Addresses)
                                            .ToListAsync(cancellationToken);
            
            return Customers;
        }


 public async Task<Customer?> GetByAppUserIdAsync
(Guid AppUserId, CancellationToken cancellationToken = default )
        {
            var CustomerWithAddresses = await _context.Customers.Include(x => x.Addresses).AsNoTracking()
                                                      .FirstOrDefaultAsync(c => c.AppUserId == AppUserId , cancellationToken);
            
            return CustomerWithAddresses;
        }



}
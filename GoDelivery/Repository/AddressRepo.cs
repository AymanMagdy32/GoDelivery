using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;

public class AddressRepo
{
    private readonly AppDbContext _context;

    public AddressRepo(AppDbContext context)
    {
        _context = context;
    }

public async Task<List<Address>> GetAddressesByCustomerIdAsync(Guid customerId , CancellationToken cancellationToken)
    {
        
    return await _context.Addresses.AsNoTracking()
        .Where(a => a.CustomerId == customerId)
        .ToListAsync(cancellationToken);
    }


// Create // Delete // Update // Read 

public async Task<bool> DeleteAddressByAddressId(Guid AddressId, CancellationToken cancellationToken) 
    {
    var address = await _context.Addresses.FindAsync(new [] { AddressId }, cancellationToken);

         if(address == null )
         return false ;

         _context.Addresses.Remove(address); 
     return  await _context.SaveChangesAsync(cancellationToken) > 0 ;  
      

    }



public async Task AddAddressAsync(Address address , CancellationToken cancellationToken )
{
    if (address is null)
        throw new ArgumentNullException(nameof(address));

    await _context.Addresses.AddAsync(address , cancellationToken );
    await _context.SaveChangesAsync(cancellationToken); 
}









    
}

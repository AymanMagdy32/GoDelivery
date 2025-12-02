using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;

public class AddressRepo : Repository<Address>
{
    private readonly AppDbContext _context;

    public AddressRepo(AppDbContext context):base(context)
    {
        _context = context;
    }

public async Task<List<Address>> GetByCustomerIdAsync(Guid customerId , CancellationToken cancellationToken)
    {
        
    return await _context.Addresses.AsNoTracking()
        .Where(a => a.CustomerId == customerId)
        .ToListAsync(cancellationToken);
    }











    
}

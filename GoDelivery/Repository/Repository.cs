using GoDelivery.Models;
using Microsoft.EntityFrameworkCore;

public abstract class Repository <T> where T : class 
{
  protected readonly AppDbContext _context ; 
  protected Repository(AppDbContext dbContext )
  {
     _context = dbContext ;     
  }
//C R U D 
  
public async Task<bool> AddAsync(T entity, CancellationToken token)
{
    await _context.Set<T>().AddAsync(entity, token);
    return await _context.SaveChangesAsync(token) > 0;
}
    public async Task<T?> GetById (Guid id ,  CancellationToken cancellationToken = default  )
    {
        
         var obj =  await _context.Set<T>().FindAsync(new [] { id }, cancellationToken);

          return obj ; 
    } 

  public async Task<bool> Update (T entity , CancellationToken cancellationToken = default  )
    {
        
          _context.Set<T>().Update(entity); 
      return await _context.SaveChangesAsync(cancellationToken) > 0 ; 
    } 


public async Task<bool> DeleteAsync(T entity, CancellationToken token)
{
    _context.Set<T>().Remove(entity);
    return await _context.SaveChangesAsync(token) > 0;
}


}

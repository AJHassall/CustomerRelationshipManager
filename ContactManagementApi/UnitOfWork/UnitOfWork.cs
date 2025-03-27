using ContactManagementApi.Data;
using ContactManagementApi.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContactDbContext _context;
    public IContactRepository Contacts { get; private set; }
    public IFundRepository Funds { get; private set; }
    public IFundRelationshipRepository FundRelationships { get; private set; }


    public UnitOfWork(ContactDbContext context)
    {
        _context = context;
        Contacts = new ContactRepository(_context);
        Funds = new FundRepository(_context);
        FundRelationships = new FundRelationshipRepository(_context);
    }

    public void Complete()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
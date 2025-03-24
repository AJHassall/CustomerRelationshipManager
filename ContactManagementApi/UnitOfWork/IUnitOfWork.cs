using ContactManagementApi.Data.Repositories;

public interface IUnitOfWork : IDisposable
    {
        IContactRepository Contacts { get; }
        IFundRepository Funds { get; }

        void Complete();
    }
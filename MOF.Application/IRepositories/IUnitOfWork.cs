
namespace MOF.Application.IRepositories
{
    public  interface IUnitOfWork
    {



        Task SaveChange(CancellationToken cancellationToken);
    }
}

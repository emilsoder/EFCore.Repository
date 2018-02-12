using EFCore.Repository.Internals;

namespace EFCore.Repository
{
    public interface IRepository: IReadonlyRepository, IAsyncReadOnlyRepository, IInternalRepository { }
}
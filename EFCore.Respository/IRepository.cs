using EFCore.Respository.Internals;

namespace EFCore.Respository
{
    public interface IRepository : IReadonlyRepository, IAsyncReadOnlyRepository, IInternalRepository { }
}
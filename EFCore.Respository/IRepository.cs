using EFCore.Repository.Internals;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public interface IRepository: IReadonlyRepository, IAsyncReadOnlyRepository, IInternalRepository { }
}
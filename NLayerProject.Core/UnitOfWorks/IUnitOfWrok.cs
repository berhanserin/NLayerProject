using System.Threading.Tasks;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWrok
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }


        Task CommitAsync();

        void Commit();
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Service
{
    public interface IProductService:IService<Product>
    {
        //bool ControlInnerBarcode(Product product);
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
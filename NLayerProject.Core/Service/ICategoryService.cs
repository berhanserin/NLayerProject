using NLayerProject.Core.Models;
using System;
using System.Threading.Tasks;


namespace NLayerProject.Core.Service
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        //Categorye özgü metodlar burada tanımlanır.
    }
}
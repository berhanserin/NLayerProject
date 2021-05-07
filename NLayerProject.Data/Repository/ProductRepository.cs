using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await appDbContext.Products.Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == productId);

        }
    }
}
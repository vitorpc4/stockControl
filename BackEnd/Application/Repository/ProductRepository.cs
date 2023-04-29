using Application.Domain;
using Application.Domain.Models;
using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(DbStockContext dbContext) : base(dbContext)
        {
        }
    }
}

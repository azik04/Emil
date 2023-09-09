using StadiumRent.DAL.Interfaces;
using StadiumRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.DAL.Repositories
{
    public class OrderRepository : IBaseRepository<Orders>
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> CreateAsync(Orders Entity)
        {
            _db.Orders.Add(Entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Orders entity)
        {
            _db.Orders.Remove(entity);
            return true;
        }

        public IQueryable<Orders> GetAll()
        {
            return _db.Orders;
        }

        public async Task<Orders> Update(Orders Entity)
        {
             _db.Orders.Update(Entity);
             _db.SaveChanges();
            return Entity;
        }
    }
}

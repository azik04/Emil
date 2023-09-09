using StadiumRent.DAL.Interfaces;
using StadiumRent.Domain.Entity;
using StadiumRent.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumRent.DAL.Repositories
{
    public class UserRepository : IBaseRepository<Users>
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> CreateAsync(Users Entity) 
        {
            await _db.Users.AddAsync(Entity);
            await _db.SaveChangesAsync();   
            return true;
        }
        public async Task<bool> Delete(Users entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();   
            return true;
        }

        public IQueryable<Users> GetAll()
        {
            return _db.Users;
        }

        public async Task<Users> Update(Users Entity)
        {
            _db.Users.Update(Entity);
            await _db.SaveChangesAsync();
            return Entity;
        }
    }
}

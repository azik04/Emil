using Microsoft.EntityFrameworkCore;
using StadiumRent.DAL.Interfaces;
using StadiumRent.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StadiumRent.DAL.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly ApplicationDbContext _db;
        public StadiumRepository(ApplicationDbContext db) => _db = db;

        public async Task<bool> CreateAsync(Stadium Entity)
        {
            await _db.Stadium.AddAsync(Entity);
            _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Stadium entity)
        {
            _db.Stadium.Remove(entity);
            _db.SaveChangesAsync();
            return true;
        }

        public  IQueryable<Stadium> GetAll()
        {
            return  _db.Stadium;
        }

        public async Task<Stadium> GetbyName(string name)
        {
            return await _db.Stadium.SingleOrDefaultAsync(x => x.name == name);
        }


        public async Task<Stadium> Update(Stadium entity)
        {
            _db.Stadium.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

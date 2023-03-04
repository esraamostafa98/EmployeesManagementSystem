using AutoMapper;
using WebApplication1.BL.Interfaces;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class CountryRep:ICountryRep
    {
        private readonly DbContainer db;
        

        //  private DbContainer db = new DbContainer();
        public CountryRep(DbContainer db)
        {
            this.db = db;
            
        }
    


        IQueryable<CountryVM> ICountryRep.Get()
        {
            var data = db.Country.Select(c => new CountryVM { Id = c.Id, CountryName = c.CountryName });
            return data;
        }

        CountryVM ICountryRep.GetById(int id)
        {
            return db.Country.Where(a => a.Id == id)
                              .Select(c => new CountryVM { Id = c.Id, CountryName = c.CountryName})
                              .FirstOrDefault();
        }
    }
}

using WebApplication1.BL.Interfaces;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly DbContainer db;


        //  private DbContainer db = new DbContainer();
        public CityRep(DbContainer db)
        {
            this.db = db;

        }

        public IQueryable<CityVM> Get()
        {
            var data = db.City.Select(c => new CityVM { Id = c.Id, CityName = c.CityName ,CountryId=c.CountryId });
            return data;
        }

        public CityVM GetById(int id)
        {
            return db.City.Where(a => a.Id == id)
                             .Select(c => new CityVM { Id = c.Id, CityName = c.CityName, CountryId = c.CountryId })
                             .FirstOrDefault();
        }
    }
}

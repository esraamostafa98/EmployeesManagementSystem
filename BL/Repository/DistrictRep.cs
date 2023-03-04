using WebApplication1.BL.Interfaces;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class DistrictRep: IDistrictRep
    {
        private readonly DbContainer db;


        //  private DbContainer db = new DbContainer();
        public DistrictRep(DbContainer db)
        {
            this.db = db;

        }

        public IQueryable<DistrictVM> Get()
        {
            var data = db.District.Select(c => new DistrictVM { Id = c.Id, DistrictName = c.DistrictName, CityId = c.CityId });
            return data;
        }

        public DistrictVM GetById(int id)
        {
            return db.District.Where(a => a.Id == id)
                        .Select(c => new DistrictVM { Id = c.Id, DistrictName = c.DistrictName })
                        .FirstOrDefault();
        }
    }
}

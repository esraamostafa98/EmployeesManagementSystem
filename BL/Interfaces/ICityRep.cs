using WebApplication1.Models;

namespace WebApplication1.BL.Interfaces
{
    public interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetById(int id);
    }
}

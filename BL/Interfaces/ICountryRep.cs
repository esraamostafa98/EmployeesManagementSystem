using WebApplication1.Models;

namespace WebApplication1.BL.Interfaces
{
    public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        CountryVM GetById(int id);
    }
}

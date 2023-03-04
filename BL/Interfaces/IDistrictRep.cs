using WebApplication1.Models;

namespace WebApplication1.BL.Interfaces
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
        DistrictVM GetById(int id);
    }
}

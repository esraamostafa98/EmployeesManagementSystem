using WebApplication1.Models;

namespace WebApplication1.BL.Interfaces
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetById(int id);
        void Add(EmployeeVM emp);
        void Edit(EmployeeVM emp);
        void Delete(int id);
    }
}

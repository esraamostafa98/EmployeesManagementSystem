using WebApplication1.Models;

namespace WebApplication1.BL.Interfaces
{
    public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetById(int id);
        void Add(DepartmentVM dept);
        void Edit(DepartmentVM dept);
        void Delete(int id);
    }
}

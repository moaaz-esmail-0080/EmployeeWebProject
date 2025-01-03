
using BaseLibrary.Responses;
using ServerLibrary.Repositories.Interfaces;

using BaseLibrary.Entites;
using AppContext = ServerLibrary.Data.AppContext;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Repositories.Implementations // Corrected 'Implementaions' to 'Implementations'
{
    public class DepartmentRepository : IGenericRepositoryInterface<Department>
    {
        private readonly AppContext appContext;

        // Corrected constructor
        public DepartmentRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appContext.Departments.FindAsync(id);
            if (dep is null) return NotFound();

            appContext.Departments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await appContext
            .Departments.AsNoTracking()
            .ToListAsync();


        public async Task<Department> GetById(int id) => await appContext.Departments.FindAsync(id);


        public async Task<GeneralResponse> Insert(Department item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            appContext.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var dep = await appContext.Departments.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            dep.GeneralDepartmentId=item.GeneralDepartmentId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry department not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

   
       
    }
}

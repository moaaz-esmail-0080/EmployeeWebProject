
using BaseLibrary.Responses;
using ServerLibrary.Repositories.Interfaces;

using BaseLibrary.Entites;
using AppContext = ServerLibrary.Data.AppContext;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Repositories.Implementations // Corrected 'Implementaions' to 'Implementations'
{
    public class BranchRepository : IGenericRepositoryInterface<Branch>
    {
        private readonly AppContext appContext;

        // Corrected constructor
        public BranchRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appContext.Branches.FindAsync(id);
            if (dep is null) return NotFound();

            appContext.Branches.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Branch>> GetAll() => await appContext.Branches.ToListAsync();


        public async Task<Branch> GetById(int id) => await appContext.Branches.FindAsync(id);


        public async Task<GeneralResponse> Insert(Branch item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            appContext.Branches.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Branch item)
        {
            var dep = await appContext.Branches.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry department not found");
        private static GeneralResponse Success() => new(true, "Process Completed");
        private async Task Commit() => await appContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appContext.Branches.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }



    }
}


using BaseLibrary.Responses;
using ServerLibrary.Repositories.Interfaces;

using BaseLibrary.Entites;
using AppContext = ServerLibrary.Data.AppContext;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Repositories.Implementations // Corrected 'Implementaions' to 'Implementations'
{
    public class CountryRepository : IGenericRepositoryInterface<Country>
    {
        private readonly AppContext appContext;

        // Corrected constructor
        public CountryRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appContext.Countries.FindAsync(id);
            if (dep is null) return NotFound();

            appContext.Countries.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await appContext.Countries.ToListAsync();


        public async Task<Country> GetById(int id) => await appContext.Countries.FindAsync(id);


        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            appContext.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var dep = await appContext.Countries.FindAsync(item.Id);
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
            var item = await appContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }



    }
}

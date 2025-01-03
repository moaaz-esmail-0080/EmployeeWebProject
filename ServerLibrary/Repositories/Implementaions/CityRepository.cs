﻿
using BaseLibrary.Responses;
using ServerLibrary.Repositories.Interfaces;

using BaseLibrary.Entites;
using AppContext = ServerLibrary.Data.AppContext;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Repositories.Implementations // Corrected 'Implementaions' to 'Implementations'
{
    public class CityRepository : IGenericRepositoryInterface<City>
    {
        private readonly AppContext appContext;

        // Corrected constructor
        public CityRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appContext.Cities.FindAsync(id);
            if (dep is null) return NotFound();

            appContext.Cities.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await appContext
            .Cities
            .AsNoTracking()
            .Include(c => c.Country)
            .ToListAsync();



        public async Task<City> GetById(int id) => await appContext.Cities.FindAsync(id);


        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            appContext.Cities.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var dep = await appContext.Cities.FindAsync(item.Id);
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
            var item = await appContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }



    }
}

using ECommerce_App.Data;
using ECommerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class FlummeryInventoryManagement : IFlummeryInventory
    {
        private StoreDbContext _context;

        /// <summary>
        /// Instantiates an InventoryManagment object.
        /// </summary>
        /// <param name="context">
        /// StoreDBContext: an object that inherits from DbContext
        /// </param>
        public FlummeryInventoryManagement(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flummery>> GetAllFlummeries()
        {
            var allFlummeries = await _context.Flummery
                .ToListAsync();
            return allFlummeries;
        }

        public async Task<Flummery> GetFlummeryBy(int id)
        {
            var flummeryForId = await _context.Flummery.FindAsync(id);
            if (flummeryForId != null)
            {
                return flummeryForId;
            }
            return null;
        }

        public async Task<List<Flummery>> GetFlummeriesForSearch(string term)
        {
            var searchedFlummeries = await _context.Flummery
                .Where(x => EF.Functions.Like(x.Name, "%" + term + "%"))
                .ToListAsync();
            return searchedFlummeries;
        }

        public async Task<List<Flummery>> GetFlummeriesOrderedBy(string ordering)
        {
            List<Flummery> orderedFummeries;
            switch (ordering)
            {
                case "alphabetical":
                    orderedFummeries = await _context.Flummery
                        .OrderBy(x => x.Name)
                        .ToListAsync();
                    return orderedFummeries;
                case "alphabeticalRev":
                    orderedFummeries = await _context.Flummery
                        .OrderByDescending(x => x.Name)
                        .ToListAsync();
                    return orderedFummeries;
                default:
                    orderedFummeries = await _context.Flummery
                        .ToListAsync();
                    return orderedFummeries;
            }
        }

        public async Task<Flummery> CreateFlummery(Flummery flummery)
        {
            _context.Entry(flummery).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return flummery;
        }

        public async Task<Flummery> UpdateFlummery(Flummery flummery)
        {
            _context.Entry(flummery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flummery;
        }

        public async Task DeleteFlummery(int id)
        {
            var flummeryEntity = await _context.Flummery.FindAsync(id);
            if (flummeryEntity != null)
            {
                _context.Entry(flummeryEntity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}

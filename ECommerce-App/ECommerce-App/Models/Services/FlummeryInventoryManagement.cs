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

        /// <summary>
        /// Gets a Flummery by its id.
        /// </summary>
        /// <param name="id">
        /// int: the id of a Flummery
        /// </param>
        /// <returns>
        /// Task<Flummery>: a Flummery in a Task object if the id exists, null if not
        /// </returns>
        public async Task<Flummery> GetFlummeryBy(int id)
        {
            var flummeryForId = await _context.Flummery.FindAsync(id);
            if (flummeryForId != null)
            {
                return flummeryForId;
            }
            return null;
        }

        /// <summary>
        /// Gets a list of all Flummery objects that match the search term.
        /// </summary>
        /// <param name="term">
        /// string: a search term
        /// </param>
        /// <returns>
        /// Task<List<Flummery>>: a List of Flummerys in a Task object
        /// </returns>
        public async Task<List<Flummery>> GetFlummeriesForSearch(string term)
        {
            var searchedFlummeries = await _context.Flummery
                .Where(x => EF.Functions.Like(x.Name, "%" + term + "%"))
                .ToListAsync();
            return searchedFlummeries;
        }

        /// <summary>
        /// Gets a list of all Flummery objects ordered by ordering.
        /// </summary>
        /// <param name="ordering">
        /// string: a string describing how to order the list
        /// </param>
        /// <returns>
        /// Task<List<Flummery>>: a List of Flummerys in a Task object
        /// </returns>
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

        /// <summary>
        /// Creates a new Flummery object in the database.
        /// </summary>
        /// <param name="flummeryVM">
        /// Flummery: the object to be created in the database
        /// </param>
        /// <returns>
        /// Task<Flummery>: the Flummery object reflecting what was saved to the database, wrapped in a Task
        /// </returns>
        public async Task<Flummery> CreateFlummery(Flummery flummery)
        {
            _context.Entry(flummery).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return flummery;
        }

        /// <summary>
        /// Updates a Flummery object in the database.
        /// </summary>
        /// <param name="flummeryVM">
        /// Flummery: the object with updated information
        /// </param>
        /// <returns>
        /// Task<Flummery>: the Flummery object reflecting what was saved to the database, wrapped in a Task
        /// </returns>
        public async Task<Flummery> UpdateFlummery(Flummery flummery)
        {
            _context.Entry(flummery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flummery;
        }


        /// <summary>
        /// Deletes a Flummery from the database.
        /// </summary>
        /// <param name="id">
        /// int: the id of the Flummery to be deleted
        /// </param>
        /// <returns>
        /// Task: an empty Task object
        /// </returns>
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

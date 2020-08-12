using ECommerce_App.Data;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class InventoryManagement : IInventory
    {
        private StoreDbContext _context;

        public InventoryManagement(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<FlummeryVM>> GetAllFlummeries()
        {
            var allFlummeryVMs = await _context.Flummery
                .Select(x => new FlummeryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Manufacturer = x.Manufacturer,
                    Calories = x.Calories,
                    Weight = x.Weight,
                    Compliment = x.Compliment
                })
                .ToListAsync();
            return allFlummeryVMs;
        }

        public async Task<List<FlummeryVM>> GetFlummeriesForSearch(string term)
        {
            var searchedFlummeryVMs = await _context.Flummery
                .Where(x => x.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase))
                .Select(x => new FlummeryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Manufacturer = x.Manufacturer,
                    Calories = x.Calories,
                    Weight = x.Weight,
                    Compliment = x.Compliment
                })
                .ToListAsync();
            return searchedFlummeryVMs;
        }

        public async Task<List<FlummeryVM>> GetFlummeriesOrderedBy(string ordering)
        {
            List<FlummeryVM> orderedFummeryVMs;
            switch (ordering)
            {
                case "alphabetical":
                    orderedFummeryVMs = await _context.Flummery
                        .OrderBy(x => x.Name)
                        .Select(x => new FlummeryVM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Manufacturer = x.Manufacturer,
                            Calories = x.Calories,
                            Weight = x.Weight,
                            Compliment = x.Compliment
                        })
                        .ToListAsync();
                    return orderedFummeryVMs;
                case "alphabeticalRev":
                    orderedFummeryVMs = await _context.Flummery
                        .OrderByDescending(x => x.Name)
                        .Select(x => new FlummeryVM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Manufacturer = x.Manufacturer,
                            Calories = x.Calories,
                            Weight = x.Weight,
                            Compliment = x.Compliment
                        })
                        .ToListAsync();
                    return orderedFummeryVMs;
                default:
                    orderedFummeryVMs = await _context.Flummery
                        .Select(x => new FlummeryVM
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Manufacturer = x.Manufacturer,
                            Calories = x.Calories,
                            Weight = x.Weight,
                            Compliment = x.Compliment
                        })
                        .ToListAsync();
                    return orderedFummeryVMs;
            }
        }

        public async Task<FlummeryVM> CreateFlummery(FlummeryVM flummeryVM)
        {
            var flummeryEntity = ConvertFlummeryVMToEntity(flummeryVM);
            _context.Entry(flummeryEntity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return ConvertFlummeryEntityToVM(flummeryEntity);
        }

        public async Task<FlummeryVM> UpdateFlummery(FlummeryVM flummeryVM)
        {
            var flummeryEntity = ConvertFlummeryVMToEntity(flummeryVM);
            _context.Entry(flummeryEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ConvertFlummeryEntityToVM(flummeryEntity);
        }

        public async Task DeleteFlummery(int id)
        {
            var flummeryEntity = await _context.Flummery.FindAsync(id);
            _context.Entry(flummeryEntity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        private Flummery ConvertFlummeryVMToEntity(FlummeryVM flummeryVM)
        {
            return new Flummery
            {
                Id = flummeryVM.Id,
                Name = flummeryVM.Name,
                Manufacturer = flummeryVM.Manufacturer,
                Calories = flummeryVM.Calories,
                Weight = flummeryVM.Weight,
                Compliment = flummeryVM.Compliment
            };
        }

        private FlummeryVM ConvertFlummeryEntityToVM(Flummery flummery)
        {
            return new FlummeryVM
            {
                Id = flummery.Id,
                Name = flummery.Name,
                Manufacturer = flummery.Manufacturer,
                Calories = flummery.Calories,
                Weight = flummery.Weight,
                Compliment = flummery.Compliment
            };
        }
    }
}

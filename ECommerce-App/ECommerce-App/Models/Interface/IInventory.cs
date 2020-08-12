using ECommerce_App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    interface IInventory
    {
        Task<List<FlummeryVM>> GetAllFlummeries();

        Task<List<FlummeryVM>> GetFlummeriesForSearch(string term);

        Task<List<FlummeryVM>> GetFlummeriesOrderedBy(string ordering);

        Task<FlummeryVM> CreateFlummery(FlummeryVM flummeryVM);

        Task<FlummeryVM> UpdateFlummery(FlummeryVM flummeryVM);

        Task DeleteFlummery(int id);
    }
}

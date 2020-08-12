using ECommerce_App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    interface IInventory
    {
        /// <summary>
        /// Gets a list of all FlummeryVM objects saved to the database.
        /// </summary>
        /// <returns>
        /// Task<List<FlummeryVM>>: a List of FlummeryVMs in a Task object
        /// </returns>
        Task<List<FlummeryVM>> GetAllFlummeries();

        /// <summary>
        /// Gets a list of all FlummeryVM objects that match the search term.
        /// </summary>
        /// <param name="term">
        /// string: a search term
        /// </param>
        /// <returns>
        /// Task<List<FlummeryVM>>: a List of FlummeryVMs in a Task object
        /// </returns>
        Task<List<FlummeryVM>> GetFlummeriesForSearch(string term);

        /// <summary>
        /// Gets a list of all FlummeryVM objects ordered by ordering.
        /// </summary>
        /// <param name="ordering">
        /// string: a string describing how to order the list
        /// </param>
        /// <returns>
        /// Task<List<FlummeryVM>>: a List of FlummeryVMs in a Task object
        /// </returns>
        Task<List<FlummeryVM>> GetFlummeriesOrderedBy(string ordering);

        /// <summary>
        /// Creates a new FlummeryVM object in the database.
        /// </summary>
        /// <param name="flummeryVM">
        /// FlummeryVM: the object to be created in the database
        /// </param>
        /// <returns>
        /// Task<FlummeryVM>: the FlummeryVM object reflecting what was saved to the database, wrapped in a Task
        /// </returns>
        Task<FlummeryVM> CreateFlummery(FlummeryVM flummeryVM);

        /// <summary>
        /// Updates a FlummeryVM object in the database.
        /// </summary>
        /// <param name="flummeryVM">
        /// FlummeryVM: the object with updated information
        /// </param>
        /// <returns>
        /// Task<FlummeryVM>: the FlummeryVM object reflecting what was saved to the database, wrapped in a Task
        /// </returns>
        Task<FlummeryVM> UpdateFlummery(FlummeryVM flummeryVM);

        /// <summary>
        /// Deletes a FlummeryVM from the database.
        /// </summary>
        /// <param name="id">
        /// int: the id of the FlummeryVM to be deleted
        /// </param>
        /// <returns>
        /// Task: an empty Task object
        /// </returns>
        Task DeleteFlummery(int id);
    }
}

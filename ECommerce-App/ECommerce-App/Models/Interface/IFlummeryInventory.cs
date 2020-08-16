using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Interface
{
    public interface IFlummeryInventory
    {
        /// <summary>
        /// Gets a list of all Flummery objects saved to the database.
        /// </summary>
        /// <returns>
        /// Task<List<Flummery>>: a List of Flummerys in a Task object
        /// </returns>
        Task<List<Flummery>> GetAllFlummeries();

        /// <summary>
        /// Gets a Flummery by its id.
        /// </summary>
        /// <param name="id">
        /// int: the id of a Flummery
        /// </param>
        /// <returns>
        /// Task<Flummery>: a Flummery in a Task object if the id exists, null if not
        /// </returns>
        Task<Flummery> GetFlummeryBy(int id);

        /// <summary>
        /// Gets a list of all Flummery objects that match the search term.
        /// </summary>
        /// <param name="term">
        /// string: a search term
        /// </param>
        /// <returns>
        /// Task<List<Flummery>>: a List of Flummerys in a Task object
        /// </returns>
        Task<List<Flummery>> GetFlummeriesForSearch(string term);

        /// <summary>
        /// Gets a list of all Flummery objects ordered by ordering.
        /// </summary>
        /// <param name="ordering">
        /// string: a string describing how to order the list
        /// </param>
        /// <returns>
        /// Task<List<Flummery>>: a List of Flummerys in a Task object
        /// </returns>
        Task<List<Flummery>> GetFlummeriesOrderedBy(string ordering);

        /// <summary>
        /// Creates a new Flummery object in the database.
        /// </summary>
        /// <param name="flummeryVM">
        /// Flummery: the object to be created in the database
        /// </param>
        /// <returns>
        /// Task<Flummery>: the Flummery object reflecting what was saved to the database, wrapped in a Task
        /// </returns>
        Task<Flummery> CreateFlummery(Flummery flummery);

        /// <summary>
        /// Updates a Flummery object in the database.
        /// </summary>
        /// <param name="flummeryVM">
        /// Flummery: the object with updated information
        /// </param>
        /// <returns>
        /// Task<Flummery>: the Flummery object reflecting what was saved to the database, wrapped in a Task
        /// </returns>
        Task<Flummery> UpdateFlummery(Flummery flummery);

        /// <summary>
        /// Deletes a Flummery from the database.
        /// </summary>
        /// <param name="id">
        /// int: the id of the Flummery to be deleted
        /// </param>
        /// <returns>
        /// Task: an empty Task object
        /// </returns>
        Task DeleteFlummery(int id);
    }
}

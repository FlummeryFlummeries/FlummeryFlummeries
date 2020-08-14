using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using ECommerce_App.Models.Interface;
using ECommerce_App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_App.Controllers
{
    public class HomeController : Controller
    {
        public IFlummeryInventory _inventory { get; set; }

        public HomeController(IFlummeryInventory inventory)
        {
            _inventory = inventory;
        }
        public async Task<IActionResult> Index()
        {
            List<FlummeryVM> all = await _inventory.GetAllFlummeries();
            List<FlummeryVM> selected = new List<FlummeryVM>();
            Random rand = new Random();
            List<int> usedNums = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int newNum = rand.Next(all.Count() - 1);
                if (usedNums.Contains(newNum))
                {
                    i--;
                }
                else
                {
                    usedNums.Add(newNum);
                    selected.Add(all[newNum]); 
                }
            }

            return View(selected);
        }
    }
}

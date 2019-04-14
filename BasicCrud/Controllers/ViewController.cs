using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrud.Models;
using BasicCrud.Services;
using BasicCrud.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    public class ViewController : Controller
    {
        /// <summary>
        /// Used to interact with the food database
        /// </summary>
        private readonly FoodService _foodService;

        public ViewController(FoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ViewViewModel model)
        {
            if (ModelState.IsValid)
            {
                // make sure we normalize the name if it's provided
                if (model.Filter.Name != null)
                {
                    model.Filter.Name = model.Filter.Name.PrepForDb();
                }

                // grab the foods that match the filter, ordered by the name
                model.Foods = await _foodService.GetFilteredAsync(model.Filter, food => food.Name);
            }
            else
            {
                ModelState.AddModelError("", "Invalid input.");
            }

            return View(model);
        }
    }
}
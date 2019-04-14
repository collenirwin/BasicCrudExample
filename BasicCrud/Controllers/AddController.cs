using BasicCrud.Models;
using BasicCrud.Services;
using BasicCrud.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BasicCrud.Controllers
{
    public class AddController : Controller
    {
        /// <summary>
        /// Used to interact with the food database
        /// </summary>
        private readonly FoodService _foodService;

        public AddController(FoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Success"] = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Food food)
        {
            ViewData["Success"] = false;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid input.");
                return View(food);
            }

            // make sure we prep the food for the database
            food.Id = Guid.NewGuid().ToString();
            food.Name = food.Name.PrepForDb();

            // insert!
            await _foodService.AddAsync(food);

            // let the view know that we added the food successfully
            ViewData["Success"] = true;

            // this will clear the inputs to prepare for the next entry
            ModelState.Clear();
            return View();
        }
    }
}
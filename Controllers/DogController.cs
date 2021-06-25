using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public DogController(IDogRepository dogRepository)
        {
            _dogRepo = dogRepository;
        }

        // GET: DogRepository
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);

            return View(dogs);
        }

        // GET: DogRepository/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // GET: DogRepository/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogRepository/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Dog dog)
        {
            try
            {
                dog.OwnerId = GetCurrentUserId();

                _dogRepo.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
           {
                return View(dog);
            }
        }

        // GET: DogRepository/Edit/5
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);
            int ownerId = GetCurrentUserId();

            if (dog == null)
            {
                return NotFound();
            }
            if (dog.OwnerId != ownerId)
            {
                return Unauthorized();
            }

            return View(dog);
        }

        // POST: DogRepository/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                dog.OwnerId = GetCurrentUserId();
                _dogRepo.UpdateDog(dog);

                    return RedirectToAction("Index");
            }
                catch
                {
                    return View(dog);
             }
}
            
        

        // GET: DogRepository/Delete/5
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            if (dog.OwnerId == GetCurrentUserId())
            {
                return View(dog);
            }
            else
            {
                return Unauthorized();
            }

        }
        // POST: DogRepository/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.DeleteDog(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(dog);
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}

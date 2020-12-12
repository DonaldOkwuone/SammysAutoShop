using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAutoShop.Data;
using SammysAutoShop.Models;

namespace SammysAutoShop.Controllers
{
    public class ServiceTypesController : Controller
    {
        public ApplicationDbContext _db { get; set; }

        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET : ServiceTypes
        public IActionResult Index()
        {

            return View(_db.ServiceTypes.ToList());
        }

        //GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Services/Create
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(serviceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}

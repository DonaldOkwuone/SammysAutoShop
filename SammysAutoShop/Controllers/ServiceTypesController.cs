using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        //Details: ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);

            if(serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        //Edit: ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        //Delete ServiceTypes/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        //Post Delete 
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveServiceType(int Id)
        { 

            var serviceType = _db.ServiceTypes.SingleOrDefaultAsync(m=> Id == m.Id);
            _db.ServiceTypes.Remove(serviceType.Result);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, ServiceType serviceType)
        {
            if(Id != serviceType.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _db.ServiceTypes.Update(serviceType);
                await _db.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            } 
            return RedirectToAction(nameof(Index));
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

using CrudMVC.Data;
using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactos.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Contactos.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContact(int? id)
        {
            var contacto = _context.Contactos.Find(id);
            if (contacto == null)
            {
                return View();
            }
            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
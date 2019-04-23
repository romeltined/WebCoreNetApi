using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreNetApi;
using WebCoreNetApi.Models;

namespace WebCoreNetApi.Controllers
{
    public class Dhts1Controller : Controller
    {
        private readonly ArduinoContext _context;

        public Dhts1Controller(ArduinoContext context)
        {
            _context = context;
        }

        // GET: Dhts1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dhts.ToListAsync());
        }

        // GET: Dhts1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dht = await _context.Dhts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dht == null)
            {
                return NotFound();
            }

            return View(dht);
        }

        // GET: Dhts1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dhts1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature,Humidity,CreatedDateTime")] Dht dht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dht);
        }

        // GET: Dhts1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dht = await _context.Dhts.FindAsync(id);
            if (dht == null)
            {
                return NotFound();
            }
            return View(dht);
        }

        // POST: Dhts1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature,Humidity,CreatedDateTime")] Dht dht)
        {
            if (id != dht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DhtExists(dht.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dht);
        }

        // GET: Dhts1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dht = await _context.Dhts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dht == null)
            {
                return NotFound();
            }

            return View(dht);
        }

        // POST: Dhts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dht = await _context.Dhts.FindAsync(id);
            _context.Dhts.Remove(dht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DhtExists(int id)
        {
            return _context.Dhts.Any(e => e.Id == id);
        }
    }
}

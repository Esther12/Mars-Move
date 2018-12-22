using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM2.Models;

namespace CRM2.Controllers
{
    public class CusController : Controller
    {
        private readonly ManagementContext _context;

        public CusController(ManagementContext context)
        {
            _context = context;
        }

        // GET: Cus
        public async Task<IActionResult> Index()
        {
            var managementContext = _context.Customers.Include(c => c.Invoice);
            return View(await managementContext.ToListAsync());
        }

        // GET: Cus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Invoice)
                .SingleOrDefaultAsync(m => m.Cus_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Cus/Create
        public IActionResult Create()
        {
            ViewData["Inv_ID"] = new SelectList(_context.Invoices, "Inv_ID", "Inv_ID");
            return View();
        }

        // POST: Cus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cus_ID,Cus_lname,Cus_fname,Cus_phone,Cus_email,Cus_street,Cus_city,Cus_pro,Cus_country,Inv_ID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Inv_ID"] = new SelectList(_context.Invoices, "Inv_ID", "Inv_ID", customer.Inv_ID);
            return View(customer);
        }

        // GET: Cus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Cus_ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["Inv_ID"] = new SelectList(_context.Invoices, "Inv_ID", "Inv_ID", customer.Inv_ID);
            return View(customer);
        }

        // POST: Cus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cus_ID,Cus_lname,Cus_fname,Cus_phone,Cus_email,Cus_street,Cus_city,Cus_pro,Cus_country,Inv_ID")] Customer customer)
        {
            if (id != customer.Cus_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Cus_ID))
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
            ViewData["Inv_ID"] = new SelectList(_context.Invoices, "Inv_ID", "Inv_ID", customer.Inv_ID);
            return View(customer);
        }

        // GET: Cus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Invoice)
                .SingleOrDefaultAsync(m => m.Cus_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Cus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Cus_ID == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Cus_ID == id);
        }
    }
}

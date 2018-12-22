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
    public class EmpController : Controller
    {
        private readonly ManagementContext _context;

        public EmpController(ManagementContext context)
        {
            _context = context;
        }

        // GET: Emp
        public async Task<IActionResult> Index()
        {
            var managementContext = _context.Employees.Include(e => e.Customer);
            return View(await managementContext.ToListAsync());
        }

        // GET: Emp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Customer)
                .SingleOrDefaultAsync(m => m.Emp_ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Emp/Create
        public IActionResult Create()
        {
            ViewData["Cus_ID"] = new SelectList(_context.Customers, "Cus_ID", "Cus_ID");
            return View();
        }

        // POST: Emp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emp_ID,Emp_lname,Emp_fname,Emp_phone,Emp_email,Cus_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cus_ID"] = new SelectList(_context.Customers, "Cus_ID", "Cus_ID", employee.Cus_ID);
            return View(employee);
        }

        // GET: Emp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.SingleOrDefaultAsync(m => m.Emp_ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Cus_ID"] = new SelectList(_context.Customers, "Cus_ID", "Cus_ID", employee.Cus_ID);
            return View(employee);
        }

        // POST: Emp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Emp_ID,Emp_lname,Emp_fname,Emp_phone,Emp_email,Cus_ID")] Employee employee)
        {
            if (id != employee.Emp_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Emp_ID))
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
            ViewData["Cus_ID"] = new SelectList(_context.Customers, "Cus_ID", "Cus_ID", employee.Cus_ID);
            return View(employee);
        }

        // GET: Emp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Customer)
                .SingleOrDefaultAsync(m => m.Emp_ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(m => m.Emp_ID == id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Emp_ID == id);
        }
    }
}

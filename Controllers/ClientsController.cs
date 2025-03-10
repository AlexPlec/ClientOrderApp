using ClientOrderApp.Data;
using ClientOrderApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientOrderApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientOrderAppDbContext _context;

        public ClientsController(ClientOrderAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _context.Clients
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Email,
                    c.Birthdate,
                    Gender = c.Gender.ToString(),
                    Orders = c.Orders.Select(o => new
                    {
                        o.Id,
                        o.Product.Title,
                        o.Quantity,
                        TotalAmount = o.Quantity * o.Product.Price,
                        o.Status
                    }).ToList(),
                    OrderCount = c.Orders.Count,
                    AverageOrderAmount = c.Orders.Any() ? c.Orders.Average(o => o.Quantity * o.Product.Price) : 0
                })
                .ToListAsync();

            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return NotFound();
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Client client)
        {
            if (id != client.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return NotFound();
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
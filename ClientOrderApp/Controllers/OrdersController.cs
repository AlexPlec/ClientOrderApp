using ClientOrderApp.Data;
using ClientOrderApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClientOrderApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ClientOrderAppDbContext _context;

        public OrdersController(ClientOrderAppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Select(o => new
                {
                    o.Id,
                    ProductTitle = o.Product.Title,
                    o.Quantity,
                    TotalAmount = o.Quantity * o.Product.Price,
                    o.Status,
                    ClientName = o.Client.Name
                })

                .ToListAsync();

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Clients"] = _context.Clients.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            ViewData["Products"] = _context.Products.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Title });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            order.Client = await _context.Clients.FindAsync(order.ClientId);
            order.Product = await _context.Products.FindAsync(order.ProductId);

            _context.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            ViewData["Clients"] = _context.Clients.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            ViewData["Products"] = _context.Products.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Title });

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {

            order.Client = await _context.Clients.FindAsync(order.ClientId);
            order.Product = await _context.Products.FindAsync(order.ProductId);

            _context.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //  var order = await _context.Orders.FindAsync(id);
            var order = await _context.Orders
      .Include(o => o.Client) // Include the related Client
      .Include(o => o.Product) // Include the related Product
      .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
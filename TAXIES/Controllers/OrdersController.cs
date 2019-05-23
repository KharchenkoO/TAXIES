using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAXIES.Data;
using TAXIES.Models;

namespace TAXIES.Controllers
{
    public class OrdersController : Controller
    {
        private readonly TaxiContext _context;

        public OrdersController(TaxiContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var taxiContext = _context.Orders.Include(o => o.Car).Include(o => o.Client).Include(o => o.Driver)
                .AsNoTracking();
            return View(await taxiContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.Client)
                .Include(o => o.Driver)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Create()
        {
            DriversDropDownList();
            ClientsDropDownList();
            CarsDropDownList();
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,ClientID,DriverID,CarID,DepPlace,DestPlace,Time")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            DriversDropDownList(order.DriverID);
            ClientsDropDownList(order.ClientID);
            CarsDropDownList(order.CarID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            DriversDropDownList(order.DriverID);
            ClientsDropDownList(order.ClientID);
            CarsDropDownList(order.CarID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToUpdate = await _context.Orders
                .FirstOrDefaultAsync(c => c.OrderID == id);

            if (await TryUpdateModelAsync<Order>(orderToUpdate,
                "",
                c => c.ClientID, c => c.DriverID, c => c.CarID, c => c.DepPlace, c => c.DestPlace, c => c.Time))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            DriversDropDownList(orderToUpdate.DriverID);
            ClientsDropDownList(orderToUpdate.ClientID);
            CarsDropDownList(orderToUpdate.CarID);
            return View(orderToUpdate);
        }

        private void DriversDropDownList(object selectedDriver = null)
        {
            var driversQuery = from d in _context.Drivers
                                   orderby d.DriverName
                                   select d;
            ViewBag.DriverID = new SelectList(driversQuery.AsNoTracking(), "DriverID", "DriverName", selectedDriver);
        }

        private void ClientsDropDownList(object selectedClient = null)
        {
            var clientsQuery = from d in _context.Clients
                               orderby d.ClientName
                               select d;
            ViewBag.ClientID = new SelectList(clientsQuery.AsNoTracking(), "ClientID", "ClientName", selectedClient);
        }

        private void CarsDropDownList(object selectedCar = null)
        {
            var carsQuery = from d in _context.Cars
                               orderby d.CarNumber
                               select d;
            ViewBag.CarID = new SelectList(carsQuery.AsNoTracking(), "CarID", "CarNumber", selectedCar);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.Client)
                .Include(o => o.Driver)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}

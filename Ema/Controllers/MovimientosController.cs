using Ema.Data;
using Ema.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ema.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly IMovimientoService movimientoService;

        //public MovimientosController(EmaContext context)
        //{
        //    movimientoService = new MovimientoService(context);
        //}

        //para UT, hasta que tenga una mejor idea
        //Jo JO lo inyecto desde el startup.cs
        public MovimientosController(IMovimientoService service)
        {
            movimientoService = service;
        }

        // GET: Movimientos
        public async Task<IActionResult> Index()
        {
            return View(nameof(Index), await movimientoService.GetAllAsync());
        }

        // GET: Movimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await movimientoService.FindByIdAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // GET: Movimientos/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: Movimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Importe,Descripcion,Fecha,TipoMovimento,Estado,Regularidad")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                await movimientoService.AddAsync(movimiento);

                return RedirectToAction(nameof(Index));
            }
            return View(movimiento);
        }

        // GET: Movimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await movimientoService.FindByIdAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }
            return View(movimiento);
        }

        // POST: Movimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Importe,Descripcion,Fecha,TipoMovimento,Estado,Regularidad")] Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await movimientoService.UpdateAsync(movimiento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoExists(movimiento.Id))
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
            return View(movimiento);
        }

        // GET: Movimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await movimientoService.FindByIdAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await movimientoService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoExists(int id)
        {
            return movimientoService.FindById(id) != null;
        }
    }
}

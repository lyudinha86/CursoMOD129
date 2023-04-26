using CursoMOD129.Data;
using CursoMOD129.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CursoMOD129.Controllers
{
    namespace CursoMOD129.Controllers
    {
        public class ClienteController : Controller
        {
            private readonly ApplicationDbContext _context;

            public ClienteController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Cliente
                public IActionResult Index()
                {
                    var clientes = _context.Clients.ToList();

                    //if (clientes == null)
                    //{
                    //    clientes = new List<Cliente>();
                    //}

                    return View(clientes);
                }

                // GET: Cliente/Create
                public IActionResult Create()
            {
                return View();
            }

            // POST: Cliente/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("ID,Name,Birthday,Address,ZipCode,City,NIF,HealthCareNumber")] Cliente cliente)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente); 
                    await _context.SaveChangesAsync(); 
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
            // GET: Cliente/Edit/5
            //public async Task<IActionResult> Edit(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var cliente = await _context.Clients.FindAsync(id);
            //    if (cliente == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(cliente);
            //}
            public IActionResult Edit(int id) {

                Cliente? cliente = _context.Clients.Find(id);
               if(cliente==null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            //// POST: Cliente/Edit/5
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Birthday,Address,ZipCode,City,NIF,HealthCareNumber")] Cliente cliente)
            //{
            //    if (id != cliente.ID)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(cliente);
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!ClienteExists(cliente.ID))
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(cliente);
            //}
            [HttpPost]
            public IActionResult Edit(Cliente editingClient) 
            { 
                if (ModelState.IsValid)
                {

                    _context.Clients.Update(editingClient);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                
                }
                return View(editingClient);
            }

           // GET: Cliente/Delete/5
            //public async Task<IActionResult> Delete(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var cliente = await _context.Clients
            //        .FirstOrDefaultAsync(m => m.ID == id);

            //    if (cliente == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(cliente);
            //}


            public IActionResult Delete(int id)
            {
                Cliente? cliente =_context.Clients.Find(id);
                if(cliente==null)
                {
                    return NotFound();  
                }
                return View(cliente);
            }
            //POST: Cliente/DeleteConfirmed/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var cliente = await _context.Clients.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                _context.Clients.Remove(cliente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public IActionResult DeleteConfirmed(int id)
            //{

            //    Cliente? deletingCliente = _context.Clients.Find(id);
            //    if(deletingCliente==null)
            //    {
            //        _context.Clients.Remove(deletingCliente);
            //        _context.SaveChanges();
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            private bool ClienteExists(int id)
            {
                return _context.Clients.Any(e => e.ID == id);
            }
        }
    }
}
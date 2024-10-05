using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaEntityFramework.Models;

namespace AulaEntityFramework.Controllers
{
    public class TimePessoasController : Controller
    {
        private readonly MyDbContext _context;

        public TimePessoasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TimePessoas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.TimesPessoas.Include(t => t.Pessoa).Include(t => t.Time);
            return View(await myDbContext.ToListAsync());
        }

        // GET: TimePessoas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timePessoa = await _context.TimesPessoas
                .Include(t => t.Pessoa)
                .Include(t => t.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timePessoa == null)
            {
                return NotFound();
            }

            return View(timePessoa);
        }

        // GET: TimePessoas/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id");
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id");
            return View();
        }

        // POST: TimePessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeId,PessoaId,DataEntrada,DataSaida")] TimePessoa timePessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timePessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", timePessoa.PessoaId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id", timePessoa.TimeId);
            return View(timePessoa);
        }

        // GET: TimePessoas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timePessoa = await _context.TimesPessoas.FindAsync(id);
            if (timePessoa == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", timePessoa.PessoaId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id", timePessoa.TimeId);
            return View(timePessoa);
        }

        // POST: TimePessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TimeId,PessoaId,DataEntrada,DataSaida")] TimePessoa timePessoa)
        {
            if (id != timePessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timePessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimePessoaExists(timePessoa.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Id", timePessoa.PessoaId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Id", timePessoa.TimeId);
            return View(timePessoa);
        }

        // GET: TimePessoas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timePessoa = await _context.TimesPessoas
                .Include(t => t.Pessoa)
                .Include(t => t.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timePessoa == null)
            {
                return NotFound();
            }

            return View(timePessoa);
        }

        // POST: TimePessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var timePessoa = await _context.TimesPessoas.FindAsync(id);
            if (timePessoa != null)
            {
                _context.TimesPessoas.Remove(timePessoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimePessoaExists(long id)
        {
            return _context.TimesPessoas.Any(e => e.Id == id);
        }
    }
}

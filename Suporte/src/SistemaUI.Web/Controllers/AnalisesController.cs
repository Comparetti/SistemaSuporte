using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInfra.Data;
using SuporteCore.Entity;

namespace SistemaUI.Web.Controllers
{
    public class AnalisesController : Controller
    {
        private readonly SuporteContext _context;

        public AnalisesController(SuporteContext context)
        {
            _context = context;
        }

        // GET: Analises
        public async Task<IActionResult> Index()
        {
            var suporteContext = _context.Analise.Include(a => a.Phoebus);
            return View(await suporteContext.ToListAsync());
        }

        // GET: Analises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var analise = await _context.Analise
                .Include(a => a.Phoebus)
                .FirstOrDefaultAsync(m => m.ANaliseId == id);
            if (analise == null)
            {
                return NotFound();
            }

            return View(analise);
        }

        // GET: Analises/Create
        public IActionResult Create()
        {
            ViewData["PhoebusId"] = new SelectList(_context.Phoebus, "PhoebusId", "Card_number");
            return View();
        }

        // POST: Analises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ANaliseId,CpfCnpj,NomeRazao,PhoebusId,Nsu,Card_number,Terminal,Confirmation_date,Date_base")] Analise analise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhoebusId"] = new SelectList(_context.Phoebus, "PhoebusId", "Card_number", analise.PhoebusId);
            return View(analise);
        }

        // GET: Analises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analise = await _context.Analise.FindAsync(id);
            if (analise == null)
            {
                return NotFound();
            }
            ViewData["PhoebusId"] = new SelectList(_context.Phoebus, "PhoebusId", "Card_number", analise.PhoebusId);
            return View(analise);
        }

        // POST: Analises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ANaliseId,CpfCnpj,NomeRazao,PhoebusId,Nsu,Card_number,Terminal,Confirmation_date,Date_base")] Analise analise)
        {
            if (id != analise.ANaliseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaliseExists(analise.ANaliseId))
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
            ViewData["PhoebusId"] = new SelectList(_context.Phoebus, "PhoebusId", "Card_number", analise.PhoebusId);
            return View(analise);
        }

        // GET: Analises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analise = await _context.Analise
                .Include(a => a.Phoebus)
                .FirstOrDefaultAsync(m => m.ANaliseId == id);
            if (analise == null)
            {
                return NotFound();
            }

            return View(analise);
        }

        // POST: Analises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analise = await _context.Analise.FindAsync(id);
            _context.Analise.Remove(analise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaliseExists(int id)
        {
            return _context.Analise.Any(e => e.ANaliseId == id);
        }
    }
}

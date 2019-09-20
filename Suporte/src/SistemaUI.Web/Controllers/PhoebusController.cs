using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Service;

namespace SistemaUI.Web.Controllers
{
    public class PhoebusController : Controller
    {
        private readonly SuporteContext _context;
        private readonly IPhoebusService _phoebusService;

        public PhoebusController(SuporteContext context, IPhoebusService phoebusService)
        {
            _phoebusService = phoebusService;
            _context = context;
        }

        // GET: Phoebus
        [HttpGet("api/ph")]
        public async Task<IActionResult> Index(string search, DateTime? minDate, DateTime? maxDate, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var result = await _phoebusService.FindByPhoebusAsync(minDate, maxDate, search);
                ViewData["Filter"] = search;
                ViewData["minDate"] = result.Item2.Value.ToString("yyyy-MM-dd");
                ViewData["maxDate"] = result.Item3.Value.ToString("yyyy-MM-dd");
                return View(result.Item1);
            }
            return View(await PagingList.CreateAsync(_context.Phoebus.AsNoTracking().OrderByDescending(r => r.Date_base), 20, page));
        }

        // GET: Phoebus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var phoebus = await _context.Phoebus
                .FirstOrDefaultAsync(m => m.PhoebusId == id);
            if (phoebus == null)
                return NotFound();

            return View(phoebus);
        }

        // GET: Phoebus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var phoebus = await _context.Phoebus.FindAsync(id);
            if (phoebus == null)
                return NotFound();

            return View(phoebus);
        }

        // GET: Phoebus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var phoebus = await _context.Phoebus
                .FirstOrDefaultAsync(m => m.PhoebusId == id);
            if (phoebus == null)
                return NotFound();

            return View(phoebus);
        }

        // POST: Phoebus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoebus = await _context.Phoebus.FindAsync(id);
            _context.Phoebus.Remove(phoebus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

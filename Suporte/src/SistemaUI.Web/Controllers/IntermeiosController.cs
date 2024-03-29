﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SistemaInfra.Data;
using SuporteCore.Entity;
using SuporteCore.Interfaces.Service;

namespace SistemaUI.Web.Controllers
{
    public class IntermeiosController : Controller
    {
        private readonly IIntermeioService _interService;
        private readonly SuporteContext _context;

        public IntermeiosController(SuporteContext context, IIntermeioService inter)
        {
            _interService = inter;
            _context = context;
        }

        // GET: Intermeios
        public async Task<IActionResult> Index(string search, DateTime? minDate, DateTime? maxDate, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var result = await _interService.FindByIntermeioAsync(minDate, maxDate, search);
                ViewData["Filter"] = search;
                ViewData["minDate"] = result.Item2.Value.ToString("yyyy-MM-dd");
                ViewData["maxDate"] = result.Item3.Value.ToString("yyyy-MM-dd");
                return View(result.Item1);
            }
            return View(await PagingList.CreateAsync(_context.Intermeio.AsNoTracking().OrderByDescending(r => r.Date_base), 20, page));
        }

        // GET: Intermeios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermeio = await _context.Intermeio
                .FirstOrDefaultAsync(m => m.IntermeioId == id);
            if (intermeio == null)
            {
                return NotFound();
            }

            return View(intermeio);
        }

        // GET: Intermeios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intermeios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntermeioId,TransacaoId,Bandeira,CodAutorizacao,Valor,PosId,Modelo,NumeroDeSerie,TID,MID,UsuarioId,CpfCnpj,NomeRazao,Status,SaldoLiberado,Email,Nsu,Card_number,Terminal,Confirmation_date,Date_base")] Intermeio intermeio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intermeio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intermeio);
        }

        // GET: Intermeios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermeio = await _context.Intermeio.FindAsync(id);
            if (intermeio == null)
            {
                return NotFound();
            }
            return View(intermeio);
        }

        // POST: Intermeios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntermeioId,TransacaoId,Bandeira,CodAutorizacao,Valor,PosId,Modelo,NumeroDeSerie,TID,MID,UsuarioId,CpfCnpj,NomeRazao,Status,SaldoLiberado,Email,Nsu,Card_number,Terminal,Confirmation_date,Date_base")] Intermeio intermeio)
        {
            if (id != intermeio.IntermeioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intermeio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntermeioExists(intermeio.IntermeioId))
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
            return View(intermeio);
        }

        // GET: Intermeios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intermeio = await _context.Intermeio
                .FirstOrDefaultAsync(m => m.IntermeioId == id);
            if (intermeio == null)
            {
                return NotFound();
            }

            return View(intermeio);
        }

        // POST: Intermeios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intermeio = await _context.Intermeio.FindAsync(id);
            _context.Intermeio.Remove(intermeio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntermeioExists(int id)
        {
            return _context.Intermeio.Any(e => e.IntermeioId == id);
        }
    }
}

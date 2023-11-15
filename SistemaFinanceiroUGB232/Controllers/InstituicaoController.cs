using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFinanceiroUGB232.Data;
using SistemaFinanceiroUGB232.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaFinanceiroUGB232.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly AcademicoContext _context;
        public InstituicaoController(AcademicoContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
        }
        //private static IList<Instituicao> instituicoes = new List<Instituicao>()
        //{
        //    new Instituicao()
        //    {
        //        InstituicaoID = 1,
        //        Nome = "Hogwarts",
        //        Endereco = "Escócia"
        //    },
        //    new Instituicao()
        //    {
        //        InstituicaoID = 2,
        //        Nome = "Mansão X",
        //        Endereco = "Nova York"
        //    }
        //};
        //public IActionResult Index()
        //{
        //    return View(instituicoes);
        //}

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome", "Endereco")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("Erro de cadastro", "Não foi possível caastrar a instituição.");
            }
            return View(instituicao);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }
        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("InstituicaoID", "Nome", "Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long? id)
        {
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool InstituicaoExists(long? instituicaoID)
        {
            throw new NotImplementedException();
        }
    }
}





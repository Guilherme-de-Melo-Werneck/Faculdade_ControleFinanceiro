using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiroUGB232.Models;

namespace SistemaFinanceiroUGB232.Controllers
{
    public class DepartamentoController : Controller
    {
        private static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento()
            {
                DepartamentoID = 1,
                Nome = "Hogwarts",
            },
            new Departamento()
            {
                DepartamentoID = 2,
                Nome = "Mansão X",
            }
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)

        {
            departamento.DepartamentoID = departamentos.Select(i => i.DepartamentoID).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoID == departamento.DepartamentoID).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        public IActionResult Delete(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Departamento departamento)
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoID == departamento.DepartamentoID).First());
            return RedirectToAction("Index");
        }
    }
}
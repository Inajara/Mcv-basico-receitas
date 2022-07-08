using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioMVC.Controllers
{
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext database;

        public CategoriaController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO CategoriaTemporaria)
        {
            if(ModelState.IsValid){
                Categoria categoria = new Categoria();
                categoria.Nome = CategoriaTemporaria.Nome;
                categoria.Status = true;
                database.Categorias.Add(categoria);
                database.SaveChanges();
                return RedirectToAction("Categorias", "Admin");
            }else{
                return View("../Admin/NovaCategoria");
            }
        }

        [HttpPost("/Admin")]
        public IActionResult Atualizar(CategoriaDTO CategoriaTemporaria)
        {
            if(ModelState.IsValid){
                var categoria = database.Categorias.First(med => med.Id == CategoriaTemporaria.Id);
                categoria.Nome = CategoriaTemporaria.Nome;
                database.SaveChanges();
                return RedirectToAction("Categorias", "Admin");
            }else{
                return View("../Admin/EditarCategoria");
            }
        }

        [HttpPost("/Admin/Categorias")]
        public IActionResult Deletar(CategoriaDTO CategoriaTemporaria)
        {
            if(ModelState.IsValid){
                var categoria = database.Medidas.First(med => med.Id == CategoriaTemporaria.Id);
                categoria.Nome = CategoriaTemporaria.Nome;
                database.Medidas.Remove(categoria);
                database.SaveChanges();
                return RedirectToAction("Categorias", "Admin");
            }else{
                return View("../Admin/DeletarCategoria");
            }
        }
    }
}
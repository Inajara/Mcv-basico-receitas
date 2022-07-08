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
    public class IngredienteController : Controller
    {
        private readonly ApplicationDbContext database;

        public IngredienteController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(IngredienteDTO IngredienteTemporario)
        {
            if(ModelState.IsValid){
                Ingrediente ingrediente = new Ingrediente();
                ingrediente.Nome = IngredienteTemporario.Nome;
                ingrediente.Medida = database.Medidas.First(medida => medida.Id == IngredienteTemporario.MedidaID);
                ingrediente.Status = true;
                database.Ingredientes.Add(ingrediente);
                database.SaveChanges();
                return RedirectToAction("Ingredientes", "Admin");
            }else{
                ViewBag.Medidas = database.Medidas.ToList();
                return View("../Admin/NovoIngrediente");
            }
        }

        [HttpPost("/Admin")]
        public IActionResult Atualizar(IngredienteDTO IngredienteTemporario)
        {
            if(ModelState.IsValid){
                var ingrediente = database.Ingredientes.First(i => i.Id == IngredienteTemporario.Id);
                ingrediente.Nome = IngredienteTemporario.Nome;
                ingrediente.Medida = database.Medidas.First(medida => medida.Id == IngredienteTemporario.MedidaID);
                ViewBag.Medidas = database.Medidas.ToList();
                database.SaveChanges();
                return RedirectToAction("Ingredientes", "Admin");
            }else{
                return View("../Admin/EditarIngrediente");
            }
        }

        [HttpPost("/Admin/Ingredientes")]
        public IActionResult Deletar(IngredienteDTO IngredienteTemporario)
        {
            if(ModelState.IsValid){
                var ingrediente = database.Ingredientes.First(i => i.Id == IngredienteTemporario.Id);
                ingrediente.Nome = IngredienteTemporario.Nome;
                ingrediente.Medida = database.Medidas.First(medida => medida.Id == IngredienteTemporario.MedidaID);
                ViewBag.Medidas = database.Medidas.ToList();
                database.Ingredientes.Remove(ingrediente);
                database.SaveChanges();
                return RedirectToAction("Ingredientes", "Admin");
            }else{
                return View("../Admin/DeletarIngrediente");
            }
        }
    }
}
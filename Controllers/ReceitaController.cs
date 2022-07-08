using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioMVC.Controllers
{
    [Route("[controller]")]
    public class ReceitaController : Controller
    {
        private readonly ApplicationDbContext database;

        public ReceitaController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(ReceitaDTO ReceitaTemporaria)
        {
            if(ModelState.IsValid){
                Receita receita = new Receita();
                receita.Nome = ReceitaTemporaria.Nome;
                receita.Medida = database.Medidas.First(medida => medida.Id == ReceitaTemporaria.MedidaID);
                receita.Ingrediente = database.Ingredientes.First(ingrediente => ingrediente.Id == ReceitaTemporaria.IngredienteID);
                receita.Categoria = database.Categorias.First(categoria => categoria.Id == ReceitaTemporaria.MedidaID);
                receita.Status = true;
                receita.Instrucao = ReceitaTemporaria.Instrucao;
                database.Receitas.Add(receita);
                database.SaveChanges();
                return RedirectToAction("Receitas", "Admin");
            }else{
                ViewBag.Medidas = database.Medidas.ToList();
                ViewBag.Ingredientes = database.Ingredientes.ToList();
                ViewBag.Categorias = database.Categorias.ToList();
                return View("../Admin/NovoReceita");
            }
        }

        [HttpPost("/Admin")]
        public IActionResult Atualizar(ReceitaDTO ReceitaTemporaria)
        {
            if(ModelState.IsValid){
                var receita = database.Receitas.First(r => r.Id == ReceitaTemporaria.Id);
                receita.Nome = ReceitaTemporaria.Nome;
                receita.Medida = database.Medidas.First(medida => medida.Id == ReceitaTemporaria.MedidaID);
                receita.Ingrediente = database.Ingredientes.First(ingrediente => ingrediente.Id == ReceitaTemporaria.IngredienteID);
                receita.Categoria = database.Categorias.First(categoria => categoria.Id == ReceitaTemporaria.MedidaID);
                receita.Instrucao = ReceitaTemporaria.Instrucao;
                ViewBag.Medidas = database.Medidas.ToList();
                ViewBag.Ingredientes = database.Ingredientes.ToList();
                ViewBag.Categorias = database.Categorias.ToList();
                database.SaveChanges();
                return RedirectToAction("Receitas", "Admin");
            }else{
                return View("../Admin/EditarReceita");
            }
        }

        [HttpPost("/Admin/Receitas")]
        public IActionResult Deletar(ReceitaDTO ReceitaTemporaria)
        {
            if(ModelState.IsValid){
                var receita = database.Receitas.First(r => r.Id == ReceitaTemporaria.Id);
                receita.Nome = ReceitaTemporaria.Nome;
                receita.Medida = database.Medidas.First(medida => medida.Id == ReceitaTemporaria.MedidaID);
                receita.Ingrediente = database.Ingredientes.First(ingrediente => ingrediente.Id == ReceitaTemporaria.IngredienteID);
                ViewBag.Medidas = database.Medidas.ToList();
                ViewBag.Ingredientes = database.Ingredientes.ToList();
                ViewBag.Categorias = database.Categorias.ToList();
                receita.Instrucao = ReceitaTemporaria.Instrucao;
                database.Receitas.Remove(receita);
                database.SaveChanges();
                return RedirectToAction("Receitas", "Admin");
            }else{
                return View("../Admin/DeletarReceita");
            }
        }
    }
}
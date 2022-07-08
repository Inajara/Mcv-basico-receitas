using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DesafioMVC.Data;
using DesafioMVC.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioMVC.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext database;

        public AdminController(ApplicationDbContext database){
            this.database = database;
        }

        public IActionResult Index()
        {
            var receitas = database.Receitas.Include(r => r.Ingrediente).Include(r => r.Medida).Include(r => r.Categoria).ToList();
            return View(receitas);
        }

        [HttpGet("/Admin/Categorias")]
        public IActionResult Categorias()
        {
            var categorias = database.Categorias.ToList();
            return View(categorias);
        }

        [HttpGet("/Admin/Medidas/NovaCategoria")]
        public IActionResult NovaCategoria()
        {
            return View();
        }

        [HttpGet("/Admin/Medidas/EditarCategoria")]
        public IActionResult EditarCategoria(int id)
        {
            var categoria = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View(categoriaView);
        }

        [HttpGet("/Admin/Medidas/DeletarCategoria")]
        public IActionResult DeletarCategoria(int id)
        {
            var categoria = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View(categoriaView);
        }

        [HttpGet("/Admin/Medidas")]
        public IActionResult Medidas()
        {
            var medidas = database.Medidas.ToList();
            return View(medidas);
        }

        [HttpGet("/Admin/Medidas/NovaMedida")]
        public IActionResult NovaMedida()
        {
            return View();
        }

        [HttpGet("/Admin/Medidas/EditarMedida")]
        public IActionResult EditarMedida(int id)
        {
            var medida = database.Medidas.First(med => med.Id == id);
            MedidaDTO medidaView = new MedidaDTO();
            medidaView.Id = medida.Id;
            medidaView.Nome = medida.Nome;
            return View(medidaView);
        }

        [HttpGet("/Admin/Medidas/DeletarMedida")]
        public IActionResult DeletarMedida(int id)
        {
            var medida = database.Medidas.First(med => med.Id == id);
            MedidaDTO medidaView = new MedidaDTO();
            medidaView.Id = medida.Id;
            medidaView.Nome = medida.Nome;
            return View(medidaView);
        }

        [HttpGet("/Admin/Ingredientes")]
        public IActionResult Ingredientes()
        {
            var ingrediente = database.Ingredientes.Include(i => i.Medida).ToList();
            return View(ingrediente);
        }

        [HttpGet("/Admin/Ingredientes/NovoIngrediente")]
        public IActionResult NovoIngrediente()
        {
            ViewBag.Medidas = database.Medidas.ToList();
            return View();
        }

        [HttpGet("/Admin/Ingredientes/EditarIngrediente")]
        public IActionResult EditarIngrediente(int id)
        {
            var ingrediente = database.Ingredientes.Include(i => i.Medida).First(i => i.Id == id);
            IngredienteDTO ingredienteView = new IngredienteDTO();
            ingredienteView.Id = ingrediente.Id;
            ingredienteView.Nome = ingrediente.Nome;
            ingredienteView.MedidaID = ingrediente.Medida.Id;
            ViewBag.Medidas = database.Medidas.ToList();
            return View(ingredienteView);
        }

        [HttpGet("/Admin/Ingredientes/DeletarIngrediente")]
        public IActionResult DeletarIngrediente(int id)
        {
            var ingrediente = database.Ingredientes.Include(i => i.Medida).First(i => i.Id == id);
            IngredienteDTO ingredienteView = new IngredienteDTO();
            ingredienteView.Id = ingrediente.Id;
            ingredienteView.Nome = ingrediente.Nome;
            ingredienteView.MedidaID = ingrediente.Medida.Id;
            ViewBag.Medidas = database.Medidas.ToList();
            return View(ingredienteView);
        }

        [HttpGet("/Admin/Receitas")]
        public IActionResult Receitas()
        {
            var receitas = database.Receitas.Include(r => r.Ingrediente).Include(r => r.Medida).Include(r => r.Categoria).ToList();
            return View(receitas);
        }

        [HttpGet("/Admin/Receitas/NovaReceita")]
        public IActionResult NovaReceita()
        {
            ViewBag.Medidas = database.Medidas.ToList();
            ViewBag.Ingredientes = database.Ingredientes.ToList();
            ViewBag.Categorias = database.Categorias.ToList();
            return View();
        }

        [HttpGet("/Admin/Receitas/EditarReceita")]
        public IActionResult EditarReceita(int id)
        {
            var receita = database.Receitas.Include(r => r.Ingrediente).Include(r => r.Medida).Include(r => r.Categoria).First(r => r.Id == id);
            ReceitaDTO receitaView = new ReceitaDTO();
            receitaView.Id = receita.Id;
            receitaView.Nome = receita.Nome;
            receitaView.MedidaID = receita.Medida.Id;
            receitaView.IngredienteID = receita.Ingrediente.Id;
            receitaView.CategoriaID = receita.Categoria.Id;
            ViewBag.Medidas = database.Medidas.ToList();
            ViewBag.Ingredientes = database.Ingredientes.ToList();
            ViewBag.Categorias = database.Categorias.ToList();
            return View(receitaView);
        }

        [HttpGet("/Admin/Receitas/DeletarReceita")]
        public IActionResult DeletarReceita(int id)
        {
            var receita = database.Receitas.Include(r => r.Ingrediente).Include(r => r.Medida).Include(r => r.Categoria).First(r => r.Id == id);
            ReceitaDTO receitaView = new ReceitaDTO();
            receitaView.Id = receita.Id;
            receitaView.Nome = receita.Nome;
            receitaView.MedidaID = receita.Medida.Id;
            receitaView.IngredienteID = receita.Ingrediente.Id;
            receitaView.CategoriaID = receita.Categoria.Id;
            ViewBag.Medidas = database.Medidas.ToList();
            ViewBag.Ingredientes = database.Ingredientes.ToList();
            ViewBag.Categorias = database.Categorias.ToList();
            return View(receitaView);
        }
    }
}
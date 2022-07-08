using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DesafioMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using DesafioMVC.Data;

namespace DesafioMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        /* private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        } */

        private readonly ApplicationDbContext database;

        public HomeController(ApplicationDbContext database){
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Pagina")]
        public IActionResult Pagina()
        {
            var receitas = database.Receitas.Include(r => r.Ingrediente).Include(r => r.Medida).Include(r => r.Categoria).ToList();
            return View(receitas);
        }

        public IActionResult Policy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

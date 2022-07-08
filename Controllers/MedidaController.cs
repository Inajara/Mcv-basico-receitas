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
    public class MedidaController : Controller
    {
        private readonly ApplicationDbContext database;

        public MedidaController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(MedidaDTO MedidaTemporaria)
        {
            if(ModelState.IsValid){
                Medida medida = new Medida();
                medida.Nome = MedidaTemporaria.Nome;
                medida.Status = true;
                database.Medidas.Add(medida);
                database.SaveChanges();
                return RedirectToAction("Medidas", "Admin");
            }else{
                return View("../Admin/NovaMedida");
            }
        }

        [HttpPost("/Admin")]
        public IActionResult Atualizar(MedidaDTO MedidaTemporaria)
        {
            if(ModelState.IsValid){
                var medida = database.Medidas.First(med => med.Id == MedidaTemporaria.Id);
                medida.Nome = MedidaTemporaria.Nome;
                database.SaveChanges();
                return RedirectToAction("Medidas", "Admin");
            }else{
                return View("../Admin/EditarMedida");
            }
        }

        [HttpPost("/Admin/Medidas")]
        public IActionResult Deletar(MedidaDTO MedidaTemporaria)
        {
            if(ModelState.IsValid){
                var medida = database.Medidas.First(med => med.Id == MedidaTemporaria.Id);
                medida.Nome = MedidaTemporaria.Nome;
                database.Medidas.Remove(medida);
                database.SaveChanges();
                return RedirectToAction("Medidas", "Admin");
            }else{
                return View("../Admin/DeletarMedida");
            }
        }
    }
}
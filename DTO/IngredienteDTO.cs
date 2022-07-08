using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMVC.DTO
{
    public class IngredienteDTO
    {
        [Required]
        public int Id{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public int MedidaID{get; set;}
    }
}
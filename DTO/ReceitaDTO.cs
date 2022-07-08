using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMVC.DTO
{
    public class ReceitaDTO
    {
        [Required]
        public int Id{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public int IngredienteID{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public int MedidaID{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public int CategoriaID{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Instrucao{get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMVC.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id{get; set;}
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome{get; set;}
    }
}
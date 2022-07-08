using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMVC.Models
{
    public class Receita
    {
        public int Id{get; set;}
        public string Nome{get; set;}
        public Ingrediente Ingrediente{get; set;}
        public Medida Medida{get; set;}
        public Categoria Categoria{get; set;}
        public string Instrucao{get; set;}
        public bool Status{get; set;}
    }
}
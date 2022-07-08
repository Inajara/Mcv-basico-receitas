using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMVC.Models
{
    public class Ingrediente
    {
        public int Id{get; set;}
        public string Nome{get; set;}
        public Medida Medida{get; set;}
        public bool Status{get; set;}
    }
}
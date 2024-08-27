using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoClases
{
    public class Pasante : Persona
    {
        public Pasante(string nombre, int edad, string genero, int dni, string numeroLegajo)
         : base(nombre, edad, genero, dni) // Llama al constructor de la clase base (Persona)
        {
            NumeroLegajo = numeroLegajo; // Inicializa el atributo específico de Pasante
        }

        public string NumeroLegajo { get; set; }

    }

}

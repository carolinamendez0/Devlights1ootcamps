using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoClases
{
    public class Profesional : Persona
    {

        #region Constructores
        //Constructor de la clase Profesional.

        public Profesional(string nombre, int edad, string genero, int dni, string numeroMatricula)
        : base(nombre, edad, genero, dni) // Llama al constructor de la clase base (Persona)
        {
            NumeroMatricula = numeroMatricula; // Inicializa el atributo específico de Pasante
        }
        #endregion

        #region Métodos
        public string NumeroMatricula { get; set; }
        //Métodos de la clase Profesional
        public void verLegajo()
        {
        }
        #endregion

    }
}

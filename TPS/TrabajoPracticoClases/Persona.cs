using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoClases
{
    public class Persona
    {
        public string Nombre { get => nombre; set => nombre = value; }
        private int _edad;
        public int Edad
        {
            get => _edad;
            //Agregar validación en edad para que value sea siempre mayor a cero
            set
            {
                if (value <= 0)
                {
                    throw new Exception("La edad debe ser mayor a cero");
                }
                _edad = value;
            }
        }

        public string Genero { get; set; }
        public int DNI { get; set; }


        //Añadir campo publico
        public string direccion;
        private string nombre;

        public Persona(string nombre, int edad, string genero,int dni)
        {
            //Inicialización de los atributos de la clase Persona
            Nombre = nombre;
            Edad = edad;
            Genero = genero;
            DNI = dni;
        }

        //Método que imprime los datos de la persona
        //public como modificador de acceso
        //public permite el acceso al método ImprimirDatos desde cualquier parte del programa
        public void ImprimirDatos()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Género: " + Genero);
        }

        //Método que imprime el mensaje de saludo
        //public como modificador de acceso
        //public permite el acceso al método Saludar desde cualquier parte del programa
        public void Saludar()
        {
            Console.WriteLine("Hola, soy " + Nombre);
        }

    }
}

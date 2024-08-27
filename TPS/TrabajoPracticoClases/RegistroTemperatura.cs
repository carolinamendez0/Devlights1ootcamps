using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoClases
{
    internal class RegistroTemperatura
    {
        public double TemperaturaRegistrada { get; set; }
        public float Temperatura { get; set; }
        public Persona PersonaDeTurno { get; set; }
        public DateTime FechaRegistro { get; set; }
        public TimeSpan HoraRegistro { get; set; }


    public RegistroTemperatura(float temperatura, Persona personaDeTurno, DateTime fechaRegistro, TimeSpan horaRegistro)
    {
        Temperatura = temperatura;
        PersonaDeTurno = personaDeTurno;
        FechaRegistro = fechaRegistro;
        HoraRegistro = (horaRegistro);
        }
    }
}

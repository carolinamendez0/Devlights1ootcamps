using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrabajoPracticoClases;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TrabajoPracticoClases
{
    internal class EstacionMeteorologica
    {

        private List<double> temperaturasPromedioSemanal;
        private List<double> temperaturasSobreUmbral;
        private RegistroTemperatura[,] temperaturasMensuales;
        
        public EstacionMeteorologica()
        {
            // Inicialización de la matriz de 5 filas por 7 columnas
            temperaturasMensuales = new RegistroTemperatura[5, 7];
            temperaturasPromedioSemanal = new List<double>();
            temperaturasSobreUmbral = new List<double>();
            //// Crear un nuevo registro de temperatura
            //var registro = new RegistroTemperatura(temperatura: 25,
            //                                       personaDeTurno: new Profesional { Nombre = "Profesional 1", NumeroMatricula = "12345" },
            //                                       fechaRegistro: DateTime.Now, 
            //                                        horaRegistro: 19:00);

        }


        //Un método llamado RegistrarTemperatura, que recibirá un objeto de tipo RegistroTemperatura, para ser almacenado en la matriz.
        //-Un método VerTemperaturas, con parámetro para elegir qué colección ver.Este método puede devolver sólo las temperaturas.
        //-Utiliza el constructor para la carga inicial de la matriz, si usaste carga automática.
        //-Utiliza un método de carga para la matriz, si le pediste al usuario que cargue manualmente.
        //-Puedes agregar algunas funciones anteriores como métodos de esta clase, como por ejemplo "Ver temperatura de un día específico". Tu eliges las que creas conveniente que pueden ir en esta clase.
        //-Recuerda que ahora la matriz ya no es de tipo int, sino que almacena objetos de la clase nueva Registro! Modificalo!
        //public void RegistrarTemperatura(RegistroTemperatura registro, int semana, int dia)
        //{
        //    matrizTemperaturas[semana, dia] = registro;
        //}
        public void RegistrarTemperatura(RegistroTemperatura registro, int semana, int dia)
        {
            if (semana >= 0 && semana < 5 && dia >= 0 && dia < 7)
            {
                temperaturasMensuales[semana, dia] = registro;
            }
        }
        public void CargarTemperaturas()
        {
            // Ejemplo de personas
            var personas = new List<Persona>
            {
                //new Profesional { Nombre = "Profesional 1", Edad = 25, Genero = "Femenino" , DNI= 111111, NumeroMatricula = "12345" },
                new Profesional("Profesional 1", 25, "Femenino", 12345678, "111111"),
                new Pasante("Carolina Mendez", 25, "Femenino", 12345678, "P001"),
                new Profesional("Profesional2", 33, "Masculino", 232323, "E66T5"),
                new Pasante("Pasante2", 26, "Femenino", 1242222, "P003"),
                new Profesional("Profesional3", 23, "Masculino", 3232323, "E9K88"),
                new Pasante("Pasante3", 22, "Masculino", 4532323, "P004"),



                //new Profesional { Nombre = "Profesional 2", NumeroMatricula = "67890" },
                //new Pasante { Nombre = "Pasante 2", NumeroLegajo = "P002" },
            };

            int personaIndex = 0;
            DateTime primerDiaDelMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month -1 , 1);

            for (int semana = 0; semana < 5; semana++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                    int diaDelMes = semana * 7 + dia;

                    if ((semana * 7 + dia) < 31)
                    {
                        float temperatura = new Random().Next(-10, 35);
                        Persona personaDeTurno = personas[personaIndex];

                        personaIndex = (personaIndex + 1) % personas.Count;

                        DateTime fechaRegistro = primerDiaDelMes.AddDays(diaDelMes);
                        //  hora y minutos aleatorios
                        Random random = new Random();
                        int horaAleatoria = random.Next(0, 24);
                        int minutosAleatorios = random.Next(0, 60);


                        // Crear un TimeSpan con la hora y minutos aleatorios
                        TimeSpan horaRegistro = new TimeSpan(horaAleatoria, minutosAleatorios, 0);

                        var registro = new RegistroTemperatura(temperatura, personaDeTurno, fechaRegistro, horaRegistro);

                        RegistrarTemperatura(registro, semana, dia);
                    }
                }
            }
        }

        public void VerTemperaturas(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Ingrese el día a ver la temperatura:");
                    daySpecific(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 2:
                    averageTemperatures();
                    break;
                case 3:
                    temperaturesSup(20);
                    break;

            }
        }

        #region Metodos Propios
        private void daySpecific(int dia)
        {
            int semana = (dia - 1) / 7;
            int diaSemana = (dia - 1) % 7;

            var registro = temperaturasMensuales[semana, diaSemana];
            if (registro != null)
            {
                Console.WriteLine($"Día: {registro.FechaRegistro.ToShortDateString()}, Hora: {registro.HoraRegistro}");
                Console.WriteLine($"Temperatura: {registro.Temperatura}°C, Registrado por: {registro.PersonaDeTurno.Nombre}");
                if (registro.Temperatura < 0)
                {
                    Console.WriteLine("Hizo mucho frío.");
                }
                else if (registro.Temperatura < 20)
                {
                    Console.WriteLine("El clima estaba fresco.");
                }
                else
                {
                    Console.WriteLine("Hizo calor afuera.");
                }
            }
        }

        //private void daySpecific(int dia)
        //{
        //    int convertDia = dia;
        //    int diasPorSemana = 7;
        //    int totalSemanas = 5;
        //    // Calcular los índices i y j
        //    int i = (dia - 1) / diasPorSemana; // Índice de la semana (fila)
        //    int j = (dia - 1) % diasPorSemana; // Índice del día de la semana (columna)
        //    if (matrizTemperaturas[i, j] < 0)
        //    {
        //        Console.WriteLine($"El día {dia}, Hizo mucho frío.");
        //    }
        //    else if (matrizTemperaturas[i, j] >= 0 && temperaturasDiarias[i, j] < 20)
        //    {
        //        Console.WriteLine($"El día {dia}, El clima estaba fresco.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"El día {dia}, Hizo calor afuera.");
        //    }
        //}

        private void averageTemperatures()
        {
            for (int semana = 0; semana < 5; semana++)
            {
                double suma = 0;
                int contador = 0;
                for (int dia = 0; dia < 7; dia++)
                {
                    if (temperaturasMensuales[semana, dia] != null)
                    {
                        suma += temperaturasMensuales[semana, dia].Temperatura;
                        contador++;
                    }
                }
                if (contador > 0)
                {
                    double promedio = suma / contador;
                    temperaturasPromedioSemanal.Add(promedio);
                    Console.WriteLine($"Semana {semana + 1}: Promedio de temperatura = {promedio}°C");
                }
            }
        }

        //Encontrar y ver temperaturas por encima de 20°
        private void temperaturesSup(int tempEnc)
        {
            temperaturasSobreUmbral.Clear();
            for (int semana = 0; semana < 5; semana++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                    if (temperaturasMensuales[semana, dia] != null && temperaturasMensuales[semana, dia].Temperatura > tempEnc)
                    {
                        temperaturasSobreUmbral.Add(temperaturasMensuales[semana, dia].Temperatura);
                        Console.WriteLine($"Semana {semana + 1}, Día {dia + 1}: Temperatura = {temperaturasMensuales[semana, dia].Temperatura}°C");
                    }
                }
            }

            if (temperaturasSobreUmbral.Count == 0)
            {
                Console.WriteLine("No hay temperaturas por encima del umbral.");
            }
        }
        #endregion
    }
}

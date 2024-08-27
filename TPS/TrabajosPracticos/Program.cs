using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

//Dejo inicializada, por si no se quiere cargar todas cada vez que se ejecute el código 
//double[,] temperaturasDiarias = new double[,]
//{
//    { 0, 15.3, -16.7, 34.4, 18.1, 20.2, 22.0 },
//    { 21.5, 19.0, 17.3, 16.4, 15.7, 14.1, 13.2 },
//    { 10.5, 9.8, 12.1, 11.3, 13.4, 14.0, 15.6 },
//    { 8.7, 7.2, 9.5, 10.0, 11.2, 12.8, 14.1 },
//    { 16.5, 17.2, -18.3, 0 , 0 , 0 ,0 }
//};
double[,] temperaturasDiarias = new double[5,7];

void LoadTemperatureMonth()
{
    bool salirDeBucle = false;
    int diaActual = 0;

    for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
    {
        for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
        {
            int Semana = i + 1;
            int Dia = j + 1;
            diaActual++;

            Console.WriteLine($"Ingrese la temperatura de la semana: {Semana} , dia : {Dia}");
            temperaturasDiarias[i, j] = Convert.ToDouble(Console.ReadLine());

            if (diaActual == 31)
            {
                salirDeBucle = true;
                break; // Sale del bucle cuando llega al día 31
            }
        }

        if (salirDeBucle)
        {
            break; 
        }
    }
}

LoadTemperatureMonth();




void daySpecific(int dia)
{
    int convertDia = dia;
    int diasPorSemana = 7;
    int totalSemanas = 5;
    // Calcular los índices i y j
    int i = (dia - 1) / diasPorSemana; // Índice de la semana (fila)
    int j = (dia - 1) % diasPorSemana; // Índice del día de la semana (columna)
    if (temperaturasDiarias[i,j] < 0 )
    {
    Console.WriteLine($"El día {dia}, Hizo mucho frío.");
    }
    else if ( temperaturasDiarias[i,j] >= 0 && temperaturasDiarias[i, j] < 20)
    {
        Console.WriteLine($"El día {dia}, El clima estaba fresco.");
    }
    else {
        Console.WriteLine($"El día {dia}, Hizo calor afuera.");
    }
}


void averageTemperatures ()
{
    //Una  para almacenar las temperaturas promedio de cada semana.
    double[] promedioSemanal = new double[5];
    for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
    {
        double sumaTemperaturas = 0;
        for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
        {
            sumaTemperaturas += temperaturasDiarias[i, j];
           
            if (j == 6)
            {
                promedioSemanal[i] = sumaTemperaturas / 7;
                Console.WriteLine($"Promedio de temperatura de la semana {i+1} = {promedioSemanal[i]}");
            }
        }
    }
}

//Una  para almacenar las temperaturas por encima de un cierto umbral.
//Encontrar y ver temperaturas por encima de 20°
void temperaturesSup(int tempEnc)
{
    List<string> temperaturasAltas = new List<string>();
    for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
    {
        for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
        {
            if (temperaturasDiarias[i, j] > tempEnc)
            {
                string descripcion = $"El día {i + 1} de la semana {j + 1} tuvo una temperatura de {temperaturasDiarias[i, j]}°C.";
                temperaturasAltas.Add(descripcion);
            }
        }
    }
    foreach (var item in temperaturasAltas)
    {
        Console.WriteLine(item);
    }
    if (temperaturasAltas.Count == 0)
    {
        Console.WriteLine("No existen días con la temperatura superior a 20°");
    }

}

//"4 - Ver la temperatura promedio del mes\n" +
void averageTemperaturesMonths()
{
    //Una  para almacenar las temperaturas promedio de cada semana.
    double sumaTemperaturas = 0;
    for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
    {
        for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
        {
            sumaTemperaturas += temperaturasDiarias[i, j];
            if (i == 4 && j == 0)
            {
                break;
            }
        }
        if (i == 4) break;
    }
    double promedioMensual = sumaTemperaturas / 31;
    Console.WriteLine($"Promedio de temperatura del mes = {promedioMensual}");
}
//5 
void seeHighestTemperature()
{
    double temperaturaMaxima = double.MinValue;
    int semanaMaxima = 0;
    int diaMaximo = 0;

    // Recorrer la matriz para encontrar la temperatura más alta
    for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
    {
        for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
        {
            if (temperaturasDiarias[i, j] > temperaturaMaxima)
            {
                temperaturaMaxima = temperaturasDiarias[i, j];
                semanaMaxima = i + 1;
                diaMaximo = j + 1;
            }
        }
    }
    // Mostrar la temperatura más alta encontrada y su ubicación en la matriz
    Console.WriteLine($"La temperatura más alta es {temperaturaMaxima}°C, registrada el día {diaMaximo} de la semana {semanaMaxima}.");
}
void seeLowerTemperature()
{
    double temperaturaMinima = double.MaxValue;
    int semanaMin = 0;
    int diaMin = 0;
    bool salirDeBucle = false;
    int diaActual = 0;

    // Recorrer la matriz para encontrar la temperatura más alta
    for (int i = 0; i < temperaturasDiarias.GetLength(0); i++)
    {
        for (int j = 0; j < temperaturasDiarias.GetLength(1); j++)
        {
            diaActual++;
            if (temperaturasDiarias[i, j] < temperaturaMinima)
            {
                if ( i == 5 && j == 4) {

                }
                temperaturaMinima = temperaturasDiarias[i, j];
                semanaMin = i + 1;
                diaMin = j + 1;
            }
            if (diaActual == 31)
            {
                salirDeBucle = true;
                break; // Sale del bucle cuando llega al día 31
            }
        }
        if (salirDeBucle)
        {
            break;
        }
    }
    // Mostrar la temperatura más alta encontrada y su ubicación en la matriz
    Console.WriteLine($"La temperatura más baja es {temperaturaMinima}°C, registrada el día {diaMin} de la semana {semanaMin}.");
}
void TempPost()
{
    var rand = new Random();
    for (int i = 0; i < 5; i++)
    {
        string dia = DateTime.Now.AddDays(+i).ToString("dd-MMM-yyyy");
        byte[] bytes = new byte[1];
        rand.NextBytes(bytes);
        foreach (byte byteValue in bytes)
            Console.WriteLine(dia + " Temp." + byteValue + "°");
    }
}


void MenuOptions()
{
    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("\nMENU (ingrese el numero de la acción deseada)");
        Console.WriteLine("-----------------------------------------------\n");
        Console.WriteLine("1 - Ver temperatura de un día específico\n" +
                      "2 - Calcular y ver temperaturas promedio de cada semana\n" +
                      "3 - Encontrar y ver temperaturas por encima de 20°\n" +
                      "4 - Ver la temperatura promedio del mes\n" +
                      "5 - Ver la temperatura más alta\n" +
                      "6 - Ver la temperatura más baja\n" +
                      "7 - Ver el pronóstico de 5 días posteriores al mes\n" +
                      "8 - Salir\n" +
                      "\n-----------------------------------------------\n");
        int OptionMenu = Convert.ToInt32(Console.ReadLine());
        switch (OptionMenu)
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
            case 4:
                averageTemperaturesMonths();
                break;
            case 5:
                seeHighestTemperature();
                break;
            case 6:
                seeLowerTemperature();
                break;
            case 7:
                TempPost();
                break;
            case 8:
                Console.WriteLine("Hasta Luego :)");
                exit = true; // Cambiar a true para salir del bucle
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, seleccione una opción entre 1 y 8.");
                break;
        }
    }
}

MenuOptions();
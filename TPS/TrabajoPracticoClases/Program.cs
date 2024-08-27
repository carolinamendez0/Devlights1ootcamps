namespace TrabajoPracticoClases
{
    // Program.cs
class Program
{
    static void Main(string[] args)
    {
        EstacionMeteorologica estacion = new EstacionMeteorologica();
        estacion.CargarTemperaturas();

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Ver temperatura de un día específico");
            Console.WriteLine("2. Ver promedio de temperaturas por semana");
            Console.WriteLine("3. Ver temperaturas por encima de 20°C");
            Console.WriteLine("4. Salir");

            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 4)
            {
                continuar = false;
            }
            else
            {
                estacion.VerTemperaturas(opcion);
            }

            if (continuar)
            {
                Console.WriteLine("¿Desea realizar otra operación? (s/n)");
                continuar = Console.ReadLine().ToLower() == "s";
            }
        }
    }
}

}

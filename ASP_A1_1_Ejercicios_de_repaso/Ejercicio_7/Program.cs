//Ejercicio_7
    //Pide al usuario el nombre de un corredor.
    //Pide al usuario los tiempos de tres carreras en segundos.
    //Crea un método llamado CalcularPromedio que reciba esos tres tiempos y devuelva el tiempo medio.
    //Muestra un mensaje en pantalla con el siguiente formato: Hola, [nombre], tu tiempo medio es: [promedio] segundos

class Ejercicio_7
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Dime un nombre");
        string nombre = Console.ReadLine();
        double tiempo1 = filtro();
        double tiempo2 = filtro();
        double tiempo3 = filtro();
        double promedio = CalcularPromedio(tiempo1,tiempo2, tiempo3);
        Console.WriteLine("Hola, " + nombre + ", tu tiempo medio es: " + promedio.ToString("F2") + " segundos");

    }


    public static double filtro()
    {
        while (true)
        {
            Console.WriteLine("Dame un tiempo de carrera");
            string tiempo = Console.ReadLine();
            if (double.TryParse(tiempo, out var val) && val > 0)
            {
                return val;
            }
            else
            {
                Console.WriteLine("Numero no valido");
            }
        }
    }

    public static double CalcularPromedio(double tiempo1, double tiempo2, double tiempo3)
    {
        double tiempototal = tiempo1 + tiempo2 + tiempo3;
        return tiempototal/3;
    } 
}
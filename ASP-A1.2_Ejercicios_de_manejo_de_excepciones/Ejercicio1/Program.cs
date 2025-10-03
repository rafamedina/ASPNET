

class Ejercicio1
{
    public static void Main(string[] args)
    {
        convertirNumero();

    }

    public static int convertirNumero()
    {
        while (true)
        {
            Console.WriteLine("Dame un numero");
            string PreNumero = Console.ReadLine();

            if (int.TryParse(PreNumero, out int resultado) && resultado > 0)
            {
                Console.WriteLine("Numero aceptado: " + resultado);
                return resultado;
            }
            else
            {
                Console.WriteLine("Numero no válido");
            }
        }

    }

}

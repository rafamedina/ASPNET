// Número par o impar
//Pide un número y muestra si es par o impar usando el operador módulo %.


class Ejercicio_6
{
    public static void Main(string[] args)
    {
        int numero = Filtro();
        if(numero % 2 == 0)
        {
            Console.WriteLine("es par");
        }
        else
        {
            Console.WriteLine("Es impar");
        }
    }

    public static int Filtro()
    {
        while (true)
        {
            Console.WriteLine("dame un numero");
            string numero = Console.ReadLine();
            if(int.TryParse(numero,out int salida)){
                return salida;
            }
            else
            {
                Console.WriteLine("Numero no valido");
            }
        }
    }
}
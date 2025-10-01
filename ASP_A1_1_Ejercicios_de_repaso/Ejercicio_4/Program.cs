// Mayor de dos números
// Pide dos números y muestra cuál es mayor.
// Si son iguales, muestra un mensaje “Los números son iguales”.

using System.Reflection.PortableExecutable;

class Ejercicio_4
{
    public static void Main(String[] args)
    {
        int num1 = Pedir();
        int num2 = Pedir();
        if (num1 < num2)
        {
            Console.WriteLine($"El numero {num2} es mayor");


        }
        else if (num2 < num1) { Console.WriteLine($"El numero {num1} es mayor"); }
        else
        {
            Console.WriteLine("Son iguales");

        }
    }
    public static int Pedir()
    {
        while (true)
        {
            Console.WriteLine("dame un numero");
            string num = Console.ReadLine();
            if (int.TryParse(num, out int salida))
            {
                return salida;
            }
            else
            {
                Console.WriteLine("Numero no válido");
            }
        }
    }
}

// See https://aka.ms/new-console-template for more informationç
//Suma de dos números
//Crea un programa que pida dos números por consola y muestre su suma.
//Bonus: muestra también la resta, multiplicación y división

class Ejercicio_1
{
    static void Main(string[] args)
    {
        double x = filtro();
        double y = filtro();
        double suma = Sumar(x, y);
        double resta = Restar(x, y);
        double multi = Multiplicar(x, y);
        double div = Dividir(x, y);

        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Resta: {resta}");
        Console.WriteLine($"Multiplicación: {multi}");
        Console.WriteLine($"División: {div}");

    }


    public static double Sumar(double x, double y)
    {
        return x + y;
    }
    public static double Restar(double x, double y)
    {
        return x - y;
    }
    public static double Multiplicar(double x, double y)
    {
        return x * y;
    }
    public static double Dividir(double x, double y)
    {
        return x / y;
    }


    public static double filtro()
    {
        while (true)
        {
            Console.WriteLine("Dame un número:");
            string input = Console.ReadLine();
            double num;
            if (double.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Error: Debes escribir un número (puede tener decimales con punto). Intenta de nuevo.");
            }
        }

    }
}
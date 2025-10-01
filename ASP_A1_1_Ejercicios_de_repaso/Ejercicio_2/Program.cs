// See https://aka.ms/new-console-template for more information
//Saludo personalizado
//Pide al usuario su nombre y muestra un mensaje: “Hola, [nombre], bienvenido al programa”.


class Ejercicio_2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Dime tu nombre");

        string nombre = Console.ReadLine();

        Console.WriteLine($"Hola, {nombre}, bienvenido al programa");
    }
}


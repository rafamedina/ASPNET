// See https://aka.ms/new-console-template for more information
//Edad en meses
//Pide la edad del usuario y calcula cuántos meses ha vivido.
//Muestra el resultado en consola.

class Ejercicio_3
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Dime tu edad: ");
            string numero = Console.ReadLine();
            if (int.TryParse(numero, out int val))
            {
                Console.WriteLine(val * 12 + " meses de vida");
                break;
            }
            else
            {
                Console.WriteLine("Tiene que ser un numero valido");
            }

        }
    }
}



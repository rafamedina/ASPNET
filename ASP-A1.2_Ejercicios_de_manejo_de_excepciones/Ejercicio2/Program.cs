using System;
using System.Collections.Generic;

class Ejercicio2
{
    public static void Main(string[] args)
    {
        Dictionary<string, int> diccionario = new Dictionary<string, int>();
        diccionario.Add("Iker", 15);
        diccionario.Add("Rafa", 25);

        if (diccionario.TryGetValue("Rafa", out int edad))
        {
            Console.WriteLine("Rafa");
            Console.WriteLine(edad); 
        }
        else
        {
            Console.WriteLine("Persona no encontrada.");
        }
    }
}
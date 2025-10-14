// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        var cola = new Queue<string>();
        cola.Enqueue("Rafa");
        cola.Enqueue("Iker");
        cola.Enqueue("tovi");

        Console.WriteLine("Elementos en la cola:");
        foreach (var item in cola)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Ahora a borrar");
        try
        {
            for (int i = 0; i < 10; i++)
            {
                string removed = cola.Dequeue();
                Console.WriteLine($"Eliminado: {removed}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Excepción: {e.Message}");
        }
    }
}
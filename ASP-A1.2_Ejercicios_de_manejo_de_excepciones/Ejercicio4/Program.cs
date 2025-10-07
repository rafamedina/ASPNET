using System;
using System.Collections.Generic;

public class Ejercicio_4
{
    public static void Main()
    {
        var productos = new Dictionary<string, double>
        {
            { "Laptop", 1500 },
            { "Mouse", 25 },
            { "Teclado", 45 }
        };

        ProcesarEntrada(productos, "Laptop", "2");
        ProcesarEntrada(productos, "Tablet", null);
        ProcesarEntrada(productos, "Mouse", "abc");
    }

    static void ProcesarEntrada(Dictionary<string, double> productos, string producto, string cantidadInput)
    {
        if (!productos.TryGetValue(producto, out double precio))
        {
            Console.WriteLine("Producto no encontrado");
            return;
        }

        int cantidad = 1; 

        if (cantidadInput != null)
        {
            if (!int.TryParse(cantidadInput, out cantidad))
            {
                Console.WriteLine("Cantidad no válida");
                return;
            }
        }

        try
        {
            double total = precio * cantidad;
            Console.WriteLine($"Total: {total}");
        }
        catch
        {
            Console.WriteLine("Error al calcular el total");
        }
    }
}
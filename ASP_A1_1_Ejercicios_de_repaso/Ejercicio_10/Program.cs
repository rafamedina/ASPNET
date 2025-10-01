using Ejercicio_8;
using System.Collections;
using System.Numerics;
//Lista de productos

//Guarda varios objetos Productos en un array o en una  lista.
//Usa un bucle foreach para mostrar la presentación de todos los productos.
//Muestra el precio total de los productos.
//Añade el poder meter un descuento del 15%.
//Bonus: hazlo sin duplicar la clase Producto, es decir, reutilizando el código de esta clase que has desarrollado para el ejercicio 7.

public class Ejercicio_10
{
    public static void Main(string[] args)
    {
        List<Producto> lista = new List<Producto>();
        lista.Add(new Producto("Gormiti", "mazo de guapo", 23));
        lista.Add(new Producto("Bakugan", "mazo de guapisimo", 12));
        lista.Add(new Producto("Peonza", "mazo de giratoria", 8));
        double totalPrecio=0;
        foreach (Producto producto in lista)
        {
            totalPrecio = totalPrecio + producto.precio;

        }
        Console.WriteLine($"El precio total es de: {totalPrecio}");
        Console.WriteLine("Qieres un descuento del 15%");
        string sino = Console.ReadLine();
        if (sino.Equals("si", StringComparison.OrdinalIgnoreCase) ||
            sino.Equals("sí", StringComparison.OrdinalIgnoreCase))
        {
           double descuento = totalPrecio * 0.85;
            Console.WriteLine($"El precio final es de {descuento}");
        }
        else
        {
            Console.WriteLine("descuento no aplicado");
        }
    }
}
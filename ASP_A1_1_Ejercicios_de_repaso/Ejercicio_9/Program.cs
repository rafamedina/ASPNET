using Ejercicio_8;
//Compra
    //En Main(), pide al usuario 3 productos con sus precios.
    //Calcula el total de la compra.
    //Bonus: hazlo sin duplicar la clase Producto, es decir, reutilizando el código de esta clase que has desarrollado para el ejercicio 7.
public class Ejercicio_9
{
    public static void Main(string[] args)
    {
        Producto producto1 = new Producto("Regla", "para medir", 12);
        Producto producto2 = new Producto("borra", "para borrar", 7);
        Producto producto3 = new Producto("lápiz", "para escribir", 2);
        producto1.Datos();
        producto2.Datos();
        producto3.Datos();

        double total = producto1.precio + producto2.precio+ producto3.precio;
        Console.WriteLine($"El precio es de: {total}");


    }
}

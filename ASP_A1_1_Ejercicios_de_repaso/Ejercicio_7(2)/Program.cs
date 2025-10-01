//Clase Producto básica
//Crea una clase Producto con atributos: Nombre, descripción, precio.
//Constructor que inicialice estos valores.
//Método Datos() que muestre la información del producto.
//Crea 2-3 objetos en Main() y llama al método Datos() de cada uno.

using Ejercicio_8;
using System;

namespace Ejercicio_8
{
    public class Producto
    {
        public string nombre;
        public string descripcion;
        public double precio;

        public Producto(string nombre, string descripcion, double precio)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }
        public void Datos()
        {
            Console.WriteLine($"El producto: {this.nombre} tiene la descripcion: {this.descripcion} y un precio de : {this.precio}");
        }
    }

}
namespace Maineje8
{
    public class Ejercicio_8
    {
        public static void Main(string[] args)
        {
            Producto producto1 = new Producto("Regla", "para medir", 12);
            Producto producto2 = new Producto("borra", "para borrar", 7);
            Producto producto3 = new Producto("lápiz", "para escribir", 2);
            producto1.Datos();
            producto2.Datos();
            producto3.Datos();
        }
    }
}



//Clase Producto básica
//Crea una clase Producto con atributos: Nombre, descripción, precio.
//Constructor que inicialice estos valores.
//Método Datos() que muestre la información del producto.
//Crea 2-3 objetos en Main() y llama al método Datos() de cada uno.

using Ejercicio_8;
using System;

namespace Ejercicio_8
{
    namespace Ejercicio_8
    {
        public class Producto
        {
            // Propiedades públicas para acceso Get/Set
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            private double precio;

            // Constructor sin parámetros para compatibilidad
            public Producto() { }

            // Constructor con parámetros para inicialización completa
            public Producto(string nombre, string descripcion, double precio)
            {
                Nombre = nombre;
                Descripcion = descripcion;
                Precio = precio;
            }

            // Propiedad con validación para precio
            public double Precio
            {
                get => precio;
                set => precio = value < 0 ? 0 : value;
            }

            public virtual void Datos()
            {
                Console.WriteLine($"El producto: {Nombre} tiene la descripción: {Descripcion} y un precio de : {Precio:C}");
            }
        }
    }
}
//namespace Maineje8
//{
   // public class Ejercicio_8
  //  {
     //   public static void Main(string[] args)
      //  {
         //   Producto producto1 = new Producto("Regla", "para medir", 12);
         //   Producto producto2 = new Producto("borra", "para borrar", 7);
            //Producto producto3 = new Producto("lápiz", "para escribir", 2);
           // producto1.Datos();
            //producto2.Datos();
            //producto3.Datos();
       // }
   // }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class main
    {
        static void Main(string[] args)
        {
        }
    }
    
    class Program
{
    static List<Figura> figuras = new List<Figura>();
    static int LeerOpcion()
    {
        while (true)
        {
            Console.WriteLine("Escoge una opción: ");
            if (int.TryParse(Console.ReadLine(), out int salida))
            {
                if(salida>0 || salida < 6)
                {
                    return salida;
                }                
            }
            else
            {
                Console.WriteLine("Opcion no valida");
            }
        }
    }
    static void CrearFigura()
    {
        Console.WriteLine("Elija Circulo, Rectangulo o Rombo");
        string Figura = Console.ReadLine().ToLower();
        if (Figura.Equals("circulo"))
        {
            Console.WriteLine("Radio: ");
            double radio;
            if(double.TryParse(Console.ReadLine(), out radio))
            {
                Circulo circulo = new Circulo();
                circulo.Radio = radio;
                
                figuras.Add(circulo);
            } else
            {
                Console.WriteLine("No es un numero valido");
            }

        }
    }
    static void VerColeccion()
    {
        foreach (var item in figuras)

        {
            Console.WriteLine(item.ToString());
        }
    }
    static void CalcularAreaTotal()
    {

    }
    static void CalcularPerimetroTotal()
    {

    }
    static void Menu()
    {

    }
}

    //Requisito tecnico de asbtraccion
    abstract class Figura{

    public abstract double calcularArea();
    public abstract double calcularPerimetro();

    }


    //Requisito tecnico de Herencia
class Circulo : Figura{

    private double _radio;
    public double Radio { get=>_radio; set=>_radio= value <=0 ? 1 : value; }

    public double Area { get=> Math.PI * Radio * Radio; }
    public double Perimetro { get=> Math.PI * Math.PI * Radio; }

    public override double calcularArea()
    {
        return Area;
    }

    public override double calcularPerimetro()
    {
        return Perimetro;
    }
    public override string ToString()
    {
        return $"Circulo de Radio {Radio} con área {Area} y perimetro {Perimetro}";
    }
    
}


//Requisito tecnico de Herencia
class Rectangulo : Figura {
    private double _base;
    private double _altura;
    public double Base { get => _base; set => _base = value <= 0 ? 1 : value; }
    public double Altura { get => _altura; set => _altura = value <= 0 ? 1 : value; }

    public double Area { get => Base * Altura; }
    public double Perimetro { get => Base * 2 + Altura * 2; }


    public override double calcularArea()
    {
        return Area;
    }

    public override double calcularPerimetro()
    {
        return Perimetro;
    }
    public override string ToString()
    {
        return $"Rectangulo de Base {Base}, con Altura {Altura}  con área {Area} y perimetro {Perimetro}";
    }
}

//Requisito tecnico de Herencia
class Rombo : Figura{
    private double _DiagonalMayor;
    private double _DiagonalMenor;
    public double DiagonalMayor { get => _DiagonalMayor; set => _DiagonalMayor = value <= 0 ? 1 : value; }
    public double DiagonalMenor { get => _DiagonalMenor; set => _DiagonalMenor = value <= 0 ? 1 : value; }

    public double Area { get => DiagonalMayor * DiagonalMenor / 2; }
    public double Perimetro { get => 2 * Math.Sqrt(Math.Pow(DiagonalMayor,2)*Math.Pow(DiagonalMenor,2)); }

    public override double calcularArea()
    {
        return Area;
    }

    public override double calcularPerimetro()
    {
        return Perimetro;
    }

    public override string ToString()
    {
        return $"Rombo con DiagonalMayor {DiagonalMayor}, con DiagonalMenor {DiagonalMenor}  con área {Area} y perimetro {Perimetro}";
    }

}














//public abstract class Figura
//{
//    protected double area;
//    protected double perimetro;

//    public abstract double CalcularArea();
//    public abstract double CalcularPerimetro();
//}

//public class Circulo : Figura
//{
//    public double _radio;
//    public double Radio { get => _radio; set=> _radio = value <0 ? 1 : value; }
//    public double Area{ get => Math.PI * Radio * Radio; }

//    public Circulo(double radio)
//    {
//        this.radio = radio;
//        area = CalcularArea();
//        perimetro = CalcularPerimetro();

//    }

//    public override double CalcularArea()
//    {
//        area = Math.PI * (radio * radio);
//        return area;
//    }

//    public override double CalcularPerimetro()
//    {
//        perimetro = 2 * Math.PI * radio;
//        return perimetro;
//    }




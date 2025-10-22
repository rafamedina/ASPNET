using System;

public class Ejercicio2
{

    public static void Main(string[] args)
    {
        var palabras = new List<string> { "casa", "coche", "árbol", "mesa", "silla" };
        var mas4letras = from n in palabras where n.Length > 4 select n;
        Console.WriteLine(string.Join(",", mas4letras));
        var mas4letraslambda = palabras.Where(p => p.Length > 4);
        Console.WriteLine(string.Join(",", mas4letraslambda));


        var mayusculas = from n in palabras select n.ToUpper();
        Console.WriteLine(string.Join(",", mayusculas));

        var mayusculaslambda = palabras.Select(p => p.ToUpper());
        Console.WriteLine(string.Join(",", mayusculaslambda));

        var anonimolambda = palabras.Select(p => new { palabra = p, numero = p.Length });
        Console.WriteLine(string.Join(",", anonimolambda));

        var anonimo = from p in palabras
                      select new { palabra = p, numero = p.Length };
        Console.WriteLine(string.Join(",", anonimo));
    }


}
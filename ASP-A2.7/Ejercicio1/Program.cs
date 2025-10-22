using System;

public class Ejercicio1
{
    
    public static void Main(string[] args)
    {
        var  numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var numerosMayores5 = from n in numeros where n > 5 select n;
        Console.WriteLine(string.Join(",", numerosMayores5));
        var numerosMayores5lambda = numeros.Where(n => n > 5);
        Console.WriteLine(string.Join(",", numerosMayores5lambda)); ;


        var numerosPares = from n in numeros where n % 2 == 0 select n;
        Console.WriteLine(string.Join(",", numerosPares));

        var numerosPareslambda = numeros.Where(n => n % 2 == 0);
        Console.WriteLine(string.Join(",", numerosPareslambda));

        var numerosx3 = from n in numeros where n% 3 == 0 select n;
        Console.WriteLine(string.Join(",", numerosx3));

        var numerosx3lambda = numeros.Where(n => n % 3 == 0);
        Console.WriteLine(string.Join(",", numerosx3lambda));
    }
}
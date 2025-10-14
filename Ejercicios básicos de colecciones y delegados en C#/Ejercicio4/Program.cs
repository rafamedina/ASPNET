// See https://aka.ms/new-console-template for more information

public class Ejercicio4
{
    public static void Main(string[] args)
    {
        var diccionario = new Dictionary<string, string>();
        diccionario.Add("España", "Madrid");
        diccionario.Add("Paris", "Francia");
        diccionario.Add("Berlin", "Alemania");

        foreach (var item in diccionario)
        {
            Console.WriteLine(item);
        }
    }
}
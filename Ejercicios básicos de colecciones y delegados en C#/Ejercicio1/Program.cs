// See https://aka.ms/new-console-template for more information
public class Ejercicio1
{

    public static void Main(string[] args)
    {
        var lista = new List<int>();
        lista.Add(1);
        lista.Add(2);
        lista.Add(3);
        lista.Add(4);
        lista.Add(5);

        foreach (int i in lista)
        {
            Console.WriteLine(i);
        }
    }
}
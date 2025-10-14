// See https://aka.ms/new-console-template for more informatio
public class Ejercicio3
{
    public static void Main(string[] args)
    {
        var pila = new Stack<string>();
        pila.Push("A");
        pila.Push("B");
        pila.Push("C");
        try
        {
            for (int i = 0; i < 10; i++)
            {
                string s = pila.Pop();
                Console.WriteLine(s);
            }
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
}

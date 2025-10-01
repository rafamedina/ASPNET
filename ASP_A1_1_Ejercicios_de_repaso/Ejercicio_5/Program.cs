//Aprobado o suspendido
//  Pide una nota y muestra “Aprobado” si es ≥ 5 o “Suspendido” si es < 5.

class Ejercicio_5
{
    public static void Main(string[] args)
    {

        while (true)
        {
            Console.WriteLine("Dame un nota");
            string nota = Console.ReadLine();
            int.TryParse(nota, out int intnota);
            if (intnota>0&&intnota<11)
            {
                if (intnota >= 5)
                {
                    Console.WriteLine("Aprobado");
                    break;
                }
                else { 
                    Console.WriteLine("Suspenso");
                    break;
                }

            }
            else
            {
                Console.WriteLine("Numero no válido");
            }



        }
    }
}

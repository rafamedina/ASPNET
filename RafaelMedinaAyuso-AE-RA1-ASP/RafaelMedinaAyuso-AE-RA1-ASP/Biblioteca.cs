public class Biblioteca
{//Lista de tipo Contenidos con la que trebajamos
    public static List<Contenidos> lista = new List<Contenidos>();
    public static void Main(string[] args)
    {
        //Inicio del programa
        Controller();
    }

    // Metodo que lleva la logica y flujo del programa
    public static void Controller()
    {
        preCarga();
        int eleccion = 1;
        while (eleccion != 0)
        {
            eleccion = Menu();
            switch (eleccion)
            {
                case 1: static void describirColeccion() => lista.ForEach(f => f.Describir());
                    describirColeccion(); 
                    break;
                case 2:

                    reporducirContenido();
                    break;

                default: Console.WriteLine("Opcion no válida"); break;
                case 0: Console.WriteLine("Saliendo..."); eleccion = 0; break;

               
            }
        }
    }

    //Metodo para desplegar menu
    public static int Menu()
    {
        Console.WriteLine("---------- MENÚ BIBLIOTECA -----------");
        Console.WriteLine("1. Listar Contenidos Precargados");
        Console.WriteLine("2. Reproducir Contenidos Precargados");
        Console.WriteLine("0. Salir");
        Console.WriteLine("Que vas a hacer: ");
        return pedirInt();

    }

    //Datos para precargar en la lista
    public static void preCarga()
    {
        Peliculas pelicula1 = new Peliculas("Interestella", 169, "4K", "Christopher Nolan");
        Peliculas pelicula2 = new Peliculas("Feast", 7, "480p", "Patrick Osborbne");
        Peliculas pelicula3 = new Peliculas("El Sextete", 120, "4K", "Pep Guardiola");
        Peliculas pelicula4 = new Peliculas("Kill bill", 165, "1080p", "Tarantino");

        lista.Add(pelicula1);
        lista.Add(pelicula2);
        lista.Add(pelicula3);
        lista.Add(pelicula4);

        Canciones cancion1 = new Canciones("Bohemian Rhapsody", 6, 320, "Protegida");
        Canciones cancion2 = new Canciones("The House of the Rising Sun", 5, 128, "Libre");
        Canciones cancion3 = new Canciones("Niño", 0.5, 320, "Libre");
        Canciones cancion4 = new Canciones("This is the life", 5, 128, "Protegida");

        lista.Add(cancion1);
        lista.Add(cancion2);
        lista.Add(cancion3);
        lista.Add(cancion4);
    }


    //Metodo Auxiliar para pedir un numero entero
    public static int pedirInt()
    {
        while (true)
        {
            String numero = Console.ReadLine();
            if (int.TryParse(numero, out int val))
            {
                return val;

            }
            else
            {
                Console.WriteLine("valor no valido");
            }


        }
    }

// Metodo para mostrar todos los contenidos de la lista y seleccionar uno para reproducirlo
    public static void reporducirContenido()
    {
        bool reproducido = false;
        foreach (Contenidos item in lista)
        {
        item.Describir();

        }
        Console.WriteLine("Selecciona que quieres repodroducir por el nombre: ");
        String eleccion = Console.ReadLine().ToLower();
        foreach (Contenidos item2 in lista)
        {
            if (eleccion.Equals(item2.titulo.ToLower()))
            {
                item2.Reproducir();
                reproducido = true;
                break;
            }
        }
        if (!reproducido)
        {
            Console.WriteLine("Ese objeto no esta en la lista ");
        }
    }
} 
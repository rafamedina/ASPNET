using System.IO;
using System.Transactions;

public abstract class Contenidos
{
    // Propiedad Automatica
    public String titulo { get; set; }

    // Propiedad para trabajar con propiedad no automatica
    public double _duracion { get; set; }

    //Propiedad No automatica que valida que si es menos de 1 te lo iguale a 1
    public double duracion { get => _duracion; set => _duracion = value < 1.0 ? 1.0 : value; }

    //Metodo para sobrescribir en clases hijas
    public abstract double tasaCompresion();

    //Metodo con cuerpo y descripcion para usar en hijos ya por defecto
    public void Describir()
    {
        Console.WriteLine($"Titulo : {titulo} | Describir: PELÍCULA: {titulo} ({duracion} minutos)\n");
    }

    // Constructor
    protected Contenidos(string titulo, double _duracion)
    {
        this.titulo = titulo;
        this._duracion = _duracion;
    }

    //Metodo sin cuerpo para sobrescribir en  hijos
    public abstract void Reproducir();

}

public abstract class ContenidoVisual : Contenidos
{   
    // Constructor que hereda el del padre e implementa sus nuevos atributos
    protected ContenidoVisual(string titulo, double _duracion, String resolucion ) : base(titulo, _duracion)
    {
        resolucionPantalla = resolucion;
    }
    // Propiedad Automatica
    public String resolucionPantalla {  get; set; }

    // Metodo del padre reescrito para funcionar aqui
    public override double tasaCompresion()
    {
        if (resolucionPantalla == "4k" || resolucionPantalla == "4K")
        {
            return 0.6;
        } else
        {
            return 0.9;
        }
    }


}
public class Peliculas : ContenidoVisual
{
  
    // Constructor que hereda el del padre e implementa sus nuevos atributos
    public Peliculas(string titulo, double _duracion, string resolucion, String director) : base(titulo, _duracion, resolucion)
    {
        _director = director;
    }

    //Propiedad no automatica para comprobar que si el nombre del autor es menor que 5 letras sea Desconocido
    public String _director;
    public String Director{get => _director; set => _director = _director.Length < 5.0 ? "Desconocido" : value; }

    //validacion de campos para el Reproducir
    public static String queEs(double duracion)
    {
        if (duracion < 60) { return "CORTOMETRAJE"; } else { return "PELÍCULA"; }
    }

    //Reescribir el metodo del padre para el hijo
    public override void Reproducir()
    {
        
        Console.WriteLine($" * * * INICIO DE {queEs(duracion)} {titulo} * * * ");
        Console.WriteLine("[INFO] Cargando componentes visuales");
        Console.WriteLine($"[CREDITO] Director : {Director}");
        Console.WriteLine($"[INFO] Tasa de compresion reportada: {tasaCompresion()}");
        Console.WriteLine($"Reproducción finalizada: {titulo}\n");
        

    }
}

public abstract class ContenidoAuditivo : Contenidos
{
    // Propiedad Automatica
    public double bitrate;
    // Constructor que hereda el del padre e implementa sus nuevos atributos
    protected ContenidoAuditivo(string titulo, double _duracion, double _bitrate) : base(titulo, _duracion)
    {
        bitrate = _bitrate;
    }



    // Metodo del padre reescrito para funcionar aqui
    public override double tasaCompresion() => 1.0 - (bitrate / 500);



}

public class Canciones : ContenidoAuditivo
{  
    // Constructor que hereda el del padre e implementa sus nuevos atributos
    public Canciones(string titulo, double _duracion, double _bitrate, String _licencia) : base(titulo, _duracion, _bitrate)
    {
        licencia = _licencia;
    }
    // Propiedad Automatica
    public String licencia {  get; set; }

    //Metodo del padre reescrito para el hijo
    public override void Reproducir()
    {
        Console.WriteLine($" * * * INICIO DE CANCIÓN {titulo} * * * ");
        Console.WriteLine($"[INFO] Bitrate utilizado: {bitrate} kbps");
        Console.WriteLine($"{queEs(licencia)}");
        Console.WriteLine($"[INFO] Tasa de compresion reportada: {tasaCompresion()}");
        Console.WriteLine($"Reproducción finalizada: {titulo}\n");

    }
    //validacion de campos para el Reproducir
    public static String queEs(string tipo)
    {
        if (tipo.Equals("Protegida")) { return "Advertencia pago de Royalties aplicado"; } else { return "No tiene Royalties"; }
    }
}



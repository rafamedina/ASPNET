using System.Globalization;

public abstract class Empleado
{
    public String Nombre {  get; set; }
    private double salarioBase;
    public double SalarioBase { get=> salarioBase ; set => salarioBase = (value < 0) ? 0.0 : value ; }




    public Empleado(String nombre, double salario)
    {
        this.Nombre = nombre;
        this.SalarioBase = salario;
    }

    public abstract double CalcularNomina();
    public override string ToString()
    {
        return $"Nombre: {Nombre}, Salario base: {SalarioBase:C2}";
    }

}
public class EmpleadoBase : Empleado
{
    public EmpleadoBase(string nombre, double salarioBase)
        : base(nombre, salarioBase)
    {
    }

    public override double CalcularNomina()
    {
        return SalarioBase;
    }

    public override string ToString()
    {
        return $"[Empleado Base] {base.ToString()}";
    }
}
public class EmpleadoFijo : Empleado
{
    private double bonoAnual;

    public double BonoAnual
    {
        get => bonoAnual;
        set => bonoAnual = (value < 0) ? 0.0 : value;
    }

    public EmpleadoFijo(string nombre, double salarioBase, double bonoAnual)
        : base(nombre, salarioBase)
    {
        BonoAnual = bonoAnual;
    }

    public override double CalcularNomina()
    {
        return SalarioBase + (BonoAnual / 12.0);
    }

    public override string ToString()
    {
        return $"[Empleado Fijo] {base.ToString()}, Bono anual: {BonoAnual:C2}";
    }
}
public class EmpleadoPorHora : Empleado
{
    private double tarifaHora;
    private double horasTrabajadasMes;

    public double TarifaHora
    {
        get => tarifaHora;
        set => tarifaHora = (value < 0) ? 0.0 : value;
    }

    public double HorasTrabajadasMes
    {
        get => horasTrabajadasMes;
        set => horasTrabajadasMes = (value < 0) ? 0.0 : value;
    }

    public EmpleadoPorHora(string nombre, double salarioBase,
                           double tarifaHora, double horasTrabajadasMes)
        : base(nombre, salarioBase)
    {
        TarifaHora = tarifaHora;
        HorasTrabajadasMes = horasTrabajadasMes;
    }

    public override double CalcularNomina()
    {
        return SalarioBase + (TarifaHora * HorasTrabajadasMes);
    }

    public override string ToString()
    {
        return $"[Empleado Por Hora] {base.ToString()}, Tarifa/hora: {TarifaHora:C2}, Horas mes: {HorasTrabajadasMes:F2}";
    }
}

internal class Program
{
    private static List<Empleado> empleados = new List<Empleado>();

    private static void Main(string[] args)
    {
        // Para interpretar comas/puntos de forma consistente
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        int opcion;
        do
        {
            Console.WriteLine("\n=== HRSystem TechSolutions S.L. ===");
            Console.WriteLine("1. Contratar empleado");
            Console.WriteLine("2. Ver nóminas individuales");
            Console.WriteLine("3. Calcular coste total de nóminas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    ContratarEmpleado();
                    break;
                case 2:
                    VerNominas();
                    break;
                case 3:
                    CalcularCosteTotal();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 4);
    }

    private static void ContratarEmpleado()
    {
        Console.WriteLine("\nTipo de empleado:");
        Console.WriteLine("1. Empleado Base");
        Console.WriteLine("2. Empleado Fijo");
        Console.WriteLine("3. Empleado Por Hora");
        Console.Write("Seleccione tipo: ");

        if (!int.TryParse(Console.ReadLine(), out int tipo))
        {
            Console.WriteLine("Tipo inválido.");
            return;
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        double salarioBase = LeerDoubleConValidacion("Salario base: ");

        switch (tipo)
        {
            case 1:
                empleados.Add(new EmpleadoBase(nombre, salarioBase));
                Console.WriteLine("Empleado base contratado correctamente.");
                break;

            case 2:
                double bonoAnual = LeerDoubleConValidacion("Bono anual: ");
                empleados.Add(new EmpleadoFijo(nombre, salarioBase, bonoAnual));
                Console.WriteLine("Empleado fijo contratado correctamente.");
                break;

            case 3:
                double tarifaHora = LeerDoubleConValidacion("Tarifa por hora: ");
                double horasMes = LeerDoubleConValidacion("Horas trabajadas en el mes: ");
                empleados.Add(new EmpleadoPorHora(nombre, salarioBase, tarifaHora, horasMes));
                Console.WriteLine("Empleado por hora contratado correctamente.");
                break;

            default:
                Console.WriteLine("Tipo de empleado no válido.");
                break;
        }
    }

    private static void VerNominas()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("\nNo hay empleados registrados.");
            return;
        }

        Console.WriteLine("\n--- Nóminas Individuales ---");
        foreach (var emp in empleados)
        {
            double nomina = emp.CalcularNomina();
            Console.WriteLine($"{emp.ToString()}, Nómina mensual: {nomina:C2}");
        }
    }

    private static void CalcularCosteTotal()
    {
        double total = 0.0;

        foreach (var emp in empleados)
        {
            total += emp.CalcularNomina();
        }

        Console.WriteLine($"\nCoste total mensual de nóminas: {total:C2}");
    }

    // Lee un double; si no es válido, toma 0. Si es negativo, las propiedades lo corrigen a 0.
    private static double LeerDoubleConValidacion(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "0";

        if (!double.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
        {
            valor = 0.0;
        }

        // La lógica de "si es negativo -> 0" se aplica en las propiedades.
        return valor;
    }
}


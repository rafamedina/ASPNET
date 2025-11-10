using System;
using System.Collections.Generic;
using System.Globalization;

namespace LogiTrack
{
    // ==========================================
    // EJERCICIO 1: CLASE BASE ENVIO
    // ==========================================
    public abstract class Envio
    {
        // Propiedad automática
        public string Descripcion { get; set; }

        // Campo + propiedad con validación
        private double peso;
        public double Peso
        {
            get => peso;
            set => peso = (value < 0) ? 0.0 : value;
        }

        // Costo base por kg (constante)
        protected const double CostoBasePorKg = 2.0;

        // Propiedad de solo lectura:
        // Costo base total = Peso * 2.0€
        public double CostoBase
        {
            get => Peso * CostoBasePorKg;
        }

        protected Envio(string descripcion, double peso)
        {
            Descripcion = descripcion;
            Peso = peso;
        }

        // Método polimórfico
        public abstract double CalcularCostoTotal();

        // ToString virtual (polimórfico)
        public override string ToString()
        {
            return $"Descripción: {Descripcion}, Peso: {Peso:F2} kg, Costo base: {CostoBase:F2}€";
        }
    }

    // ==========================================
    // EJERCICIO 2: PAQUETE ESTÁNDAR
    // ==========================================
    public class PaqueteEstandar : Envio
    {
        private double tarifaPlana;

        public double TarifaPlana
        {
            get => tarifaPlana;
            set => tarifaPlana = (value < 0) ? 0.0 : value;
        }

        public PaqueteEstandar(string descripcion, double peso, double tarifaPlana)
            : base(descripcion, peso)
        {
            TarifaPlana = tarifaPlana;
        }

        public override double CalcularCostoTotal()
        {
            return CostoBase + TarifaPlana;
        }

        public override string ToString()
        {
            return $"[Paquete Estándar] {base.ToString()}, Tarifa plana: {TarifaPlana:F2}€";
        }
    }

    // ==========================================
    // EJERCICIO 3: PAQUETE EXPRESS
    // ==========================================
    public class PaqueteExpress : Envio
    {
        private double recargoUrgencia;

        // Interpretamos RecargoUrgencia como importe por kg adicional
        // El enunciado dice: CostoTotal = CostoBase + RecargoUrgencia x Peso
        public double RecargoUrgencia
        {
            get => recargoUrgencia;
            set => recargoUrgencia = (value < 0) ? 0.0 : value;
        }

        public PaqueteExpress(string descripcion, double peso, double recargoUrgencia)
            : base(descripcion, peso)
        {
            RecargoUrgencia = recargoUrgencia;
        }

        public override double CalcularCostoTotal()
        {
            return CostoBase + (RecargoUrgencia * Peso);
        }

        public override string ToString()
        {
            return $"[Paquete Express] {base.ToString()}, Recargo urgencia/kg: {RecargoUrgencia:F2}€";
        }
    }

    // ==========================================
    // EJERCICIO 4: APLICACIÓN DE CONSOLA
    // ==========================================
    internal class Program
    {
        private static List<Envio> envios = new List<Envio>();

        private static void Main(string[] args)
        {


            int opcion;
            do
            {
                Console.WriteLine("\n=== Sistema LogiTrack S.A. ===");
                Console.WriteLine("1. Crear envío");
                Console.WriteLine("2. Ver costos individuales");
                Console.WriteLine("3. Calcular ingreso total");
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
                        CrearEnvio();
                        break;
                    case 2:
                        VerCostosIndividuales();
                        break;
                    case 3:
                        CalcularIngresoTotal();
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

        private static void CrearEnvio()
        {
            Console.WriteLine("\nTipo de paquete:");
            Console.WriteLine("1. Paquete Estándar");
            Console.WriteLine("2. Paquete Express");
            Console.Write("Seleccione tipo: ");

            if (!int.TryParse(Console.ReadLine(), out int tipo))
            {
                Console.WriteLine("Tipo inválido.");
                return;
            }

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine() ?? "";

            double peso = LeerDoubleConValidacion("Peso en kg: ");

            switch (tipo)
            {
                case 1:
                    // Tarifa plana fija recomendada 10.0€, pero dejamos que el usuario introduzca.
                    double tarifaPlana = LeerDoubleConValidacion("Tarifa plana (€): ");
                    envios.Add(new PaqueteEstandar(descripcion, peso, tarifaPlana));
                    Console.WriteLine("Paquete estándar creado correctamente.");
                    break;

                case 2:
                    double recargo = LeerDoubleConValidacion("Recargo urgencia por kg (€): ");
                    envios.Add(new PaqueteExpress(descripcion, peso, recargo));
                    Console.WriteLine("Paquete express creado correctamente.");
                    break;

                default:
                    Console.WriteLine("Tipo de paquete no válido.");
                    break;
            }
        }

        private static void VerCostosIndividuales()
        {
            if (envios.Count == 0)
            {
                Console.WriteLine("\nNo hay envíos registrados.");
                return;
            }

            Console.WriteLine("\n--- Costos Individuales ---");
            foreach (var envio in envios)
            {
                double costoTotal = envio.CalcularCostoTotal();
                Console.WriteLine($"{envio.ToString()}, Costo total: {costoTotal:F2}€");
            }
        }

        private static void CalcularIngresoTotal()
        {
            double total = 0.0;

            foreach (var envio in envios)
            {
                total += envio.CalcularCostoTotal();
            }

            Console.WriteLine($"\nIngreso total por envíos: {total:F2}€");
        }

        // Lee un double; si es inválido, lo deja en 0.0.
        // Si luego es negativo, las propiedades lo corrigen a 0.0.
        private static double LeerDoubleConValidacion(string mensaje)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine() ?? "0";

            if (!double.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
            {
                valor = 0.0;
            }

            return valor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;

namespace FleetManager
{
    // ==============================
    // CLASE BASE: VEHÍCULO
    // ==============================
    public class Vehiculo
    {
        // Propiedad automática
        public string Matricula { get; set; }

        // Campo + propiedad con validación
        private double consumo; // litros por 100 km
        public double Consumo
        {
            get => consumo;
            set => consumo = (value < 0) ? 0.0 : value;
        }

        // Costo operacional base (€/litro)
        protected const double CostoOperacionalBase = 0.15;

        public Vehiculo(string matricula, double consumo)
        {
            Matricula = matricula;
            Consumo = consumo;
        }

        // Método polimórfico: costo por km (por defecto solo combustible)
        public virtual double CalcularCostoPorKm()
        {
            // Interpretamos "Consumo" según enunciado directamente:
            // CostePorKm = Consumo x CostoOperacionalBase
            return Consumo * CostoOperacionalBase;
        }

        public override string ToString()
        {
            return $"Matrícula: {Matricula}, Consumo: {Consumo:F2} L/100km";
        }
    }

    // ==============================
    // AUTOBÚS (TRANSPORTE PASAJEROS)
    // ==============================
    public class Autobus : Vehiculo
    {
        private double capacidadMaxima;

        public double CapacidadMaxima
        {
            get => capacidadMaxima;
            set => capacidadMaxima = (value < 0) ? 0.0 : value;
        }

        private const double FactorDesgaste = 1.2;

        public Autobus(string matricula, double consumo, double capacidadMaxima)
            : base(matricula, consumo)
        {
            CapacidadMaxima = capacidadMaxima;
        }

        public override double CalcularCostoPorKm()
        {
            // Se apoya en el cálculo base y aplica el factor
            return base.CalcularCostoPorKm() * FactorDesgaste;
        }

        public override string ToString()
        {
            return $"[Autobús] {base.ToString()}, Capacidad máx.: {CapacidadMaxima:F0} pasajeros";
        }
    }

    // ==============================
    // CAMIÓN (TRANSPORTE CARGA)
    // ==============================
    public class Camion : Vehiculo
    {
        private double peajeAnual;

        public double PeajeAnual
        {
            get => peajeAnual;
            set => peajeAnual = (value < 0) ? 0.0 : value;
        }

        private const double KmReferencia = 100000.0;

        public Camion(string matricula, double consumo, double peajeAnual)
            : base(matricula, consumo)
        {
            PeajeAnual = peajeAnual;
        }

        public override double CalcularCostoPorKm()
        {
            // Costo base combustible + peaje fijo por km
            double costoBase = base.CalcularCostoPorKm();
            double peajePorKm = PeajeAnual / KmReferencia;
            return costoBase + peajePorKm;
        }

        public override string ToString()
        {
            return $"[Camión] {base.ToString()}, Peaje anual: {PeajeAnual:F2}€";
        }
    }

    // ==============================
    // APLICACIÓN DE CONSOLA
    // ==============================
    internal class Program
    {
        private static List<Vehiculo> flota = new List<Vehiculo>();
        private const double DistanciaFlota = 100000.0;

        private static void Main(string[] args)
        {

            int opcion;
            do
            {
                Console.WriteLine("\n=== FleetManager S.A. ===");
                Console.WriteLine("1. Registrar vehículo");
                Console.WriteLine("2. Ver costos operacionales por km");
                Console.WriteLine("3. Calcular costo total de flota (100,000 km por vehículo)");
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
                        RegistrarVehiculo();
                        break;
                    case 2:
                        VerCostosOperacionales();
                        break;
                    case 3:
                        CalcularCostoTotalFlota();
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

        private static void RegistrarVehiculo()
        {
            Console.WriteLine("\nTipo de vehículo:");
            Console.WriteLine("1. Autobús");
            Console.WriteLine("2. Camión");
            Console.Write("Seleccione tipo: ");

            if (!int.TryParse(Console.ReadLine(), out int tipo))
            {
                Console.WriteLine("Tipo inválido.");
                return;
            }

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine() ?? "";

            double consumo = LeerDoubleConValidacion("Consumo (litros por 100 km): ");

            switch (tipo)
            {
                case 1:
                    double capacidad = LeerDoubleConValidacion("Capacidad máxima de pasajeros: ");
                    flota.Add(new Autobus(matricula, consumo, capacidad));
                    Console.WriteLine("Autobús registrado correctamente.");
                    break;

                case 2:
                    double peaje = LeerDoubleConValidacion("Peaje anual (€): ");
                    flota.Add(new Camion(matricula, consumo, peaje));
                    Console.WriteLine("Camión registrado correctamente.");
                    break;

                default:
                    Console.WriteLine("Tipo de vehículo no válido.");
                    break;
            }
        }

        private static void VerCostosOperacionales()
        {
            if (flota.Count == 0)
            {
                Console.WriteLine("\nNo hay vehículos registrados.");
                return;
            }

            Console.WriteLine("\n--- Costos Operacionales por Km ---");
            foreach (var vehiculo in flota)
            {
                double costoKm = vehiculo.CalcularCostoPorKm();
                Console.WriteLine($"{vehiculo.ToString()}, Costo por km: {costoKm:F4}€");
            }
        }

        private static void CalcularCostoTotalFlota()
        {
            if (flota.Count == 0)
            {
                Console.WriteLine("\nNo hay vehículos registrados.");
                return;
            }

            double total = 0.0;

            foreach (var vehiculo in flota)
            {
                double costoKm = vehiculo.CalcularCostoPorKm();
                total += costoKm * DistanciaFlota;
            }

            Console.WriteLine($"\nCosto total de la flota para {DistanciaFlota:F0} km por vehículo: {total:F2}€");
        }

        // Lee un double; si es inválido -> 0.0.
        // Si fuera negativo, la propiedad del objeto lo corregirá a 0.0.
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

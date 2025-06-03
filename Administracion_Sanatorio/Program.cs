using System;

namespace AdministracionSanatorio
{
    public class Program
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();

            //testing(hospital);
            
            MenuInteractivo(hospital);
        }

        public static void testing(Hospital institucion)
        {
            institucion.Pacientes.Add(new Paciente("69696969", "Sigma Chad", "9696-7777", "GigaChads", 99));

            institucion.MostrarPacientes();

            institucion.AsignarIntervencion("69696969", "INT004");

            Console.WriteLine($"Costo total de las intervenciones del paciente con dni 69696969: ${institucion.CalcularCostoTotal("69696969"):F2}");

            institucion.MostrarLiquidacionesPendientes();
        }

        public static void MenuInteractivo(Hospital hospital)
        {
            while (true)
            {
                Console.WriteLine("\n=== MENÚ DEL HOSPITAL ===");
                Console.WriteLine("1. Dar de alta un nuevo Paciente");
                Console.WriteLine("2. Listar los pacientes");
                Console.WriteLine("3. Asignar una nueva intervención a un Paciente");
                Console.WriteLine("4. Calcular el costo de las intervenciones de un paciente (por DNI)");
                Console.WriteLine("5. Reporte de liquidaciones pendientes de pago");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("DNI: ");
                        string dni = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();
                        Console.Write("Obra Social (dejar vacío si no tiene): ");
                        string obraSocial = Console.ReadLine();

                        int porcentajeCobertura;
                        while (true)
                        {
                            Console.Write("Porcentaje de cobertura (0 si no tiene): ");
                            string buffer = Console.ReadLine();
                            if (int.TryParse(buffer, out porcentajeCobertura) && porcentajeCobertura >= 0 && porcentajeCobertura <= 100)
                                break;
                            Console.WriteLine("Por favor, ingrese un número válido entre 0 y 100.");
                        }

                        hospital.Pacientes.Add(new Paciente(dni, nombre, telefono, obraSocial, porcentajeCobertura));
                        Console.WriteLine("\nPaciente dado de ALTA correctamente");
                        break;

                    case "2":
                        hospital.MostrarPacientes();
                        break;

                    case "3":
                        Console.Write("DNI del paciente: ");
                        string dniInterv = Console.ReadLine();
                        Console.Write("Código de la intervención: ");
                        string codInterv = Console.ReadLine();

                        try
                        {
                            hospital.AsignarIntervencion(dniInterv, codInterv);
                            Console.WriteLine("\nIntervención asignada correctamente.");
                        }
                        catch (Exception excepcion)
                        {
                            Console.WriteLine("Error: " + excepcion.Message);
                        }
                        break;

                    case "4":
                        Console.Write("DNI del paciente: ");
                        string dniCosto = Console.ReadLine();
                        double costo = hospital.CalcularCostoTotal(dniCosto);
                        Console.WriteLine($"\nCosto total de las intervenciones del paciente con DNI {dniCosto}: ${costo:F2}");
                        break;

                    case "5":
                        hospital.MostrarLiquidacionesPendientes();
                        break;

                    case "0":
                        Console.WriteLine("Gracias por usar el sistema :D");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}

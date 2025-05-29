using System;

namespace AdministracionSanatorio
{
    public class Program
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();
            hospital.Pacientes.Add(new Paciente("69696969", "Sigma Chad", "9696-7777", "GigaChads", 99));

            MostrarPacientes(hospital);

            hospital.AsignarIntervencion("69696969", "INT004");
        }

        public static void MostrarPacientes(Hospital hospital)
        {
            Console.WriteLine("Listado de pacientes registrados:");
            foreach (var paciente in hospital.Pacientes)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"DNI: {paciente.dni}");
                Console.WriteLine($"Nombre: {paciente.nombre}");
                Console.WriteLine($"Teléfono: {paciente.telefono}");
                Console.WriteLine($"Obra Social: {(string.IsNullOrEmpty(paciente.obraSocial) ? "-" : paciente.obraSocial)}");
                Console.WriteLine($"Porcentaje Cobertura: {paciente.porcentajeCobertura}%");
                Console.WriteLine("Intervenciones realizadas: " + (paciente.intervenciones?.Count ?? 0));
                if (paciente.intervenciones != null && paciente.intervenciones.Count > 0)
                {
                    foreach (var interv in paciente.intervenciones)
                    {
                        Console.WriteLine($"  - {interv.descripcion} ({interv.codigo}) - {interv.especialidad} - ${interv.arancel}");
                    }
                }
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}

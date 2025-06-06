using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public class Hospital
    {
        public List<Doctor> Doctores { get; set; } = new List<Doctor>();
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public List<Intervencion> Intervenciones { get; set; } = new List<Intervencion>();

        public List<RegistroIntervencion> Registros { get; set; } = new List<RegistroIntervencion>();

        public Hospital()
        {
            // Doctores
            Doctores.Add(new Doctor("Juan Pérez", "12345", "Cardiología", true));
            Doctores.Add(new Doctor("Laura Gómez", "23456", "Traumatología", false));
            Doctores.Add(new Doctor("Carlos Ruiz", "34567", "Neurología", true));
            Doctores.Add(new Doctor("María Silva", "45678", "Gastroenterología", true));
            Doctores.Add(new Doctor("Fernando Torres", "56789", "Cardiología", true));
            Doctores.Add(new Doctor("Cecilia López", "67890", "Traumatología", true));

            // Pacientes
            Pacientes.Add(new Paciente("30111222", "Ana Torres", "1111-2222", "ObraMed", 80));
            Pacientes.Add(new Paciente("29222333", "Luis Fernández", "2222-3333", null, 0));
            Pacientes.Add(new Paciente("28444555", "Clara Méndez", "3333-4444", "SaludPlus", 90));
            Pacientes.Add(new Paciente("27555666", "Pedro Gómez", "4444-5555", "VidaTotal", 70));
            Pacientes.Add(new Paciente("26666777", "Lucía Ortega", "5555-6666", null, 0));
            Pacientes.Add(new Paciente("25777888", "Jorge Ramírez", "6666-7777", "SaludPlus", 60));

            // Intervenciones comunes
            Intervenciones.Add(new IntervencionComun("INT001", "Bypass coronario", "Cardiología", 120000));
            Intervenciones.Add(new IntervencionComun("INT003", "Artroscopía de rodilla", "Traumatología", 80000));
            Intervenciones.Add(new IntervencionComun("INT005", "Endoscopía digestiva", "Gastroenterología", 40000));
            Intervenciones.Add(new IntervencionComun("INT007", "Colocación de stent", "Cardiología", 95000));
            Intervenciones.Add(new IntervencionComun("INT008", "Reducción de fractura", "Traumatología", 60000));

            // Intervenciones de alta complejidad
            Intervenciones.Add(new IntervencionAltaComplejidad("INT002", "Neurocirugía", "Neurología", 200000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT004", "Revascularización miocárdica", "Cardiología", 250000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT006", "Cirugía de columna", "Traumatología", 180000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT009", "Cirugía bariátrica", "Gastroenterología", 220000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT010", "Craneotomía", "Neurología", 270000));
        }

        public void AsignarIntervencion(string dniPaciente, string codigoIntervencion)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.dni == dniPaciente);
            if (paciente == null)
                throw new Exception("Paciente no encontrado.");

            var intervencion = Intervenciones.FirstOrDefault(i => i.codigo == codigoIntervencion);
            if (intervencion == null)
                throw new Exception("Intervención no encontrada.");

            var medico = Doctores.FirstOrDefault(d => d.especialidad.Equals(intervencion.especialidad, StringComparison.OrdinalIgnoreCase) && d.disponible);
            if (medico == null)
                throw new Exception("No hay médico disponible con la especialidad requerida.");


            paciente.intervenciones.Add(intervencion);

            var registro = new RegistroIntervencion(DateTime.Now, intervencion, medico, paciente, false);

            Registros.Add(registro);
        }

        public void MostrarPacientes()
        {
            Console.WriteLine("\nListado de pacientes registrados:");
            foreach (var paciente in Pacientes)
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

        public double CalcularCostoTotal(string dni)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.dni == dni);
            if (paciente == null || paciente.intervenciones == null)
                return 0;

            double costoTotal = 0;
            foreach (var interv in paciente.intervenciones)
            {
                costoTotal += interv.arancel * (1 - paciente.porcentajeCobertura / 100.0);
            }
            return costoTotal;
        }

        public void MostrarLiquidacionesPendientes()
        {
            Console.WriteLine("\n=== Reporte de Liquidaciones Pendientes ===");
            var pendientes = Registros.Where(r => !r.Pagado);

            if (!pendientes.Any())
            {
                Console.WriteLine("No hay liquidaciones pendientes.");
                return;
            }

            foreach (var reg in pendientes)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"ID: {reg.Id}");
                Console.WriteLine($"Fecha: {reg.Fecha}");
                Console.WriteLine($"Paciente: {reg.Paciente.nombre} (DNI: {reg.Paciente.dni})");
                Console.WriteLine($"Médico: {reg.Medico.nombre} (Matrícula: {reg.Medico.matricula})");
                Console.WriteLine($"Intervención: {reg.Intervencion.descripcion} ({reg.Intervencion.codigo})");
                Console.WriteLine($"Obra Social: {(string.IsNullOrEmpty(reg.Paciente.obraSocial) ? "-" : reg.Paciente.obraSocial)}");
                Console.WriteLine($"Importe Total: ${reg.Intervencion.arancel * (1 - reg.Paciente.porcentajeCobertura / 100.0):F2}");
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}

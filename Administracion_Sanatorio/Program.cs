using System;

namespace Administracion_Sanatorio
{
    public class Program
    {
        private static RegistroIntervencion[] registros = new RegistroIntervencion[100];
        private static int registroIndex = 0;

        public static void Main()
        {
            RegistrarIntervencion("12345678", "INT001", "MP12345", DateTime.Now, false); //personalmente guardaria todos, los pendientes y los pagados

            GenerarReporteLiquidaciones();
        }

        public static void RegistrarIntervencion(string documentoPaciente, string codigoIntervencion, string matriculaMedico, DateTime fecha, bool pagado)
        {
            if (registroIndex >= registros.Length)
            {
                Console.WriteLine("Error: No se pueden registrar más intervenciones, el arreglo está lleno.");
                return;
            }

            Paciente paciente = Array.Find(BaseDeDatos.Pacientes, p => p.DocumentoIdentidad == documentoPaciente);
            if (paciente == null)
            {
                Console.WriteLine("Error: Paciente no encontrado.");
                return;
            }

            Intervencion intervencion = Array.Find(BaseDeDatos.Intervenciones, i => i.Codigo == codigoIntervencion);
            if (intervencion == null)
            {
                Console.WriteLine("Error: Intervención no encontrada.");
                return;
            }

            Medico medico = Array.Find(BaseDeDatos.Medicos, m => m.MatriculaProfesional == matriculaMedico);
            // mucho no entiendo que hace el string.equals pero me ayuda a comparar sin tomar en cuenta mayusculas y minusculas
            if (medico == null || !string.Equals(medico.Especialidad, intervencion.Especialidad, StringComparison.OrdinalIgnoreCase) || !medico.Disponible)
            {
                Console.WriteLine("Error: Médico no disponible o no coincide con la especialidad requerida.");
                return;
            }

            decimal costoTotal = intervencion.Arancel;
            if (intervencion is IntervencionAltaComplejidad altaComplejidad) //demasiados warnings de null me van a volver loco
            {
                costoTotal += (costoTotal * altaComplejidad.PorcentajeAdicional / 100);
            }

            if (paciente.ObraSocial)
            {
                costoTotal -= paciente.MontoCobertura;
                if (costoTotal < 0)
                {
                    costoTotal = 0;

                }
            }

            registros[registroIndex++] = new RegistroIntervencion
            {
                Id = registroIndex,
                Fecha = fecha,
                Paciente = paciente,
                Intervencion = intervencion,
                Medico = medico,
                Pagado = pagado,
                CostoTotal = costoTotal
            };

            Console.WriteLine("\nIntervención registrada exitosamente.");
        }

        public static void GenerarReporteLiquidaciones()
        {
            Console.WriteLine("\nReporte de Liquidaciones Pendientes:");
            Console.WriteLine("ID | Fecha       | Paciente          | Médico            | Costo Total");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var registro in registros)
            {
                if (registro != null && !registro.Pagado)
                {
                    Console.WriteLine($"{registro.Id,-2} | {registro.Fecha.ToShortDateString(),-11} | {registro.Paciente.Nombre} {registro.Paciente.Apellido,-12} | {registro.Medico.Nombre} {registro.Medico.Apellido,-12} | ${registro.CostoTotal:F2}");
                }
            }
        }
    }
}
using System;

namespace AdministracionSanatorio
{
    public class RegistroIntervencion
    {
        private static int _ultimoId = 0; // Para asignar IDs automáticamente

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Intervencion Intervencion { get; set; }
        public Doctor Medico { get; set; }
        public Paciente Paciente { get; set; }
        public bool Pagado { get; set; }

        public RegistroIntervencion(DateTime fecha, Intervencion intervencion, Doctor medico, Paciente paciente, bool pagado)
        {
            if (medico == null || intervencion == null)
                throw new ArgumentException("Médico e intervención no pueden ser nulos.");
            if (!medico.especialidad.Equals(intervencion.especialidad, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("El médico no tiene la especialidad requerida para la intervención.");

            Id = ++_ultimoId;
            Fecha = fecha;
            Intervencion = intervencion;
            Medico = medico;
            Paciente = paciente;
            Pagado = pagado;
        }
    }
}
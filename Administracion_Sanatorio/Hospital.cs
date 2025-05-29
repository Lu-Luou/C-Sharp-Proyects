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

            this.Registros.Add(registro);
        }
    }
}

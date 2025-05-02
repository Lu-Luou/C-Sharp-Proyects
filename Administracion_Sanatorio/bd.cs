using System;

namespace Administracion_Sanatorio
{
    public static class BaseDeDatos
    {
        // Arreglo de Médicos
        public static Medico[] Medicos = new Medico[]
        {
            new Medico { Nombre = "Juan", Apellido = "Pérez", MatriculaProfesional = "MP12345", Especialidad = "Cardiología", Disponible = true },
            new Medico { Nombre = "Ana", Apellido = "Gómez", MatriculaProfesional = "MP67890", Especialidad = "Traumatología", Disponible = false },
            new Medico { Nombre = "Luis", Apellido = "Martínez", MatriculaProfesional = "MP11223", Especialidad = "Cirugía General", Disponible = true }
        };

        // Arreglo de Pacientes
        public static Paciente[] Pacientes = new Paciente[]
        {
            new Paciente { DocumentoIdentidad = "12345678", Nombre = "Carlos", Apellido = "López", Telefono = "123456789", ObraSocial = true, MontoCobertura = 5000.00m },
            new Paciente { DocumentoIdentidad = "87654321", Nombre = "María", Apellido = "Fernández", Telefono = "987654321", ObraSocial = false, MontoCobertura = 0 },
            new Paciente { DocumentoIdentidad = "45678912", Nombre = "Lucía", Apellido = "García", Telefono = "456789123", ObraSocial = true, MontoCobertura = 3000.00m }
        };

        // Arreglo de Intervenciones Quirúrgicas
        public static Intervencion[] Intervenciones = new Intervencion[]
        {
            new IntervencionAltaComplejidad { Codigo = "INT001", Descripcion = "Bypass coronario", Especialidad = "Cardiología", Arancel = 20000.00m, PorcentajeAdicional = 15.00m },
            new Intervencion { Codigo = "INT002", Descripcion = "Reparación de fractura", Especialidad = "Traumatología", Arancel = 8000.00m },
            new IntervencionAltaComplejidad { Codigo = "INT003", Descripcion = "Apendicectomía", Especialidad = "Cirugía General", Arancel = 10000.00m, PorcentajeAdicional = 10.00m }
        };
    }
}
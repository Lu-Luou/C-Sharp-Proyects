using System;

namespace Administracion_Sanatorio
{
    public class Paciente
    {
        public string DocumentoIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public bool ObraSocial { get; set; }
        public decimal MontoCobertura { get; set; } //copilot me lo armo con decimal y me di cuenta tarde
    }
}
using System;

namespace Administracion_Sanatorio
{
    public class RegistroIntervencion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Paciente Paciente { get; set; }
        public Intervencion Intervencion { get; set; }
        public Medico Medico { get; set; }
        public bool Pagado { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
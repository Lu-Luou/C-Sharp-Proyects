using System;

namespace Administracion_Sanatorio
{
    public class Intervencion
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Especialidad { get; set; }
        public decimal Arancel { get; set; }
    }

    public class IntervencionAltaComplejidad : Intervencion
    {
        public decimal PorcentajeAdicional { get; set; }
    }
}
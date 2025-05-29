using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public abstract class Intervencion
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string especialidad { get; set; }
        public int arancel { get; set; }
    }

    public class IntervencionComun : Intervencion
    {
        public IntervencionComun(string codigo, string descripcion, string especialidad, int arancel)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.especialidad = especialidad;
            this.arancel = arancel;
        }
    }

    public class IntervencionAltaComplejidad : Intervencion
    {
        int porcentaje_adicional = 20;

        public IntervencionAltaComplejidad(string codigo, string descripcion, string especialidad, int arancel)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.especialidad = especialidad;
            this.arancel = (arancel * (100 + porcentaje_adicional)) / 100;
        }
    }
}

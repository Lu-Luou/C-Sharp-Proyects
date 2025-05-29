using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public class Paciente
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string obraSocial { get; set; }
        public int porcentajeCobertura { get; set; }
        public List<Intervencion> intervenciones { get; set; }
        public Paciente(string dni, string nombre, string telefono, string obraSocial, int porcentajeCobertura)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.telefono = telefono;
            this.obraSocial = obraSocial;
            this.porcentajeCobertura = porcentajeCobertura;
            this.intervenciones = new List<Intervencion>();
        }
    }
}

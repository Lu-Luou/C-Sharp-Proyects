using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionSanatorio
{
    public class Doctor
    {
        public string nombre { get; set; }
        public string matricula { get; set; }
        public string especialidad { get; set; }
        public bool disponible { get; set; }

        public Doctor(string nombre, string matricula, string especialidad, bool disponible)
        {
            this.nombre = nombre;
            this.matricula = matricula;
            this.especialidad = especialidad;
            this.disponible = disponible;
        }
    }
}

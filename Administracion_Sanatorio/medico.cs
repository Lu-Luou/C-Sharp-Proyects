using System;

namespace Administracion_Sanatorio
{
    public class Medico
    {
        public string Nombre { get; set; } //copilot me genero esto y realmente no termino de entender para que sirve el encapsulamiento pero se que es para daler un formato a los datos
        public string Apellido { get; set; }
        public string MatriculaProfesional { get; set; }
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }
    }
}
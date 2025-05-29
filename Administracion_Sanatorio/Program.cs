using System;

namespace AdministracionSanatorio
{
    public class Program
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();
            hospital.Pacientes.Add(new Paciente("69696969", "Sigma Chad", "9696-7777", "GigaChads", 99));

            hospital.MostrarPacientes();

            hospital.AsignarIntervencion("69696969", "INT004");

            Console.WriteLine
            (
                "Costo total de las intervenciones del paciente con dni 69696969: "
                + hospital.CalcularCostoTotal("69696969")
            );
        }
    }
}

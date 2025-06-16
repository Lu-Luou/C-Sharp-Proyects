using System;

public class Cronometro
{
    public int Segundos { get; private set; }
    public int Minutos { get; private set; }

    public Cronometro()
    {
        Segundos = 0;
        Minutos = 0;
    }

    public void Reiniciar()
    {
        Segundos = 0;
        Minutos = 0;
    }

    public void IncrementarTiempo()
    {
        Segundos++;
        if (Segundos >= 60)
        {
            Minutos++;
            Segundos -= 60;
        }
    }

    public string MostrarTiempo()
    {
        return $"{Minutos} minutos, {Segundos} segundos";
    }
}

public class Program
{
    public static void Main()
    {
        Cronometro cronometro = new Cronometro();

        for (int i = 0; i < 5000; i++)
        {
            cronometro.IncrementarTiempo();
        }

        Console.WriteLine("Tiempo acumulado: " + cronometro.MostrarTiempo());

        cronometro.Reiniciar();
        Console.WriteLine("Tiempo después de reiniciar: " + cronometro.MostrarTiempo());
    }
}

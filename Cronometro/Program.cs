using System;

public class Cronometro
{
    private int _segundos;
    private int _minutos;

    public void Reiniciar()
    {
        _segundos = 0;
        _minutos = 0;
    }

    public void IncrementarTiempo()
    {
        _segundos++;
        if (_segundos >= 60)
        {
            _minutos++;
            _segundos -= 60;
        }
    }

    public string MostrarTiempo()
    {
        return $"{_minutos} minutos, {_segundos} segundos";
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
        Console.WriteLine(cronometro.MostrarTiempo());
    }
}
using System;

public interface IJugador
{
    bool Correr(int minutos);
    bool Cansado();
    void Descansar(int minutos);
}

public class Profesional : IJugador
{
    private int _minutosResistencia;
    private const int MaxResistencia = 40;

    public Profesional()
    {
        _minutosResistencia = MaxResistencia;
    }

    public bool Correr(int minutos)
    {
        if (minutos <= _minutosResistencia)
        {
            _minutosResistencia -= minutos;
            return true;
        }
        return false;
    }

    public bool Cansado()
    {
        return _minutosResistencia <= 0;
    }

    public void Descansar(int minutos)
    {
        _minutosResistencia += minutos;
        if (_minutosResistencia > MaxResistencia)
            _minutosResistencia = MaxResistencia;
    }
}

public class Amateur : IJugador
{
    private int _minutosResistencia;
    private const int MaxResistencia = 20;

    public Amateur()
    {
        _minutosResistencia = MaxResistencia;
    }

    public bool Correr(int minutos)
    {
        if (minutos <= _minutosResistencia)
        {
            _minutosResistencia -= minutos;
            return true;
        }
        return false;
    }

    public bool Cansado()
    {
        return _minutosResistencia <= 0;
    }

    public void Descansar(int minutos)
    {
        _minutosResistencia += minutos;
        if (_minutosResistencia > MaxResistencia)
            _minutosResistencia = MaxResistencia;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Prueba Jugador Profesional ===");
        IJugador profesional = new Profesional();
        TestJugador(profesional, 40);

        Console.WriteLine("\n=== Prueba Jugador Amateur ===");
        IJugador amateur = new Amateur();
        TestJugador(amateur, 20);
    }

    public static void TestJugador(IJugador jugador, int resistenciaMaxima)
    {
        Console.WriteLine($"Resistencia inicial: {resistenciaMaxima} minutos");
        
        Console.WriteLine($"\nIntentando correr {resistenciaMaxima - 10} minutos:");
        bool exito = jugador.Correr(resistenciaMaxima - 10);
        Console.WriteLine($"Puede completar: {exito}");
        Console.WriteLine($"¿Está cansado?: {jugador.Cansado()}");

        Console.WriteLine($"\nIntentando correr 15 minutos adicionales:");
        exito = jugador.Correr(15);
        Console.WriteLine($"Puede completar: {exito}");
        Console.WriteLine($"¿Está cansado?: {jugador.Cansado()}");

        Console.WriteLine("\nDescansando 30 minutos...\n");
        jugador.Descansar(30);
        Console.WriteLine($"Intenta correr 25 minutos:");
        exito = jugador.Correr(25);
        Console.WriteLine($"Puede completar: {exito}");
        Console.WriteLine($"¿Está cansado?: {jugador.Cansado()}");

        Console.WriteLine($"\nIntentando correr {resistenciaMaxima} minutos (maxima resistencia):");
        jugador.Descansar(resistenciaMaxima);
        exito = jugador.Correr(resistenciaMaxima);
        Console.WriteLine($"Puede completar: {exito}");
        Console.WriteLine($"¿Está cansado?: {jugador.Cansado()}");

        console.WriteLine("\n");
    }
}

using System;

public interface Jugador
{
    bool Correr(int minutos);
    bool Cansado();
    void Descansar(int minutos);
}

public class JugadorProfesional : Jugador
{
    private int minutosCorridos;
    private int minutosDescanso;
    private const int LimiteMinutosCorrer = 40;

    public bool Correr(int minutos)
    {
        if (Cansado())
            return false;

        minutosCorridos += minutos;
        return true;
    }

    public bool Cansado()
    {
        return minutosCorridos >= LimiteMinutosCorrer;
    }

    public void Descansar(int minutos)
    {
        minutosDescanso += minutos;
        minutosCorridos = Math.Max(0, minutosCorridos - minutos);
    }
}

public class JugadorAmateur : Jugador
{
    private int minutosCorridos;
    private int minutosDescanso;
    private const int LimiteMinutosCorrer = 20;

    public bool Correr(int minutos)
    {
        if (Cansado())
            return false;

        minutosCorridos += minutos;
        return true;
    }

    public bool Cansado()
    {
        return minutosCorridos >= LimiteMinutosCorrer;
    }

    public void Descansar(int minutos)
    {
        minutosDescanso += minutos;
        minutosCorridos = Math.Max(0, minutosCorridos - minutos);
    }
}
class Program
{
    public static void Main()
    {
        Console.WriteLine("===SIMULADOR DE JUGADORES CANSADOS===");

 
        Jugador profesional = new JugadorProfesional();
        Jugador amateur = new JugadorAmateur();

        Console.WriteLine("\n[Prueba Jugador Profesional]");
        Console.WriteLine($"- Puede correr 30 min? {profesional.Correr(30)}");
        Console.WriteLine($"  Estado cansado: {profesional.Cansado()}");
        Console.WriteLine($"- Puede correr 15 min? {profesional.Correr(15)}");
        Console.WriteLine($"  Estado cansado: {profesional.Cansado()}");
        Console.WriteLine("- Descansa 20 min");
        profesional.Descansar(20);
        Console.WriteLine($"  Estado cansado: {profesional.Cansado()}");
        Console.WriteLine($"- Puede correr 10 min? {profesional.Correr(10)}");
        Console.WriteLine($"  Estado cansado: {profesional.Cansado()}");

        Console.WriteLine("\n[Prueba Jugador Amateur]");
        Console.WriteLine($"- Puede correr 15 min? {amateur.Correr(15)}");
        Console.WriteLine($"  Estado cansado: {amateur.Cansado()}");
        Console.WriteLine($"- Puede correr 10 min? {amateur.Correr(10)}");
        Console.WriteLine($"  Estado cansado: {amateur.Cansado()}");
        Console.WriteLine("- Descansa 5 min");
        amateur.Descansar(5);
        Console.WriteLine($"  Estado cansado: {amateur.Cansado()}");
        Console.WriteLine($"- Puede correr 10 min? {amateur.Correr(10)}");
        Console.WriteLine($"  Estado cansado: {amateur.Cansado()}");
    }
}
using System;

public interface Vehiculo
{
    void Mover(int segundos);
    int Posicion();
    void ReiniciarPosicion();
}

public class Bicicleta : Vehiculo
{
    private int distancia = 0;
    private const int Velocidad = 10;

    public void Mover(int segundos)
    {
        distancia += segundos * Velocidad;
    }

    public int Posicion()
    {
        return distancia;
    }

    public void ReiniciarPosicion()
    {
        distancia = 0;
    }
}

public class Auto : Vehiculo
{
    private int distancia = 0;
    private int velocidad;

    public Auto(int velocidad = 40) 
    {
        this.velocidad = velocidad;
    }

    public void Mover(int segundos)
    {
        distancia += segundos * velocidad;
    }

    public int Posicion()
    {
        return distancia;
    }

    public void ReiniciarPosicion()
    {
        distancia = 0;
    }
}

public class Camion : Vehiculo
{
    private int distancia = 0;
    private const int Velocidad = 30;

    public void Mover(int segundos)
    {
        distancia += segundos * Velocidad;
    }

    public int Posicion()
    {
        return distancia;
    }

    public void ReiniciarPosicion()
    {
        distancia = 0;
    }
}

public class Carrera
{
    private Vehiculo vehiculo1;
    private Vehiculo vehiculo2;
    private int duracion;

    public Carrera(Vehiculo v1, Vehiculo v2, int segundos)
    {
        vehiculo1 = v1;
        vehiculo2 = v2;
        duracion = segundos;
    }

    public void Comenzar()
    {
 
        vehiculo1.ReiniciarPosicion();
        vehiculo2.ReiniciarPosicion();

        vehiculo1.Mover(duracion);
        vehiculo2.Mover(duracion);

        Console.WriteLine("\nResultados de la carrera:");
        Console.WriteLine($"Vehículo 1 recorrió: {vehiculo1.Posicion()} metros");
        Console.WriteLine($"Vehículo 2 recorrió: {vehiculo2.Posicion()} metros");

        // Determinamos ganador
        if (vehiculo1.Posicion() > vehiculo2.Posicion())
            Console.WriteLine("Vehículo 1 gana la carrera");
        else if (vehiculo2.Posicion() > vehiculo1.Posicion())
            Console.WriteLine("Vehículo 2 gana la carrera");
        else
            Console.WriteLine("Empate");
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Sistema de Vehículos");

        // Crear vehículos
        Auto auto = new Auto(45);
        Bicicleta bici = new Bicicleta();
        Camion camion = new Camion();

        // Probar bicicleta
        bici.Mover(20);
        Console.WriteLine($"Bicicleta después de 20 segundos: {bici.Posicion()} metros");
        bici.Mover(10);
        Console.WriteLine($"Bicicleta después de otros 10 segundos: {bici.Posicion()} metros");
        bici.ReiniciarPosicion();
        Console.WriteLine($"Bicicleta reiniciada: {bici.Posicion()} metros");

        // Hacer carreras
        Carrera carrera1 = new Carrera(auto, bici, 60);
        carrera1.Comenzar();

        Carrera carrera2 = new Carrera(camion, bici, 30);
        carrera2.Comenzar();
    }
}
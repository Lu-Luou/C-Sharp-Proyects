using System;

public interface Vehiculo
{
    void mover(int tiempo);

    void reiniciarPosicion();

    int mostrarPosicion();
}

public class Bicicleta : Vehiculo
{
    public int posicion = 0;

    public void mover(int tiempo)
    {
        posicion += tiempo * 10;
    }

    public void reiniciarPosicion()
    {
        posicion = 0;
    }

    public int mostrarPosicion()
    {
        return posicion;
    }
}

public class Auto : Vehiculo
{
    public int posicion = 0;
    public int velocidad;

    public Auto(int velocidad = 40)
    {
        this.velocidad = velocidad;
    }

    public void mover(int tiempo)
    {
        posicion += tiempo * velocidad;
    }

    public void reiniciarPosicion()
    {
        posicion = 0;
    }

    public int mostrarPosicion()
    {
        return posicion;
    }
}

public class Camion : Vehiculo
{
    public int posicion = 0;

    public void mover(int tiempo)
    {
        posicion += tiempo * 30;
    }

    public void reiniciarPosicion()
    {
        posicion = 0;
    }

    public int mostrarPosicion()
    {
        return posicion;
    }
}

public class Carrera
{
    public int tiempo;
    public Vehiculo[] vehiculos = new Vehiculo[2];

    public Carrera(Vehiculo Vehiculo1, Vehiculo Vehiculo2, int tiempo = 0)
    {
        this.vehiculos[0] = Vehiculo1;
        this.vehiculos[1] = Vehiculo2;
        this.tiempo = tiempo;
    }

    public void iniciarCarrera()
    {
        Console.WriteLine("\nLa carrera ha comenzado.\n");

        vehiculos[0].mover(tiempo);
        vehiculos[1].mover(tiempo);

        Console.WriteLine("La carrera ha terminado.\n");
        Console.WriteLine("Posición del vehículo 1: " + vehiculos[0].mostrarPosicion() + " metros.\n");
        Console.WriteLine("Posición del vehículo 2: " + vehiculos[1].mostrarPosicion() + " metros.\n");
    }
}

public class Program
{
    public static void Main()
    {
        Auto fiat = new Auto(45);
        Bicicleta bici = new Bicicleta();
        Camion camion = new Camion();
        Carrera test = new Carrera(fiat, bici, 100);

        bici.mover(20);
        Console.WriteLine(bici.mostrarPosicion());
        bici.mover(10);
        Console.WriteLine(bici.mostrarPosicion());

        test.iniciarCarrera(); // Bici recorre 300 + 1000 en total
    }
}
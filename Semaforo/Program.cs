using System;

public class Semaforo
{
    public string colorActual;
    public int segundosTranscurridos;
    public bool intermitente;
    public bool amarilloIntermitente;
    public int tiempoIntermitente;
    
    public readonly (string Color, int Duracion)[] secuencia = new[]
    {
        ("Rojo", 30),
        ("Rojo - Amarillo", 2),
        ("Verde", 20),
        ("Amarillo", 2)
    };
    
    public int indiceSecuencia;
    
    public Semaforo(string colorInicial = "Rojo")
    {
        if (colorInicial != "Rojo" && colorInicial != "Verde" && colorInicial != "Amarillo")
        {
            throw new ArgumentException("Color inicial no válido. Debe ser Rojo, Verde o Amarillo.");
        }
        
        if (colorInicial == "Rojo")
        {
            indiceSecuencia = 0;
        }
        else if (colorInicial == "Verde")
        {
            indiceSecuencia = 2;
        }
        else if (colorInicial == "Amarillo")
        {
            indiceSecuencia = 3;
        }
        
        colorActual = secuencia[indiceSecuencia].Color;
        segundosTranscurridos = 0;
        intermitente = false;
        amarilloIntermitente = false;
        tiempoIntermitente = 0;
    }
    
    public void PasoDelTiempo(int segundos)
    {
        if (intermitente)
        {
            tiempoIntermitente += segundos;
            
            while (tiempoIntermitente >= 1)
            {
                amarilloIntermitente = !amarilloIntermitente;
                tiempoIntermitente--;
            }
        }
        else
        {
            segundosTranscurridos += segundos;
            
            while (segundosTranscurridos >= secuencia[indiceSecuencia].Duracion)
            {
                segundosTranscurridos -= secuencia[indiceSecuencia].Duracion;
                indiceSecuencia = (indiceSecuencia + 1) % secuencia.Length;
                colorActual = secuencia[indiceSecuencia].Color;
            }
        }
    }
    
    public string MostrarColor()
    {
        if (intermitente)
        {
            return amarilloIntermitente ? "Amarillo" : "Apagado";
        }
        return colorActual;
    }
    
    public void PonerEnIntermitente()
    {
        intermitente = true;
        amarilloIntermitente = false;
        tiempoIntermitente = 0;
    }
    
    public void SacarDeIntermitente()
    {
        intermitente = false;
    }
}

public class Program
{
    public static void Main()
    {
        Semaforo semaforo = new Semaforo("Amarillo");
        
        Console.WriteLine($"Color inicial: {semaforo.MostrarColor()}");
        
        for (int i = 1; i < 50; i += 5)
        {
            semaforo.PasoDelTiempo(i);
            Console.WriteLine($"Segundo {i}: {semaforo.MostrarColor()}");
        }
        
        semaforo.PonerEnIntermitente();
        Console.WriteLine("\nModo intermitente:");
        for (int i = 0; i < 5; i++)
        {
            semaforo.PasoDelTiempo(1);
            Console.WriteLine($"Segundo {i+1}: {semaforo.MostrarColor()}");
        }

        semaforo.SacarDeIntermitente();
        Console.WriteLine($"\nFuera de intermitente: {semaforo.MostrarColor()}");
    }
}
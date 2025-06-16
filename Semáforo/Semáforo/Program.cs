using System;


class Semaforo
{
    public string colorActual;
    public int tiempoActual;
    public bool enIntermitente;

 
    public Semaforo(string colorInicial)
    {
        colorActual = colorInicial;
        tiempoActual = 0;
        enIntermitente = false;
    }

    public void PasoDelTiempo(int segundos)
    {
      
        if (enIntermitente)
        {
            colorActual = (colorActual == "Amarillo") ? "Apagado" : "Amarillo";
            tiempoActual = 1; 
        }
        else
        {
            tiempoActual += segundos;
            CambiarColor();
        }
    }

  
    public void CambiarColor()
    {
        switch (colorActual)
        {
            case "Rojo":
                if (tiempoActual >= 30)
                {
                    colorActual = "Rojo-Amarillo";
                    tiempoActual = 30;
                }
                break;

            case "Rojo-Amarillo":
                if (tiempoActual >= 2)
                {
                    colorActual = "Verde";
                    tiempoActual = 2;
                }
                break;

            case "Verde":
                if (tiempoActual >= 20)
                {
                    colorActual = "Amarillo";
                    tiempoActual = 20;
                }
                break;

            case "Amarillo":
                if (tiempoActual >= 2)
                {
                    colorActual = "Rojo";
                    tiempoActual = 2;
                }
                break;
        }
    }

    
    public void MostrarColor()
    {
        Console.WriteLine("El tiempo que transcurrio en ese color es de:" + tiempoActual + " segundos");
        Console.WriteLine($"El color actual del semáforo es: {colorActual}");
        
    }

    
    public void PonerEnIntermitente()
    {
        enIntermitente = true;
        colorActual = "Amarillo";
        tiempoActual = 0;
    }

    public void SacarDelIntermitente()
    {
        enIntermitente = false;
        tiempoActual = 0;
    }
}

class Program
{
   public static void Main()
    {

        Semaforo semaforo = new Semaforo("Rojo");

 
        semaforo.MostrarColor();
        semaforo.PasoDelTiempo(30);
        semaforo.MostrarColor();
        semaforo.PasoDelTiempo(2);
        semaforo.MostrarColor();
        semaforo.PasoDelTiempo(20);
        semaforo.MostrarColor();
        semaforo.PasoDelTiempo(2);
        semaforo.MostrarColor();

        Console.WriteLine("Modo intermitente activado");
        semaforo.PonerEnIntermitente();
        for (int i = 0; i < 5; i++)
        {
            semaforo.PasoDelTiempo(1);
            semaforo.MostrarColor();
        }

       
        Console.WriteLine("Modo intermitente desactivado");
        semaforo.SacarDelIntermitente();
        semaforo.MostrarColor();
    }
}


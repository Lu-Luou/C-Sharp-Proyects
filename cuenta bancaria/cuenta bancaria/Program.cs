using System;
using System.Collections.Generic;

public class CuentaBancaria
{

    private string numeroCuenta;
    private int saldo;
    private string titular;

    public CuentaBancaria(string numero, string nombreTitular, int saldoInicial = 0)
    {
        numeroCuenta = numero;
        titular = nombreTitular;
        saldo = saldoInicial;
    }

  
    public int ObtenerSaldo()
    {
        return saldo;
    }

    public void ModificarSaldo(int nuevoSaldo)
    {
        saldo = nuevoSaldo;
    }

   
    public string NumeroCuenta { get { return numeroCuenta; } }
    public string Titular { get { return titular; } }
}

public class Banco
{
 
    private Dictionary<string, CuentaBancaria> cuentas = new Dictionary<string, CuentaBancaria>();

  
    public void AgregarCuenta(CuentaBancaria cuenta)
    {
        cuentas[cuenta.NumeroCuenta] = cuenta;
    }


    public bool Depositar(string numeroCuenta, int monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("Error: El monto debe ser mayor a cero");
            return false;
        }

        if (cuentas.ContainsKey(numeroCuenta))
        {
            CuentaBancaria cuenta = cuentas[numeroCuenta];
            cuenta.ModificarSaldo(cuenta.ObtenerSaldo() + monto);
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: {cuenta.ObtenerSaldo()}");
            return true;
        }
        else
        {
            Console.WriteLine("Error: Cuenta no encontrada");
            return false;
        }
    }

  
    public bool Extraer(string numeroCuenta, int monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("Error: El monto debe ser mayor a cero");
            return false;
        }

        if (cuentas.ContainsKey(numeroCuenta))
        {
            CuentaBancaria cuenta = cuentas[numeroCuenta];

            if (cuenta.ObtenerSaldo() >= monto)
            {
                cuenta.ModificarSaldo(cuenta.ObtenerSaldo() - monto);
                Console.WriteLine($"Extracción exitosa. Nuevo saldo: {cuenta.ObtenerSaldo()}");
                return true;
            }
            else
            {
                Console.WriteLine("Error: Fondos insuficientes");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Error: Cuenta no encontrada");
            return false;
        }
    }

    
    public bool Transferencia(string cuentaOrigen, int monto, string cuentaDestino)
    {
       
        if (monto <= 0)
        {
            Console.WriteLine("Error: El monto debe ser mayor a cero");
            return false;
        }

        
        if (!cuentas.ContainsKey(cuentaOrigen) || !cuentas.ContainsKey(cuentaDestino))
        {
            Console.WriteLine("Error: Una o ambas cuentas no existen");
            return false;
        }

        CuentaBancaria origen = cuentas[cuentaOrigen];
        CuentaBancaria destino = cuentas[cuentaDestino];

       
        if (origen.ObtenerSaldo() < monto)
        {
            Console.WriteLine("Error: Fondos insuficientes en la cuenta origen");
            return false;
        }

    
        origen.ModificarSaldo(origen.ObtenerSaldo() - monto);
        destino.ModificarSaldo(destino.ObtenerSaldo() + monto);

        Console.WriteLine($"Transferencia exitosa de {monto} de {cuentaOrigen} a {cuentaDestino}");
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sistema Bancario Básico");

        // Crear banco
        Banco banco = new Banco();

        // Crear cuentas
        CuentaBancaria cuenta1 = new CuentaBancaria("001", "Juan Pérez", 1000);
        CuentaBancaria cuenta2 = new CuentaBancaria("002", "María Gómez", 500);
        CuentaBancaria cuenta3 = new CuentaBancaria("003", "Carlos López");

        // Agregar cuentas al banco
        banco.AgregarCuenta(cuenta1);
        banco.AgregarCuenta(cuenta2);
        banco.AgregarCuenta(cuenta3);

        // Realizar operaciones
        Console.WriteLine("\nOperaciones de depósito:");
        banco.Depositar("001", 300);
        banco.Depositar("004", 100);
        banco.Depositar("002", -50);
        Console.WriteLine("\nOperaciones de extracción:");
        banco.Extraer("002", 200);
        banco.Extraer("002", 400);
        banco.Extraer("005", 100);

        Console.WriteLine("\nOperaciones de transferencia:");
        banco.Transferencia("001", 150, "003");
        banco.Transferencia("002", 500, "001");
        banco.Transferencia("001", 100, "006"); 


        Console.WriteLine("\nSaldos finales:");
        Console.WriteLine($"Cuenta 001: {cuenta1.ObtenerSaldo()}");
        Console.WriteLine($"Cuenta 002: {cuenta2.ObtenerSaldo()}");
        Console.WriteLine($"Cuenta 003: {cuenta3.ObtenerSaldo()}");
    }
}
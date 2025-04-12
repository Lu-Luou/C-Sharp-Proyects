using System;

public class CuentaBancaria
{
    private string numero_cuenta;
    private int saldo;
    private string titular;

    public CuentaBancaria(string numero_cuenta, string titular, int saldo = 0)
    {
        this.numero_cuenta = numero_cuenta;
        this.saldo = saldo;
        this.titular = titular;
    }

    public int obtener_saldo()
    {
        return saldo;
    }

    public void modificar_saldo(int cantidad)
    {
        if(cantidad < 0 && saldo + cantidad >= 0)
        {
            saldo += cantidad;
        }
        else if(cantidad > 0)
        {
            saldo += cantidad;
        }
        else
        {
            Console.WriteLine("No se puede modificar el saldo a un valor negativo.");
        }
    }
}

public class Banco
{
    public void depositar(CuentaBancaria cuenta, int cantidad)
    {
        if(cantidad > 0)
        {
            cuenta.modificar_saldo(cantidad);
        }
        else
        {
            Console.WriteLine("No se puede depositar una cantidad negativa.");
        }
    }

    public void retirar(CuentaBancaria cuenta, int cantidad)
    {
        if(cantidad > 0 && cuenta.obtener_saldo() >= cantidad)
        {
            cuenta.modificar_saldo(-cantidad);
        }
        else
        {
            Console.WriteLine("No se puede retirar una cantidad negativa o mayor al saldo.");
        }
    }

    public bool transferencia(CuentaBancaria cuenta_origen, CuentaBancaria cuenta_destino, int cantidad)
    {
        if(cantidad > 0 && cuenta_origen.obtener_saldo() >= cantidad)
        {
            cuenta_origen.modificar_saldo(-cantidad);
            cuenta_destino.modificar_saldo(cantidad);
            return true;
        }
        else
        {
            Console.WriteLine("No se puede transferir una cantidad negativa o mayor al saldo.");
            return false;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CuentaBancaria cuenta1 = new CuentaBancaria("000001", "Juan Perez", 1000);
        CuentaBancaria cuenta2 = new CuentaBancaria("000002", "Maria Lopez", 500);

        Banco banco = new Banco();

        banco.depositar(cuenta1, 200);
        Console.WriteLine("Saldo cuenta 1: " + cuenta1.obtener_saldo());

        banco.retirar(cuenta1, 300);
        Console.WriteLine("Saldo cuenta 1: " + cuenta1.obtener_saldo());

        banco.transferencia(cuenta1, cuenta2, 400);
        Console.WriteLine("Saldo cuenta 1: " + cuenta1.obtener_saldo());
        Console.WriteLine("Saldo cuenta 2: " + cuenta2.obtener_saldo());
        banco.transferencia(cuenta1, cuenta2, 2000); // Intento de transferencia mayor al saldo
        Console.WriteLine("Saldo cuenta 2: " + cuenta2.obtener_saldo());
    }
}
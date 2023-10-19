using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Principal
    {
        BasedeDatos basedeDatos = new BasedeDatos();

        public void AgregarCliente(Cliente cliente)
        {
            basedeDatos.Clientes.Add(cliente);
            basedeDatos.SaveChanges();

        }

        public void AgregarCuentaBancaria(string tipo, int idcliente)
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria();

            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);


            if (clienteEncontrado != null)
            {

                cuentaBancaria.saldo = 0;
                cuentaBancaria.tipoCuenta = tipo;
                cuentaBancaria.clienteCuentaBancaria = clienteEncontrado;
                var numeroCuenta = (clienteEncontrado.dni).ToString();

                if (tipo == "CC")
                {
                    numeroCuenta = numeroCuenta + "111";
                }
                else
                {
                    numeroCuenta = numeroCuenta + "222";

                }
                cuentaBancaria.numeroCuenta = long.Parse(numeroCuenta);

                basedeDatos.CuentasBancaria.Add(cuentaBancaria);
                basedeDatos.SaveChanges();


            }
        }
        public void EmitirTarjetaCredito(int idcliente)
        {
            TarjetaCredito tarjetasCredito = new TarjetaCredito();
            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);

            if (clienteEncontrado != null)
            {
                tarjetasCredito.limiteCredito = 400000;
                tarjetasCredito.saldoDisponible = 400000;
                tarjetasCredito.montoDeuda = (tarjetasCredito.limiteCredito - tarjetasCredito.saldoDisponible);
                tarjetasCredito.estado = "ACTIVA";
                var numeroTarjeta = (clienteEncontrado.dni).ToString() + "333";

                basedeDatos.TarjetasCredito.Add(tarjetasCredito);
                basedeDatos.SaveChanges();
            }


        }

        public void PausarTarjetaCredito(string numeroTarjeta, int idcliente, double monmontoDeuda, string estado)
        {
            TarjetaCredito tarjetasCredito = new TarjetaCredito();
            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);


            if (clienteEncontrado != null)
            {

                tarjetasCredito.numeroTarjeta = numeroTarjeta;
                tarjetasCredito.montoDeuda = monmontoDeuda;
                tarjetasCredito.estado = estado;

                if (numeroTarjeta != null + (tarjetasCredito.montoDeuda >= 400000) + (estado = "ACTIVA"))
                {
                    estado = "PAUSADA";
                }
                basedeDatos.TarjetasCredito.Add(tarjetasCredito);
                basedeDatos.SaveChanges();
            }

        }
        public void RegistrarDeposito(double saldo, int idcliente)
        {
            CuentaBancaria ctaBancaria = new CuentaBancaria();
            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);

            if (clienteEncontrado != null)
            {
                Console.WriteLine("¿Desea realizar un depósito? (si/no)");
                string respuesta = Console.ReadLine();


                if (respuesta.ToLower() == "si")
                {

                    Console.WriteLine("Ingrese el monto a depositar:");
                    double monto = Convert.ToDouble(Console.ReadLine());
                    ctaBancaria.saldo = saldo + monto;

                }
                else
                {
                    Console.WriteLine("No se realizará ningún depósito.");
                }
                basedeDatos.CuentasBancaria.Add(ctaBancaria);
                basedeDatos.SaveChanges();
            }
        }

        public void RealizarExtraccion(double saldo, int idcliente)
        {
            CuentaBancaria cttaBancaria = new CuentaBancaria();
            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);

            if (clienteEncontrado != null)
            {
                Console.WriteLine("¿Desea realizar una extracción? (si/no)");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "si")
                {

                    Console.WriteLine("Ingrese el monto a extraer:");
                    double monto = Convert.ToDouble(Console.ReadLine());
                    cttaBancaria.saldo = saldo - monto;

                }
                else
                {
                    Console.WriteLine("No se realizará ningún depósito.");
                }
                basedeDatos.CuentasBancaria.Add(cttaBancaria);
                basedeDatos.SaveChanges();
            }

        }
        public void RealizarTransferencia(double saldo, int idcliente)
        {
            CuentaBancaria cBancaria = new CuentaBancaria();
            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);

            if (clienteEncontrado != null)
            {
                Console.WriteLine("¿Desea realizar una transferencia? (si/no)");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "si")
                {

                    Console.WriteLine("Ingrese el monto a transferir:");
                    double monto = Convert.ToDouble(Console.ReadLine());
                    cBancaria.saldo = saldo - monto;

                }
                else
                {
                    Console.WriteLine("No se realizará ningún transferencia.");
                }
                basedeDatos.CuentasBancaria.Add(cBancaria);
                basedeDatos.SaveChanges();





















            }
        }
    }
}

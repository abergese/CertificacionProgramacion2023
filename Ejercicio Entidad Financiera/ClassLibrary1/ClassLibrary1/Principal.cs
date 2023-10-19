using System;
using System.Collections.Generic;
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
        public void EmitirTarjetaCredito( int idcliente)
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

            }

        }

        public void PausarTarjetaCredito(string numeroTarjeta , int idcliente , double monmontoDeuda, string estado)
        {
            TarjetaCredito tarjetasCredito = new TarjetaCredito();
            var clienteEncontrado = basedeDatos.Clientes.Find(idcliente);
            

            if (clienteEncontrado != null )
            {

                tarjetasCredito.numeroTarjeta = numeroTarjeta;
                tarjetasCredito.montoDeuda = monmontoDeuda;
                tarjetasCredito.estado = estado;

                if (numeroTarjeta != null + (tarjetasCredito.montoDeuda >= 400000) + (estado = "ACTIVA"))
                {
                    estado = "PAUSADA";
                }

            }

        }



















    }

}
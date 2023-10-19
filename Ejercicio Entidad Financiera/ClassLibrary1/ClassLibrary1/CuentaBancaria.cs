using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class CuentaBancaria
    {
        public int id { get; set; }
        public long numeroCuenta { get; set; }
        public double saldo { get; set; }

        public string tipoCuenta { get; set; }

        public Cliente clienteCuentaBancaria { get; set; }
    }
}

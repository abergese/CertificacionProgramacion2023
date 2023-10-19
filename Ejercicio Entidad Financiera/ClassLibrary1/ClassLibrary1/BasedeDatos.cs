using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace Backend
{
    public class BasedeDatos : DbContext    
    {
        public DbSet <Cliente> Clientes { get; set; }
        public DbSet <CuentaBancaria> CuentasBancaria { get; set; }

        public DbSet <TarjetaCredito> TarjetasCredito { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer("server=.;database=EntidadFinanciera;trusted_connection=true;Encrypt=False");

        }

    }
}

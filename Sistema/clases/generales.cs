using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    class CLIENTE
    {
        private string Nombre;
        private string Direccion;
        private string Telefono;
        private string Gerente;

        public CLIENTE(string Nombre, string Direccion, string Telefono, string Gerente)
        {
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Gerente = Gerente;
        }

        public CLIENTE(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public CLIENTE()
        {

        }

        public string GRABAR()
        {
            return (" insert into CLIENTE values ('" + this.Nombre + "','" + this.Direccion + "','" + this.Telefono + "','" + this.Gerente + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  CLIENTE WHERE Nombre = '" + this.Nombre + "'" );
        }
        public string modificar()
        {
            return (" update CLIENTE set  direccion ='" + this.Direccion + "', Telefono ='" + this.Telefono + "', Gerente ='" + this.Gerente + "' WHERE Nombre = '" + this.Nombre + "'" );
        }
        public string consultageneral()
        {
            return (" SELECT Nombre as Nombre , Direccion as Direccion, Telefono as Telefono, Gerente as Gerente FROM  CLIENTE");
        }
        /*public string consecutivo()
        {
            return ("select count(*) as folio from generales");
        }*/
    }
}

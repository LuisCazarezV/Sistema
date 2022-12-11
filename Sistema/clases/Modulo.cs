using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    class Modulo
    {
        private byte ID;
        private string NOMBRE;

        public Modulo (byte ID, String NOMBRE)
        {
            this.ID = ID;
            this.NOMBRE = NOMBRE;
        }

        public Modulo(byte ID)
        {
            this.ID = ID;
        }

        public Modulo()
        {

        }

        public string GRABAR()
        {
            return (" insert into Modulo values ('" + this.ID + "','" + this.NOMBRE + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  Modulo WHERE ID= '" + this.ID + "'");
        }
        public string modificar()
        {
            return (" update Modulo set  NOMBRE ='" + this.NOMBRE + "' WHERE ID = '" + this.ID + "'");
        }
        public string consultageneral()
        {
            return (" SELECT ID as ID , NOMBRE as NOMBRE FROM  Modulo");
        }
        public string consecutivo()
        {
            return ("select count(*) + 1 as folio from Modulo");
        }

    }
}

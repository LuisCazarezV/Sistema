using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    class ClRoles
    {
        private byte id;
        private string nombre;


        //metodo costructor para grabar y editar
        public ClRoles(byte id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        //metodo constructor consultar
        public ClRoles(byte id)
        {
            this.id = id;
        }

        public ClRoles()
        {

        }

        public string GRABAR()
        {
            return (" insert into IDRol values ('" + this.id + "','" + this.nombre + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  ROL WHERE IDRol= '" + this.id + "'");
        }
        public string modificar()
        {
            return (" update IDRol set  Nombre ='" + this.nombre + "' WHERE IDRol = '" + this.id + "'");
        }
        public string consultageneral()
        {
            return (" SELECT Id as clave , Nombre as Nombre FROM  IDRol");
        }
        public string consecutivo()
        {
            return ("select count(*) + 1 as folio from IDRol");
        }
    }
}

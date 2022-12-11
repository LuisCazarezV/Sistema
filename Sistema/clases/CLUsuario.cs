using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    class CLUsuario
    {
        private int id_usuario;
        private string Nombre;
        private string Contraseña;
        private byte Rol;

        public CLUsuario(int id_usuario, string Nombre, string Contraseña, byte Rol)
        {
            this.id_usuario = id_usuario;
            this.Nombre = Nombre;
            this.Contraseña = Contraseña;
            this.Rol = Rol;        
        }

        public CLUsuario(int id_usuario)
        {
            this.id_usuario = id_usuario;
        }

        public CLUsuario()
        {
            
        }

        public string GRABAR()
        {
            return (" insert into Usuario values ('" + this.id_usuario + "','" + this.Nombre + "','" + this.Contraseña + "','" + this.Rol + "')");
        }

        public string CONSULTARI()
        {
            return (" SELECT * FROM  Usuario WHERE IdUsuario= '" + this.id_usuario + "'");
        }


        public string modificar()
        {
            return (" update Usuario set  IdUsuario ='" + this.id_usuario + "', Nombre ='" + this.Nombre + "', Contraseña ='" + this.Contraseña + "', Rol ='" + this.Rol +  "'");
        }


        public string consultageneral()
        {
            return (" SELECT id_usuario as IdUsuario , Nombre as Nombre, Contraseña as Contraseña , Rol as Rol FROM  Usuario");
        }

        public string consecutivo()
        {
            return ("select count(*) + 1 as folio from Usuario");
        }
    }
}

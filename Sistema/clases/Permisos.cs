using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    class Permisos
    {
        private byte id;
        private byte id_rol;
        private byte id_modulo;
        private bool consultar;
        private bool grabar;
        private bool eliminar;
        private bool actualizar;
        //private bool buscar;      

        public Permisos(byte id, byte id_rol, byte id_modulo, bool consultar, bool grabar, bool eliminar, bool actualizar)
        {
            this.id = id;
            this.id_rol = id_rol;
            this.id_modulo = id_modulo;
            this.consultar = consultar;
            this.grabar = grabar;
            this.eliminar = eliminar;
            this.actualizar = actualizar;
        ;
        }

        public Permisos(byte id, byte id_rol, byte id_modulo)
        {
            this.id = id;
            this.id_rol = id_rol;
            this.id_modulo = id_modulo;
        }

        public Permisos()
        {
           
        }

        public string GRABAR()
        {
            return (" insert into Permisos values ('" + this.id_rol + "','" + this.id_modulo + "','" + this.consultar + "','" + this.grabar + "','" + this.eliminar + "','" + this.actualizar + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  Permisos WHERE Id= '" + this.id + "'");
        }


        public string modificar()
        {
            return (" update Permisos set  id_rol ='" + this.id_rol + "', id_modulo ='" + this.id_modulo + "', consultar ='" + this.consultar + "', grabar ='" + this.grabar + "', eliminar ='" + this.eliminar + "', actualizar ='" + this.actualizar + "' WHERE id = '" + this.id + "'");
        }


        public string consultageneral()
        {
            return (" SELECT id as id , id_rol as id_rol, id_modulo as id_modulo , consulta as consulta , grabar as grabar, eliminar as eliminar , actualizar as actualizar FROM  Permisos");
        }
        public string consecutivo()
        {
            return ("select count(*) + 1 as folio from Permisos");
        }
    }
}

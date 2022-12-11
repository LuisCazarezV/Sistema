using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    internal class CLUSUARIOS
    {
        private string USU_LOGIN;
        private string USU_PASS;
        //public string USU_NOMBRE;

        public CLUSUARIOS(string uSU_LOGIN, string uSU_PASS)
        {
            USU_LOGIN = uSU_LOGIN;
            USU_PASS = uSU_PASS;
           // USU_NOMBRE = uSU_NOMBRE;
        }

      /* public CLUSUARIOS(System.String USU_LOGIN, System.String USU_PASS)
        {
            this.USU_LOGIN
        }*/

        public string CONSULTARI()
        {
            return ("SELECT Nombre, Contraseña FROM Usuario WHERE Nombre = '" + this.USU_LOGIN + "' and Contraseña = dbo.MD5('" + this.USU_PASS + "')");
            //return ("SELECT * FROM TBLUSUARIOS WHERE USU_LOGIN= '" + this.USU_LOGIN + "'and USU_PASS = dbo.MDS('" + this.USU_PASS + "')");
        }
    }
}

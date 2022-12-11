using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    public static class globales
    {

        static public string dbn = "Program";
        static public string server = "LUISCAZAREZ";
        static public string password = "91870577";
        static public string seguridad = "Integrated Security=True";
        static public string userID = "sa";

        static public string miconexion = @"Data Source = " + server + "; Initial Catalog = " + dbn + "; Persist Security info = True; User ID = sa; Password = " + password;

        static public byte nivel = 0;
        static public bool nive = false;
        static public string lusuario = "";
        static public string lnombre = "";
        static public string lpuesto = "";




        /*  //cambio para probar
          static public string dbn = "Program";
          //static public string server =
          static public string server = "LUISCAZAREZ";
          static public string password = "91870577";
          //static public string server =
          //static public string password =
          static public string seguridad = "integrated security=true";
          //static public string User OD=
          static public string UserID = "sa";

          static public string miconexion = @"Data Source" + server + "; Initital Catalog =" + dbn + "; Persist Security Info = true;User ID = SA; Password =" + password;

          //statilc public UserID = "sa"
          static public byte nivel = 0; //agregado el 30/09/2022
          static public bool nive = false;//agregado el 30/09/2022
          static public string lusuario = "";//agregado el 30/09/2022
          static public string lnombre = "";//agregado el 30/09/2022
          static public string lpuesto = "";//agregado el 30/09/2022*/



    }
}

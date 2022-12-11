using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//clase que sirve para conectar a la BD

namespace Sistema.clases
{
    internal class Conexion
    {
        private string sentencial;

        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;
        
        // se pone como nombre como se llama la clase "conexion se llama conexion le vas a poner"
        public Conexion()
        {
        }
        public Conexion(string sentacia)
        {
            this.sentencial = sentacia;
        }
        //este metodo sirve para guardar, eliminar y modificar

        public string ejecutar()
        {
            conn.ConnectionString = clases.globales.miconexion;
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sentencial;
            cmd.ExecuteNonQuery();
            conn.Close();
            return "Operación exitosa";
        }

        public DataSet consultar()
        {
           
             DataSet datos = new DataSet();

             conn = new SqlConnection(clases.globales.miconexion);
             if (conn.State != System.Data.ConnectionState.Open)
             {
                 conn.Close(); conn.Open();
             }
             SqlDataAdapter resp = new SqlDataAdapter(sentencial, conn);
             resp.Fill(datos, "Tabla");
             conn.Close();
             return datos;
        }

        private string mFieldValue;
        internal string FieldValue
        {
            get { return mFieldValue; }
        }
        internal bool Execute(string SQL, int ColumnNumberToRetrive)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(SQL, clases.globales.miconexion);
            da.Fill(ds, "Table");

           formularios.SearchForm frmSearchForm = new formularios.SearchForm();
            frmSearchForm.mColNumber = ColumnNumberToRetrive;
            frmSearchForm.mDS = ds;
            ds = null;
            frmSearchForm.ShowDialog();
            if (frmSearchForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                mFieldValue = frmSearchForm.ReturnValue;
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}

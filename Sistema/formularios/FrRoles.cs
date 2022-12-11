using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Globalization;

namespace Sistema.formularios
{
    public partial class FrRoles : Form
    {
        public FrRoles()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            busca();
        }

        clases.ClRoles G;
        private void busca()
        {
            try
            {
                G = new clases.ClRoles();
                clases.Conexion con = new clases.Conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        TXTCLAVE.Text = con.FieldValue;
                        consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        clases.Conexion c;
        clases.ClRoles B;
        private void consultar()
        {
            if (!(TXTCLAVE.Text == ""))
            {
                try
                {
                    B = new clases.ClRoles(byte.Parse(TXTCLAVE.Text));
                    DataSet ds = new DataSet();
                    c = new clases.Conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        TXTCLAVE.Text = ds.Tables["Tabla"].Rows[0]["Id"].ToString();
                        TXTNOMBREROL.Text = ds.Tables["Tabla"].Rows[0]["Nombre"].ToString();
                        /* TXTCHO_NOMBRE.Text = ds.Tables["Tabla"].Rows[0]["cho_NOMBRE"].ToString();
                         TXTCHO_PLACAS.Text = ds.Tables["Tabla"].Rows[0]["CHO_PLACAS"].ToString();
                         TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                         TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                         TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();
                         // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);*/

                    }
                    else

                    MessageBox.Show("No Existe este dato");
                    TXTNOMBREROL.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        private void FrRoles_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }
        void cargarfolio()
        {
            B = new clases.ClRoles();
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                 TXTCLAVE.Text = ds.Tables["Tabla"].Rows[0]["folio"].ToString();
            }
        }
        //private void busca()
        //    clases.Conexion c;
        private void Guardar_Click(object sender, EventArgs e)
        {
            if (TXTNOMBREROL.Text == "")
            {
                MessageBox.Show("Falta de rellenar datos");
            }
            else
            {
                graba();
                cargarfolio();
                TXTNOMBREROL.Clear();
            }
        }
        private void graba()
        {
            clases.ClRoles B = new clases.ClRoles(byte.Parse(TXTCLAVE.Text));
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new clases.ClRoles(byte.Parse(TXTCLAVE.Text), TXTNOMBREROL.Text);//, true
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new clases.Conexion(G.modificar());
            else
                c = new clases.Conexion(G.GRABAR());
            MessageBox.Show(c.ejecutar());
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TXTCLAVE_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void Imprimir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Catalogo2.Plantilla x = new Catalogo2.Plantilla();

            Catalogo2.rptRoles orptPrueba;
            ConnectionInfo oConexInfo;
            Tables oListaTablas;
            TableLogOnInfo oTablaConexInfo;
            oConexInfo = new ConnectionInfo();
            oConexInfo.ServerName = clases.globales.server;
            oConexInfo.DatabaseName = clases.globales.dbn;

            Boolean IntegratedSecurity = false;
            oConexInfo.IntegratedSecurity = IntegratedSecurity;
            oConexInfo.UserID = clases.globales.userID;
            oConexInfo.Password = clases.globales.password;
            oConexInfo.DatabaseName = clases.globales.dbn;
            oConexInfo.Type = ConnectionInfoType.Query;

            //orptPrueba = new rptventasperiodo();
            orptPrueba = new Catalogo2.rptRoles();
            oListaTablas = orptPrueba.Database.Tables;
            foreach (Table roTabla in oListaTablas)
            {
                oTablaConexInfo = roTabla.LogOnInfo;
                oTablaConexInfo.ConnectionInfo = oConexInfo;
                roTabla.ApplyLogOnInfo(oTablaConexInfo);
            }

            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;


          /*  if (!(string.IsNullOrEmpty(txtboletai.Text)))
                orptPrueba.SetParameterValue("@FOLIOBOLETA", int.Parse(txtboletai.Text));
            else

                MessageBox.Show("Por favor introduzca el Número de Boleta", "Advertencia",
        MessageBoxButtons.OK,
        MessageBoxIcon.Exclamation,
        MessageBoxDefaultButton.Button1);*/


            x.crystalReportViewer1.ReportSource = orptPrueba;
            x.ShowDialog();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }
    }
}

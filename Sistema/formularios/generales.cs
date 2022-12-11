using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.formularios
{
    public partial class generales : Form
    {
        public generales()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            busca();
        }

        clases.CLIENTE G;
        private void busca()
        {
            try
            {
                G = new clases.CLIENTE();
                clases.Conexion con = new clases.Conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        TXTNOMBRE.Text = con.FieldValue;
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
        clases.CLIENTE B;
        private void consultar()
        {
            if (!(TXTNOMBRE.Text == ""))
            {
                try
                {
                    B = new clases.CLIENTE(TXTNOMBRE.Text);
                    DataSet ds = new DataSet();
                    c = new clases.Conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        TXTNOMBRE.Text = ds.Tables["Tabla"].Rows[0]["Nombre"].ToString();
                        textDirec.Text = ds.Tables["Tabla"].Rows[0]["Direccion"].ToString();
                        textTelefono.Text = ds.Tables["Tabla"].Rows[0]["Telefono"].ToString();
                        TXTGerente.Text = ds.Tables["Tabla"].Rows[0]["Gerente"].ToString();
                    }
                    else
                    
                        MessageBox.Show("No Existe este dato");
                        TXTNOMBRE.Focus();
                        
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

       /*private void generales_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }

        void cargarfolio()
        {
            B = new clases.generales();
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                TXTNOMBREROL.Text = ds.Tables["Tabla"].Rows[0]["folio"].ToString();
            }
        }*/

        private void Guardar_Click(object sender, EventArgs e)
        {
            if ((TXTNOMBRE.Text == "") || (textDirec.Text == "") || (textTelefono.Text == "") || (TXTGerente.Text == ""))
            {
                MessageBox.Show("Falta de rellenar datos");
            }
            else
            {
                graba();
                // cargarfolio();
                TXTNOMBRE.Clear();
                textDirec.Clear();
                textTelefono.Clear();
                TXTGerente.Clear();
            }
        }

        private void graba()
        {
            clases.CLIENTE B = new clases.CLIENTE(TXTNOMBRE.Text);
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new clases.CLIENTE(TXTNOMBRE.Text, textDirec.Text, textTelefono.Text, TXTGerente.Text);//, true
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

        private void generales_Load(object sender, EventArgs e)
        {

        }
    }
}

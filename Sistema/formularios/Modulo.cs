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
    public partial class Modulo : Form
    {
        public Modulo()
        {
            InitializeComponent();
        }

        private void Modulo_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (TXTNOMBREROL.Text == "")
            {
                MessageBox.Show("Rellene los datos necesarios");
            }
            else
            {
                graba();
                cargarfolio();
                TXTNOMBREROL.Clear();
            }
        }

        clases.Modulo G;
        private void busca()
        {
            try
            {
                G = new clases.Modulo();
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
        clases.Modulo B;
        private void consultar()
        {
            if (!(TXTCLAVE.Text == ""))
            {
                try
                {
                    B = new clases.Modulo(byte.Parse(TXTCLAVE.Text));
                    DataSet ds = new DataSet();
                    c = new clases.Conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        TXTCLAVE.Text = ds.Tables["Tabla"].Rows[0]["ID"].ToString();
                        TXTNOMBREROL.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                      

                    }
                    else

                        MessageBox.Show("Este dato no existe");
                    TXTNOMBREROL.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        void cargarfolio()
        {
            B = new clases.Modulo();
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                TXTCLAVE.Text = ds.Tables["Tabla"].Rows[0]["Folio"].ToString();
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            busca();
        }

        private void graba()
        {
            clases.Modulo B = new clases.Modulo(byte.Parse(TXTCLAVE.Text));
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new clases.Modulo(byte.Parse(TXTCLAVE.Text), TXTNOMBREROL.Text);//, true
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
    }
}

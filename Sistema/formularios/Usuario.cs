using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            cargarroles();
            cargarfolio();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void cargarroles()
        {
            DataSet ds = new DataSet();
            clases.ClRoles s = new clases.ClRoles();
            clases.Conexion c = new clases.Conexion(s.consultageneral());
            ds = c.consultar();
            cdroles.DataSource = ds.Tables[0];
            cdroles.DisplayMember = ds.Tables[0].Columns["Nombre"].ToString();
            cdroles.ValueMember = ds.Tables[0].Columns["Clave"].ToString();

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("Rellene los datos faltantes");
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    graba();
                    cargarfolio();
                    textBox4.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta");
                }
            }

        }
        
        public string consultafeneral()
        {
            return ("select * ");
        }

        clases.CLUsuario G;
        private void busca()
        {
            try
            {
                G = new clases.CLUsuario();
                clases.Conexion con = new clases.Conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        textBox1.Text = con.FieldValue;
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
        clases.CLUsuario B;
        private void consultar()
        {
            if (!(textBox1.Text == ""))
            {
                try
                {
                    B = new clases.CLUsuario(Convert.ToInt32(textBox1.Text));
                    DataSet ds = new DataSet();
                    c = new clases.Conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        textBox1.Text = ds.Tables["Tabla"].Rows[0]["id_usuario"].ToString();
                        textBox4.Text = ds.Tables["Tabla"].Rows[0]["Nombre"].ToString();
                        textBox2.Text = ds.Tables["Tabla"].Rows[0]["Contraseña"].ToString();
                        cdroles.Text = ds.Tables["Tabla"].Rows[0]["Rol"].ToString();                    
                    }
                    else

                        MessageBox.Show("Este dato no existe");
                    textBox4.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        void cargarfolio()
        {
            B = new clases.CLUsuario();
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables["Tabla"].Rows[0]["Folio"].ToString();
            }
        }

        private void graba()
        {
            clases.CLUsuario B = new clases.CLUsuario(Convert.ToInt32(textBox1.Text));
            DataSet ds = new DataSet();
            c = new clases.Conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new clases.CLUsuario(Convert.ToInt32(textBox1.Text), textBox4.Text, clases.Contraseña.Encrypt.GetMD5(textBox2.Text), byte.Parse(cdroles.SelectedValue.ToString()));//, true
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new clases.Conexion(G.modificar());
            else
                c = new clases.Conexion(G.GRABAR());
            MessageBox.Show(c.ejecutar());
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            busca();
        }
    }
}

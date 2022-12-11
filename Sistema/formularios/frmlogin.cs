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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        clases.Conexion c;
        clases.CLUSUARIOS cu;

        private void button2_Click(object sender, EventArgs e)
        {
           ingresar();
        }

        private void ingresar()
        {
            clases.CLUSUARIOS U = new clases.CLUSUARIOS(textBox1.Text, textBox2.Text);
            DataSet ds = new DataSet();
            c = new clases.Conexion(U.CONSULTARI());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                Menu x = new Menu();
                x.Show(); this.Hide();
            }
          else
            {
                MessageBox.Show("Usuario o Contraseña incorrectas", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

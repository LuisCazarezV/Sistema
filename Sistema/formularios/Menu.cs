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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void rOLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios.FrRoles x = new formularios.FrRoles();
            x.Show();

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario x = new Usuario();
            x.Show();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mODULOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios.Modulo x = new formularios.Modulo();
            x.Show();
        }

        private void generalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios.generales x = new formularios.generales();
            x.Show();
        }
    }
}

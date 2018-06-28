using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmDemo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbMinimize_MouseHover(object sender, EventArgs e)
        {
            pbMinimize.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void pbClose_MouseHover(object sender, EventArgs e)
        {
           pbClose.BackColor =  Color.FromArgb(244, 67, 54);
        }

        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
            pbMinimize.BackColor = Color.FromArgb(15, 15, 15);

        }

        private void PintarLetraTextBox(TextBox parametro)
        {
            if (parametro.Text == "Ingresar Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
                
                
            }
            else if(parametro.Text == "Ingresar Clave")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.White;
                
            }
        }
 
    

        private void txtClave_Enter(object sender, EventArgs e)
        {
            PintarLetraTextBox(txtClave);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            PintarLetraTextBox(txtUsuario);
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == String.Empty)
            {
                txtClave.Text = "Ingresar Clave";
                txtClave.ForeColor = Color.FromArgb(0, 130, 114);
          
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty)
            {
                txtUsuario.Text = "Ingresar Usuario";
                txtUsuario.ForeColor = Color.FromArgb(0, 130, 114);
              
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
       
            
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            var frmPrincipalMenu = new frmPrincipalMenu();
            this.Hide();
            frmPrincipalMenu.ShowDialog();
        }
    }
}

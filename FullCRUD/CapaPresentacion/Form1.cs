using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string retornoMensaje;
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            retornoMensaje = NMarca.IngresarMarca(txtNombre.Text, txtDescripcion.Text);
            MessageBox.Show(retornoMensaje);
        }
    }
}

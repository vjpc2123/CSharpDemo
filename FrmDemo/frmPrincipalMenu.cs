using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmDemo
{
    public partial class frmPrincipalMenu : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frmPrincipalMenu()
        {
            InitializeComponent();
        }

        int lx, ly;
        int sw, sh;

        private void btnRestore_Click(object sender, EventArgs e)
        {
          
        }

        private void frmPrincipalMenu_Load(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           
        }

     
        private void btnRestore_MouseHover_1(object sender, EventArgs e)
        {
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeader_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMenuSlider_Click(object sender, EventArgs e)
        {
            //-------SIN EFECTO SLIDE
            if (panelMenuBAR.Width == 40)
            {
                panelMenuBAR.Width = 185;
                btnVehiculo.Text = "Vehiculo";
                btnVender.Text = "Ventas";
                btnCliente.Text = "Cliente";
                btnSuplidor.Text = "Suplidor";
                btnCompra.Text = "Compra";
                btnMantenimiento.Text = "   Mantenimiento";

            }
            else
            {

                panelMenuBAR.Width = 40;
                btnVehiculo.Text = "";
                btnVender.Text = "";
                btnCliente.Text = "";
                btnSuplidor.Text = "";
                btnCompra.Text = "";
                btnMantenimiento.Text = "";
            }
        }

        private void panelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelPrincipal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(64, 69, 76));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.FromArgb(0, 122, 204), sizeGripRectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            frmVehiculo Frm = new frmVehiculo();
            ExecuteFormIntoPanel(Frm);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
         
        }

        private void ExecuteFormIntoPanel(object FormSon)
        {
            if (this.panelFormularios.Controls.Count > 0)
                this.panelFormularios.Controls.RemoveAt(0);
            Form fh = FormSon as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelFormularios.Controls.Add(fh);
            this.panelFormularios.Tag = fh;
            fh.Show();
        }
    }
}

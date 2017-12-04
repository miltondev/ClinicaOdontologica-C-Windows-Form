using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaProject
{
    public partial class Mastermenu : Form
    {
        private int childFormNumber = 0;

        public Mastermenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

   

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Mastermenu_Load(object sender, EventArgs e)
        {

        }

        private void opcionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            Login lg = new Login();
            lg.MdiParent = this;
            lg.Show();

        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {

            Consultas lg = new Consultas();
            lg.MdiParent = this;
            lg.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {

            Citas lg = new Citas();
            lg.MdiParent = this;
            lg.Show();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {

            //Facturas lg = new Facturas();
            //lg.MdiParent = this;
            //lg.Show();
        }

        private void btnDoctores_Click(object sender, EventArgs e)
        {

            Doctores lg = new Doctores();
            lg.MdiParent = this;
            lg.Show();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {

            //Pacientes lg = new Pacientes();
            //lg.MdiParent = this;
            //lg.Show();
        }

        private void btnTratamientos_Click(object sender, EventArgs e)
        {
           //Tratamientos lg = new Tratamientos();
           // lg.MdiParent = this;
           // lg.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
            this.Close();
        }
    }
}

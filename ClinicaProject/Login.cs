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
    public partial class Login : Form
    {
        public static string Username = "Admin";
        public static string Passwd = "12345678";

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.Equals(Username) && txtContra.Text.Equals(Passwd))
            {
                Mastermenu ms = new Mastermenu();
                this.Hide();
                ms.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error, No se Pudo Iniciar Sesion");
            }
        }
    }
}

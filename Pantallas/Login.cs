using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_DSI
{
    public partial class Login : Form
    {
        private Usuario usuario;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Usuario uss = new Usuario("Hassan Dinia", "1234", true);
            usuario = uss;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUss.Text.Equals("") || txtCon.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese su usuario y contraseña.");
                return;
            }
            if (txtUss.Text.Trim().Equals(usuario.Uss) && txtCon.Text.Trim().Equals(usuario.Con))
            {
                MessageBox.Show("Sesion iniciada con éxito, bienvenido " + usuario.Uss);
                Menu frm = new Menu(usuario, this);
                Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Contraseña o Usuario incorrectos.");
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgLogin_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu(usuario, this);
            Hide();
            frm.Show();
        }
    }
}
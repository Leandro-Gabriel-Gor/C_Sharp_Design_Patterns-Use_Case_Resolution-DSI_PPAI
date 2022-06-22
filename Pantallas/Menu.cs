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
    public partial class Menu : Form
    {
        private Usuario usuario;
        private Login login;

        public Menu(Usuario uss, Login log)
        {
            InitializeComponent();
            usuario = uss;
            login = log;
        }

        private void opcionReserva(object sender, EventArgs e)
        {
            PantallaReservaTurno pantalla = new PantallaReservaTurno(usuario, login, this);
            Hide();
            pantalla.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            login.Close();
        }
    }
}
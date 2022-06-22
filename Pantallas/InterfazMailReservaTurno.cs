using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class InterfazMailReservaTurno
    {
        public void enviarReserva(string mail, string mensaje, PantallaReservaTurno pantalla)
        {
            pantalla.enviarCorreo(mensaje, mail);
        }
    }
}
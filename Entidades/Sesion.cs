using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Sesion
    {
        private DateTime fechaHoraInicio { get; set; }
        private DateTime fechaHoraFin { get; set; }
        private Usuario usuario { get; set; }

        public Sesion(DateTime fechaHoraInicio, DateTime fechaHoraFin, Usuario usuario)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.usuario = usuario;
        }

        public PersonalCientiico obtenerCientificoLogueado( List<PersonalCientiico> cientificosbd)
        {
            return usuario.obtenerCientifico(cientificosbd);
        }
    }
}

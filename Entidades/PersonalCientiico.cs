using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class PersonalCientiico
    {
        private string legajo { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string nroDoc { get; set; }
        private string correoInstitucion { get; set; }
        private string correoPersonal { get; set; }
        private string telefonoCelular { get; set; }
        private Usuario usuario { get; set; }


        public PersonalCientiico(string legajo, string nombre, string apellido, string nroDoc, string correoInstitucion, string correoPersonal, string telefonoCelular, Usuario usuario)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nroDoc = nroDoc;
            this.correoInstitucion = correoInstitucion;
            this.correoPersonal = correoPersonal;
            this.telefonoCelular = telefonoCelular;
            this.usuario = usuario;
        }

        public PersonalCientiico() { }

        internal Usuario getUsuario()
        {
            return usuario;
        }

        internal void setTurno(Turno turnoSelec, AsignacionCientificoDelCl asignacionCI)
        {
            throw new NotImplementedException();
        }

        internal string getMail()
        {
            return correoInstitucion;
        }
    }
}
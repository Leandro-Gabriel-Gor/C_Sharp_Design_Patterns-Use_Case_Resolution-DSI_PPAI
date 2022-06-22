using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class AsignacionCientificoDelCl
    {
        private DateTime fechaDesde { get; set; }
        private DateTime? fechaHasta { get; set; }
        private PersonalCientiico personalCientiico { get; set; }
        private List<Turno> turnos { get; set; }

        public AsignacionCientificoDelCl(DateTime fechaDesde, DateTime fechaHasta, PersonalCientiico personalCientiico, List<Turno> turno)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.personalCientiico = personalCientiico;
            this.turnos = turno;
        }
        public AsignacionCientificoDelCl()
        {

        }

        public AsignacionCientificoDelCl(DateTime fechaDesde, PersonalCientiico personalCientiico, List<Turno> turno)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = null;
            this.personalCientiico = personalCientiico;
            this.turnos = turno;
        }

        public PersonalCientiico getPersonalCientifico()
        {
            return personalCientiico;
        }

        internal bool esCientificoActivo()
        {
            return fechaHasta == null;
        }

        internal void setTurno(Turno turno)
        {
            this.turnos.Add(turno);
        }

        internal string obtenerMail()
        {
            return personalCientiico.getMail();
        }
    }
}
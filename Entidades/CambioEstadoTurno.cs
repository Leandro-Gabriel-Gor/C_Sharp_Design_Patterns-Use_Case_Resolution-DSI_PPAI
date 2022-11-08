using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class CambioEstadoTurno
    {
        private DateTime fechaHoraDesde { get; set; }
        private DateTime? fechaHoraHasta { get; set; }
        private Estado estado { get; set; }

        public CambioEstadoTurno(DateTime fechaHoraDesde, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = null;
            this.estado = estado;
        }

        public CambioEstadoTurno(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.estado = estado;
        }

        public CambioEstadoTurno()
        {
        }

        internal bool esActual()
        {
            return fechaHoraHasta == null;
        }

        internal string mostrarEstado()
        {
            return estado.getNombre();
        }

        internal void setFechaHoraHasta()
        {
            fechaHoraHasta = DateTime.Now;
        }
    }
}
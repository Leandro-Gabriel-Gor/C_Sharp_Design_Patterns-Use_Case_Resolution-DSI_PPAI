using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class CambioEstadoRT
    {
        private DateTime fechaHoraDesde { get; set; }
        private DateTime? fechaHoraHasta { get; set; }
        private Estado estado { get; set; }

        public CambioEstadoRT(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.estado = estado;
        }

        public CambioEstadoRT(DateTime fechaHoraDesde, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
   
            this.estado = estado;
        }


        public bool esActual()
        {
            return fechaHoraHasta == null;
        }

        internal bool esEstadoActualReservable()
        {
            return estado.esReservable1();
        }

        public string mostrarEstado()
        {
            return estado.getNombre();
        }
    }
}
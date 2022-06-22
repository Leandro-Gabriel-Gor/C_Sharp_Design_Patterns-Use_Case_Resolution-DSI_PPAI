using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Turno
    {
        private DateTime fechaHoraInicio { get; set; }
        private DateTime fechaHoraFin { get; set; }
        private string diaSemana { get; set; }
        private DateTime fechaGeneracion { get; set; }
        private List<CambioEstadoTurno> cambioEstadoTurno {get; set; }

        public Turno(DateTime fechaHoraInicio, DateTime fechaHoraFin, string diaSemana, DateTime fechaGeneracion, List<CambioEstadoTurno> cambioEstadoTurno)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.diaSemana = diaSemana;
            this.fechaGeneracion = fechaGeneracion;
            this.cambioEstadoTurno = cambioEstadoTurno;
        }

        internal bool esPosteriorAFecha(DateTime fecha)
        {
            return DateTime.Compare(fechaHoraInicio, fecha) > 0;
        }

        internal List<string> mostrarTurno()
        {
            List<string> turno = new List<string>();
            foreach (var CEturno in cambioEstadoTurno)
            {
                if (CEturno.esActual())
                {
                    turno.Add(this.diaSemana);
                    turno.Add(this.fechaHoraInicio.ToString());
                    turno.Add(this.fechaHoraFin.ToString());
                    turno.Add(CEturno.mostrarEstado());
                }
            }
            return turno;
        }

        internal DateTime getFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        internal void reservar(Estado estado)
        {
            foreach (var CEturno in cambioEstadoTurno)
            {
                if (CEturno.esActual())
                {
                    CEturno.setFechaHoraHasta();
                }
            }

            this.cambioEstadoTurno.Add(new CambioEstadoTurno(DateTime.Now, estado));
        }

        public string getStrTurno()
        {
            return "Fecha: " + fechaHoraInicio.ToString("dd/MM/yyyy") + ".\n"
                + "Hora de Inicio: " + fechaHoraInicio.ToString("HH:mm") + "hs" + ".\n"
                + "Hora de Fin: " + fechaHoraFin.ToString("HH:mm") + "hs.";
        }
    }
}
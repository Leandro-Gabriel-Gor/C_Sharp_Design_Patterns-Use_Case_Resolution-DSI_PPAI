using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Estados
{
    public class DisponibleT : Estado
    {
        public DisponibleT(string nombre, string descripcion, string ambito) : base(nombre, descripcion, ambito)
        {
        }

        public override void reservarTurno(Turno turnoSeleccionado, PersonalCientiico ci, List<CambioEstadoTurno> cambioEstados) {
            //listaCET = BD.traerlistaid(id Turno)
            CambioEstadoTurno actualCET = buscarCambioEstadoActual(cambioEstados);
            actualCET.setFechaHoraHasta();
            Estado nuevoEstado = crearEstadoNuevo();
            CambioEstadoTurno nuevoCET = new CambioEstadoTurno(DateTime.Now, nuevoEstado);
            turnoSeleccionado.agregarCambioEstadoTurno(nuevoCET);
            turnoSeleccionado.setEstado(nuevoEstado);

        }

        public Estado crearEstadoNuevo()
        {
            return new ReservadoT(
                "Reserva Pendiente", "La reserva del turno se encuentra pendiente de confirmación.", "Turno");
        }

        public CambioEstadoTurno buscarCambioEstadoActual(List<CambioEstadoTurno> cambioEstadoTurno)
        {
            foreach (var CEturno in cambioEstadoTurno)
            {
                if (CEturno.esActual())
                {
                    return CEturno;
                }
            }
            return new CambioEstadoTurno();
        } 

    }
}

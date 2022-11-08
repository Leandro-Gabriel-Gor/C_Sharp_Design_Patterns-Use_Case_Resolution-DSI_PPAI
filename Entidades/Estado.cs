using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Estado
    {
        internal string nombre { get; set; }
        internal string descripcion { get; set; }
        internal string ambito { get; set; }
        

        public Estado(string nombre, string descripcion, string ambito)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.ambito = ambito;
            
        }
        public Estado()
        {

        }
        public virtual bool esReservable1()
        {
            return true;
        }

        public string getNombre()
        { 
            return nombre;
        }

        public bool esAmbitoTurno()
        {
            return this.ambito.Equals("Turno");   
        }

        public bool esReservado()
        {
            return this.nombre.Equals("Reservado");
        }

        public virtual void reservarTurno(Turno turnoSeleccionado, PersonalCientiico ci, List<CambioEstadoTurno> cambioEstados)
        {
            throw new NotImplementedException();
        }
    }
}

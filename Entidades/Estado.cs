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
        internal bool esReservable { get; set; }
        internal bool esCancelable { get; set; }

        public Estado(string nombre, string descripcion, string ambito, bool esReservable, bool esCancelable)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.ambito = ambito;
            this.esReservable = esReservable;
            this.esCancelable = esCancelable;
        }
        public Estado()
        {

        }
        public virtual bool esReservable1()
        {
            return false;
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
    }
}

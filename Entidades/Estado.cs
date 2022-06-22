using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Estado
    {
        private string nombre { get; set; }
        private string descripcion { get; set; }
        private string ambito { get; set; }
        private bool esReservable { get; set; }
        private bool esCancelable { get; set; }

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
        public bool esReservable1()
        {
            return esReservable;
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

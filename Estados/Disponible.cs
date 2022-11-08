using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Estados
{
    public class Disponible : Estado
    {
        public Disponible(string nombre, string descripcion, string ambito) : base(nombre, descripcion, ambito)
        {
        }

        public override bool esReservable1()
        {
            return true;
        }
    }
}

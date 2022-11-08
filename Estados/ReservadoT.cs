using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Estados
{
    public class ReservadoT : Estado
    {

        public ReservadoT(string nombre, string descripcion, string ambito) : base(nombre, descripcion, ambito)
        {
        }
    }
}

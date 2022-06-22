using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class CaracteristicaRecursoTecnologico
    {
        private int valor { get; set; }
        private Caracteristica caracteristica { get; set; }

        public CaracteristicaRecursoTecnologico(int valor, Caracteristica caracteristica)
        {
            this.valor = valor;
            this.caracteristica = caracteristica;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class TipoRecursoTecnologico
    {
        private string nombre { get; set; }
        private string descripcion { get; set; }
        private List<Caracteristica> caracteristica { get; set; }

        public TipoRecursoTecnologico(string nombre, string descripcion, List<Caracteristica> caracteristica)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.caracteristica = caracteristica;
        }

        public TipoRecursoTecnologico mostrarTipoRecurso()
        {
            return this;
        }

        public string getNombre() { return this.nombre; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Marca
    {
        private string nombre { get; set; }
        private List <Modelo> modelos { get; set; }

        public Marca(string nombre, List<Modelo> modelos)
        {
            this.nombre = nombre;
            this.modelos = modelos;
        }

        public List<Modelo> getModelos()
        {
            List<Modelo> modelos = new List<Modelo> { };
            foreach (Modelo mod in this.modelos)
            {
                modelos.Add(mod);
            }
            return modelos;
        }

        public string mostrarMarca()
        {
            return this.nombre;
        }
    }
}
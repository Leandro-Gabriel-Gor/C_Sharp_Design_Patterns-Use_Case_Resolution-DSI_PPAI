using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Modelo
    {
        private string nombre { get; set; }

        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }


        internal List<string> mostrarMarcaYModelo(List<Marca> marcaBD)
        {
            List<string> result = new List<string>();
            result.Add(nombre);
            Marca marca = null;
            foreach (Marca mar in marcaBD)
            {
                if (mar.getModelos().Contains(this))
                {
                    marca = mar;
                }
            }
            result.Add(marca.mostrarMarca());
            return result;
        }
    }
}
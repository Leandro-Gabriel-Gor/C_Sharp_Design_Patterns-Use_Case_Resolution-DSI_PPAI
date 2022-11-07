using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Repositorios
{
    public class MarcaRepositorio
    {
        public List<Marca> GetMarcas()
        {
            var sql = $"SELECT * FROM Marcas WHERE Activo=1";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            var marcas = new List<Marca>();

            // Mostramos los locales en la grilla
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var marca = new Marca();
                marca.id = Convert.ToInt32(fila["id"].ToString());
                marca.descripcion = fila["descripcion"].ToString();
                marcas.Add(marca);
            }

            return marcas;
        }

    }
}

using PPAI_DSI.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace PPAI_DSI.Repositorios
{
    public class SuperObjetoPersistente
    {
        // Trae todos los tipos de recursos tecnológicos.
        internal List<TipoRecursoTecnologico> getRTBD()
        {
            Caracteristica carac = new Caracteristica("Memoria", "cantidad de memoria para guardar");
            var tipos = new List<TipoRecursoTecnologico>();
            var sentenciaSql = $"SELECT * FROM TipoRecursoTecnologico";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipo = new TipoRecursoTecnologico(
                    fila["nombre"].ToString(),
                    fila["descripcion"].ToString(),
                    new List<Caracteristica> { carac }
                    );
                tipo.nombre = fila["nombre"].ToString();
                tipo.descripcion = fila["descripcion"].ToString();
                tipos.Add(tipo);
            }
            return tipos;
        }

        // Trae todos los recursos tecnológicos con su lista de turnos.
        internal List<RecursoTecnologico> getRecursosBD()
        {
            throw new NotImplementedException();
        }

        internal List<CentroDeInvestigacion> getCIBD()
        {
            throw new NotImplementedException();
        }

        internal List<Marca> getMarcaBD()
        {
            throw new NotImplementedException();
        }

        internal List<Estado> getEstadosBD()
        {
            throw new NotImplementedException();
        }

        internal List<PersonalCientiico> getPCBD()
        {
            throw new NotImplementedException();
        }
    }
}

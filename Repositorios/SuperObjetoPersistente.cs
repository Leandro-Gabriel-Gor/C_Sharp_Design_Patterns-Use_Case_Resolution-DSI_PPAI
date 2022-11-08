using PPAI_DSI.Entidades;
using PPAI_DSI.Estados;
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
            List<Caracteristica> caracteristicas = new List<Caracteristica>();
            List<CambioEstadoRT> cambiosEstadoRT = new List<CambioEstadoRT>();
            var recursosTecnologicos = new List<RecursoTecnologico>();
            var sentenciaSql = $"" +
                $"SELECT RT.numeroRT, RT.fechaAlta, RT.imagenes," +
                $" RT.periodicidadMantenimientoPrev, RT.duracionMantenimientoPrev," +
                $"TRT.nombre as nombreTRT, TRT.descripcion, M.nombre as nombreM " +
                $"FROM RecursoTecnologico RT JOIN TipoRecursoTecnologico TRT JOIN Modelo M " +
                $"WHERE RT.idTipoRecursoTecnologico = TRT.id and M.id = RT.idModelo";

            //esa sentencia esta mal
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var RT = new RecursoTecnologico(
                    int.Parse(fila["numeroRT"].ToString()),
                    DateTime.Parse(fila["fechaAlta"].ToString()),
                    fila["imagen"].ToString(),
                    int.Parse(fila["periodicidadMantenimientoPrev"].ToString()),
                    int.Parse(fila["duracionMantenimientoPrev"].ToString()),
                    new TipoRecursoTecnologico(fila["nombreTRT"].ToString(), fila["descripcion"].ToString(), caracteristicas),
                    GetTurnosXRecurso(int.Parse(fila["numeroRT"].ToString())),
                    new Modelo(fila["nombreM"].ToString()),
                    cambiosEstadoRT,
                    new Disponible("Disponible", "El RT se encuentra disponible para ser reservado.", "RT"));

                recursosTecnologicos.Add(RT);
            }

            return recursosTecnologicos;
        }

        public List<Turno> GetTurnosXRecurso(int idRecurso)
        {
            List<Turno> turnos = new List<Turno>();
            var sentenciaSql = $"SELECT * FROM Turno T JOIN Estado E WHERE T.nombreEstado = E.nombre and T.ambitoEstado = E.ambito and T.idRecurso = {idRecurso}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                Estado estado = new Estado();
                switch (fila["nombre"].ToString())
                {
                    case "Disponible":
                        estado = new DisponibleT(fila["nombre"].ToString(), fila["descripcion"].ToString(), fila["ambito"].ToString());
                        break;
                    case "Reservado":
                        estado = new ReservadoT(fila["nombre"].ToString(), fila["descripcion"].ToString(), fila["ambito"].ToString());
                        break;
                }

                var turno = new Turno(
                    DateTime.Parse(fila["fechaHoraInicio"].ToString()),
                    DateTime.Parse(fila["fechaHoraFin"].ToString()),
                    fila["diaSemana"].ToString(),
                    DateTime.Parse(fila["fechaGeneracion"].ToString()),
                    GetCambioEstadoTurnoXTurno(fila["id"].ToString()),
                    estado);
                turnos.Add(turno);

            }

            return turnos;
        }

        public List<CambioEstadoTurno> GetCambioEstadoTurnoXTurno(string id)
        {
            List<CambioEstadoTurno> cambios = new List<CambioEstadoTurno>();
            var sentenciaSql = $"SELECT * FROM CambioEstadoTurno WHERE id = {id}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                Estado estado = new Estado();
                switch (fila["nombre"].ToString())
                {
                    case "Disponible":
                        estado = new DisponibleT(fila["estado"].ToString(), fila["descripcion"].ToString(), fila["ambito"].ToString());
                        break;
                    case "Reservado":
                        estado = new ReservadoT(fila["estado"].ToString(), fila["descripcion"].ToString(), fila["ambito"].ToString());
                        break;
                }

                var CET = new CambioEstadoTurno(
                    DateTime.Parse(fila["fechaHoraDesde"].ToString()),
                    DateTime.Parse(fila["fechahorahasta"].ToString()),
                    estado
                    );
                cambios.Add(CET);
            }

            return cambios;
        }


        internal List<CentroDeInvestigacion> getCIBD()
        {
            var centros = new List<CentroDeInvestigacion>();
            var sentenciaSql = $"SELECT * FROM CentroDeInvestigacion";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                //var centro = new CentroDeInvestigacion(
                //    fila["nombre"].ToString(),
                //    fila["sigla"].ToString(),
                //    fila["direccion"].ToString(),
                //    fila["edificio"].ToString(),
                //    Convert.ToInt32(fila["piso"]),
                //    Convert.ToInt32(fila["coordenadas"]),
                //    Convert.ToInt32(fila["telefonoContacto"]),
                //    fila["mail"].ToString(),
                //    Convert.ToInt32(fila["numeroResolucionCreacion"]),
                //    DateTime.Parse(fila["fechaResolucionCreacion"].ToString()),
                //    fila["reglamento"].ToString(),
                //    fila["caracteristicasGenerales"].ToString(),
                //    DateTime.Parse(fila["fechaAlta"].ToString()),
                //    fila["motivoBaja"],
                //    Convert.ToInt32(fila["tiempoAntelacionReserva"]),
                //    GetRecursosXCI(fila["id"].ToString()));
                //    //GetAsignacionCientificosDelCI()));

                //centros.Add(centro);
            }
            return centros; ;
        }

        private object GetRecursosXCI(string id)
        {
            List<Caracteristica> caracteristicas = new List<Caracteristica>();
            List<CambioEstadoRT> cambiosEstadoRT = new List<CambioEstadoRT>();
            var recursosTecnologicos = new List<RecursoTecnologico>();
            var sentenciaSql = $"SELECT RT.numeroRT, RT.fechaAlta, RT.imagen, RT.periodicidadMantenimientoPrev, RT.duracionMantenimientoPrev," +
                $"TRT.nombre as nombreTRT, TRT.descripcion, M.nombre as nombreM " +
                $"FROM RecursoTecnologico RT JOIN TipoRecursoTecnologico TRT JOIN Modelo M JOIN CentroDeInvestigacion CI " +
                $"WHERE RT.idTipoRecursoTecnologico = TRT.id and M.id = RT.idModelo and CI.idRecursoTecnologico = RT.numeroRT and CI.id = {id}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var RT = new RecursoTecnologico(
                    int.Parse(fila["numeroRT"].ToString()),
                    DateTime.Parse(fila["fechaAlta"].ToString()),
                    fila["imagen"].ToString(),
                    int.Parse(fila["periodicidadMantenimientoPrev"].ToString()),
                    int.Parse(fila["duracionMantenimientoPrev"].ToString()),
                    new TipoRecursoTecnologico(fila["nombreTRT"].ToString(), fila["descripcion"].ToString(), caracteristicas),
                    GetTurnosXRecurso(int.Parse(fila["numeroRT"].ToString())),
                    new Modelo(fila["nombreM"].ToString()),
                    cambiosEstadoRT,
                    new Disponible("Disponible", "El RT se encuentra disponible para ser reservado.", "RT"));

                recursosTecnologicos.Add(RT);
            }

            return recursosTecnologicos;
        }

        public List<Marca> getMarcaBD()
        {
            var marcas = new List<Marca>();
            var sentenciaSql = $"SELECT * FROM Marca";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var marca = new Marca(
                    fila["nombre"].ToString(),
                    GetModelos()
                    );
                marcas.Add(marca);
            }
            return marcas;
        }

        public List<Modelo> GetModelos()
        {
            var modelos = new List<Modelo>();
            var sentenciaSql = $"SELECT * FROM Modelo";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var modelo = new Modelo(
                    fila["nombre"].ToString()
                    );
                modelos.Add(modelo);
            }
            return modelos;

        }
        //falta implementar
        internal List<Estado> getEstadosBD()
        {
            var modelos = new List<Estado>();
            var sentenciaSql = $"SELECT * FROM Estado";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                //supongo que hay que hacer un if para el ambito y dentro del ambito turno otro if y al diabolo cabron
            }
            return modelos;
        }

        internal List<PersonalCientiico> getPCBD()
        {
            var modelos = new List<PersonalCientiico>();
            var sentenciaSql = $"SELECT * FROM PersonalCientifico PC JOIN Usuario U WHERE PC.idUsuario = U.id";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var personalCientifico = new PersonalCientiico(
                    fila["legajo"].ToString(),
                    fila["nombre"].ToString(),
                    fila["apellido"].ToString(),
                    fila["nroDoc"].ToString(),
                    fila["correoInstitucion"].ToString(),
                    fila["correoPersonal"].ToString(),
                    fila["telefonoCelular"].ToString(),
                    new Usuario(fila["usuario"].ToString(),
                    fila["contraseña"].ToString(),
                    bool.Parse(fila["habiilitado"].ToString()))
                    );
                modelos.Add(personalCientifico);
            }
            return modelos;
        }
    }
}

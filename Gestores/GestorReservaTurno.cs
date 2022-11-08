using PPAI_DSI.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPAI_DSI.Entidades
{
    public class GestorReservaTurno
    {
        SuperObjetoPersistente sop = new SuperObjetoPersistente();
        private List<TipoRecursoTecnologico> tiposRTBD;
        private List<RecursoTecnologico> recursos { get; set; }
        private Sesion sesion { get; set; }
        private List<TipoRecursoTecnologico> tiposRT { get; set; }
        private DateTime fecha { get; set; }
        private Turno turno { get; set; }
        private bool controlInvestigacionRT { get; set; }
        private List<TipoRecursoTecnologico> tiposRTSeleccionados { get; set; }
        private List<RecursoTecnologico> recursosbd { get; set; }
        private List<Marca> marcaBD { get; set; }
        private List<CentroDeInvestigacion> centroInvestigacionBD { get; set; }
        private List<PersonalCientiico> cientificosBD { get; set; }
        private List<Estado> estadosBD { get; set; }
        private List<Turno> turnos { get; set; }
        private List<List<Turno>> matrizTurnos { get; set; }
        private AsignacionCientificoDelCl asignacionCI { get; set; }

        private int val = 0;

        public GestorReservaTurno(List<RecursoTecnologico> recursos, Sesion sesion, List<TipoRecursoTecnologico> tiposRT,
            DateTime fecha, Turno turno, bool controlInvestigacionRT, List<TipoRecursoTecnologico> tiposRTSeleccionados,
            List<TipoRecursoTecnologico> tiposRTseleccionadosBD, List<RecursoTecnologico> recursosbd, List<Marca> marcaBD,
            List<CentroDeInvestigacion> centroInvestigacionBD, List<PersonalCientiico> cientificosBD, List<Estado> estadosBD)
        {
            this.recursos = recursos;
            this.sesion = sesion;
            this.tiposRT = tiposRT;
            this.fecha = fecha;
            this.turno = turno;
            this.controlInvestigacionRT = controlInvestigacionRT;
            this.tiposRTSeleccionados = tiposRTSeleccionados;
            this.tiposRTBD = tiposRTseleccionadosBD;
            this.recursosbd = recursosbd;
            this.marcaBD = marcaBD;
            this.centroInvestigacionBD = centroInvestigacionBD;
            this.cientificosBD = cientificosBD;
            this.estadosBD = estadosBD;
            this.matrizTurnos = new List<List<Turno>>();
            this.asignacionCI = new AsignacionCientificoDelCl();
            //tiposRTRepositorio = new TiposRTRepositorio();
        }

        public GestorReservaTurno(Sesion sesion)
        {
            this.sesion = sesion;
            this.tiposRT = sop.getRTBD();//Hecho
            this.recursosbd = sop.getRecursosBD();//Hecho
            //this.centroInvestigacionBD = sop.getCIBD();
            this.marcaBD = sop.getMarcaBD();//Hecho
            this.estadosBD = sop.getEstadosBD();//Empezado
            this.cientificosBD = sop.getPCBD();//Hecho
        }


        // 1. 
        public void nuevaReserva(PantallaReservaTurno boundary)
        {
            obtenerTipoRT();
            boundary.pedirSeleccionTipoRT(tiposRT);
        }

        public void obtenerTipoRT() // Aca se ingresa a BD
        {
            //var tiposRT = tiposRTRepositorio.GetTipos();


            // metodo que llena la lista tiposRTBD
            //llamar muchas veces el metodo mostrarTipoRecurso
            foreach (TipoRecursoTecnologico tipo in tiposRTBD)
            {
                tiposRT.Add(tipo.mostrarTipoRecurso());
            }
        }


        // 2. 
        public void tomarSeleccionTipoRT(int indice, PantallaReservaTurno boundary)
        {
            indice--;
            if (indice == -1)
            {
                tiposRTSeleccionados = tiposRTBD;
            }
            else
            {
                tiposRTSeleccionados.Add(tiposRTBD[indice]);
            }


            this.obtenerRTActivoDeTipoRT();
            List<RecursoTecnologico> rec = recursos;
            List<List<string>> mostrarDatos = new List<List<string>>();

            for (int i = 0; i < rec.Count - val; i++)
            {
                mostrarDatos.Add(rec[i].mostrarDatos(centroInvestigacionBD, marcaBD));
            }
            val = rec.Count;
            mostrarDatos = this.ordenarYAgruparRT(mostrarDatos);
            boundary.pedirSeleccionRT(mostrarDatos);
        }

        public void obtenerRTActivoDeTipoRT()
        {
            foreach (TipoRecursoTecnologico tipo in tiposRTSeleccionados)
            {
                foreach (RecursoTecnologico rec in recursosbd)
                {
                    if (rec.esDeTipoRT(tipo) && rec.esActivo())
                    {
                        recursos.Add(rec);

                    }
                }
            }

        }

        public List<List<string>> ordenarYAgruparRT(List<List<string>> mostrarDatos)
        {
            return mostrarDatos.OrderBy(x => x[1]).ToList();
        }


        // 3. 
        public void tomarSeleccionRT(int index, PantallaReservaTurno boundary)
        {
            List<List<string>> turnosReservables = new List<List<string>>();
            if (this.verificarCentroDeCientificoLogueado(index))
            {
                turnosReservables = this.obtenerTurnosReservablesRTSeleccionado(index);
            }
            List<List<List<string>>> cuboFechas = this.agruparYOrdenarTurnos(turnosReservables); // Creacion del cubo |_|
            List<bool> disponibilidadFechas = this.determinarDisponibilidadPorFecha(cuboFechas);
            boundary.pedirSeleccionDeTurno(cuboFechas, disponibilidadFechas);
        }

        public bool verificarCentroDeCientificoLogueado(int index)
        {
            PersonalCientiico cientificoLogueado = sesion.obtenerCientificoLogueado(cientificosBD);
            return this.recursoTSeleccionado(index).elCientificoEsDeMiCI(cientificoLogueado, centroInvestigacionBD, this);
        }

        internal void setAsigC(AsignacionCientificoDelCl asigCientif)
        {
            asignacionCI = asigCientif;
        }

        public RecursoTecnologico recursoTSeleccionado(int index)
        {
            return recursos[index];
        }

        private List<List<string>> obtenerTurnosReservablesRTSeleccionado(int index)
        {
            fecha = obtenerFechaActual();
            this.turnos = this.recursoTSeleccionado(index).getTurnos();
            return recursoTSeleccionado(index).mostrarTurnos(fecha);
        }

        public DateTime obtenerFechaActual()
        {
            return DateTime.Today;
        }

        private List<List<List<string>>> agruparYOrdenarTurnos(List<List<string>> turnosReservables) // |_|
        {
            List<List<List<string>>> resultado = new List<List<List<string>>>();

            var turnosPorFecha = turnosReservables.GroupBy(turno => DateTime.Parse(turno[1]).Date);
            foreach (var grupoTurno in turnosPorFecha)
            {
                resultado.Add(grupoTurno.ToList());
            }

            var turnosPorFechaT = this.turnos.GroupBy(turno => turno.getFechaHoraInicio().Date);
            foreach (var grupoTurno in turnosPorFechaT)
            {
                matrizTurnos.Add(grupoTurno.ToList());
            }

            return resultado;
        }

        private List<bool> determinarDisponibilidadPorFecha(List<List<List<string>>> cuboFechas)
        {
            List<bool> resultado = new List<bool>();
            for (int i = 0; i < cuboFechas.Count; i++)
            {
                resultado.Add(false);
                foreach (var turno in cuboFechas[i])
                {
                    if (turno[3] == "Disponible")
                    {
                        resultado[i] = true;
                        break;
                    }
                }
            }
            return resultado;
        }


        // 5. (4 es solo selección de fecha en boundary)
        internal void tomarSeleccionTurno(int indexTurno, PantallaReservaTurno pantallaReservaTurno)
        {
            pantallaReservaTurno.pedirConfirmacion();
        }


        // 6. 
        internal void tomarConfirmacionReserva(int indexT, int indexFecha, int indexRT, PantallaReservaTurno boundary, InterfazMailReservaTurno intMail)
        {
            this.generarReservaRTSeleccionado(indexRT, indexT, indexFecha);
            string mail = asignacionCI.obtenerMail();
            string mensaje = "Se ha reservado su turno.\n\n* Recurso Tecnológico:\n" + obtenerStrRT(indexRT) + "\n\n* Datos del turno:\n" + obtenerTurnoSeleccionado(indexT, indexFecha).getStrTurno();
            intMail.enviarReserva(mail, mensaje, boundary);
        }

        private void generarReservaRTSeleccionado(int RTindex, int indexT, int indexFecha)
        {
            //Estado EstadoRes = this.obtenerEstadoReservado();
            Turno turnoSelec = this.obtenerTurnoSeleccionado(indexT, indexFecha);
            this.recursoTSeleccionado(RTindex).reservarTurno(turnoSelec, asignacionCI);
        }

        private Estado obtenerEstadoReservado()
        {
            foreach (Estado est in estadosBD)
            {
                if (est.esAmbitoTurno())
                {
                    if (est.esReservado())
                    {
                        return est;
                    }
                }
            }
            return new Estado();
        }

        private Turno obtenerTurnoSeleccionado(int indexT, int indexFecha)
        {
            return matrizTurnos[indexFecha][indexT];
        }

        private string obtenerStrRT(int indexRT)
        {
            return recursos[indexRT].toString();
        }
    }
}
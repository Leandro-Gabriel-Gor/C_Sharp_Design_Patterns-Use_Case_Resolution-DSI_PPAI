using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class RecursoTecnologico
    {
        private int numeroRT { get; set; }
        private DateTime fechaAlta { get; set; }
        private string imagen { get; set; }
        private int periodicidadMantenimientoPrev { get; set; }
        private int duracionMantenimientoPrev { get; set; }
        private TipoRecursoTecnologico tipoRecursoT { get; set; }
        private List<Turno> turnos { get; set; }
        private Modelo modeloDelRT { get; set; }
        public List<CambioEstadoRT> cambioEstadoRT { get; set; }
        internal Estado estadoActual { get; set; }



        public RecursoTecnologico(int numeroRT, DateTime fechaAlta, string imagen, int periodicidadMantenimientoPrev, int duracionMantenimientoPrev, 
            TipoRecursoTecnologico tipoRecursoT, List<Turno> turno, Modelo modeloDelRT, List<CambioEstadoRT> cambioEstadoRT, Estado estadoActual)
        {
            this.numeroRT = numeroRT;
            this.fechaAlta = fechaAlta;
            this.imagen = imagen;
            this.periodicidadMantenimientoPrev = periodicidadMantenimientoPrev;
            this.duracionMantenimientoPrev = duracionMantenimientoPrev;
            this.tipoRecursoT = tipoRecursoT;
            this.turnos = turno;
            this.modeloDelRT = modeloDelRT;
            this.cambioEstadoRT = cambioEstadoRT;
            this.estadoActual = estadoActual;
        }

        public TipoRecursoTecnologico getTipoRecursoT()
        {
            return this.tipoRecursoT;
        }

        public bool esDeTipoRT(TipoRecursoTecnologico tipo)
        {
            return this.getTipoRecursoT() == tipo;
        }

        public bool esActivo()
        {
            return estadoActual.esReservable1();
        }

        private List<string> mostrarMarcaYModelo(List<Marca> marcaBD)
        {
            return modeloDelRT.mostrarMarcaYModelo(marcaBD);
        }


        public List<string> mostrarDatos( List<CentroDeInvestigacion> centroInvestigacionBD, List<Marca> marcaBD)
        {
            List<string> res = new List<string>();

            res.Add(estadoActual.getNombre());
            res.Add(this.mostrarCI(centroInvestigacionBD));
            List<string> marcaYModelo = this.mostrarMarcaYModelo(marcaBD);

            res.Add(marcaYModelo[0]);
            res.Add(marcaYModelo[1]);

            return res;
        }

        private string mostrarCI(List<CentroDeInvestigacion> centroInvestigacionBD)
        {
            return getCI(centroInvestigacionBD).getNombre();
        }

        private CentroDeInvestigacion getCI(List<CentroDeInvestigacion> centroInvestigacionBD)
        {

            foreach (CentroDeInvestigacion centro in centroInvestigacionBD)
            {
                if (centro.getRecursoTecnologicos().Contains(this))
                {
                    return centro;
                }
            }
            return new CentroDeInvestigacion();
        }



        internal bool elCientificoEsDeMiCI(PersonalCientiico personalCientiico, List<CentroDeInvestigacion> centroInvestigacionBD, GestorReservaTurno gestor)
        {
            return this.getCI(centroInvestigacionBD).esTuCientificoActivo(personalCientiico, gestor);
        }

        internal List<List<string>> mostrarTurnos(DateTime fechaActual)
        {
            List<List<string>> lista = new List<List<string>>();
            foreach (Turno turno in this.turnos)
            {
                if (turno.esPosteriorAFecha(fechaActual))
                {
                    lista.Add(turno.mostrarTurno());
                }
            }
            return lista;
        }

        public void reservarTurno(Turno turno, AsignacionCientificoDelCl asig)
        {
            foreach(Turno tur in turnos)
            {
                if(tur == turno)
                {
                    tur.reservarTurno(asig.getPersonalCientifico());
                }
            }
            asig.setTurno(turno);
        }

        internal List<Turno> getTurnos()
        {
            List<Turno> result = new List<Turno> ();
            foreach(Turno t in turnos)
            {
                result.Add(t);
            }
            return result;
        }

        internal string getEstadoActual()
        {
            return estadoActual.getNombre();
        }

        public  string toString()
        {
            return $"+ Numero RT: {numeroRT} \n" +
                $"+ ";
        }
    }
}      
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class CentroDeInvestigacion
    {
        private string nombre { get; set; }
        private string sigla { get; set; }
        private string direccion { get; set; }
        private string edificio { get; set; }
        private int piso { get; set; }
        private string coordenadas { get; set; }
        private int telefonosContacto { get; set; }
        private string mail { get; set; }
        private int numeroResolucionCreacion { get; set; }
        private DateTime fechaResolucionCreacion { get; set; }
        private string reglamento { get; set; }
        private string caracteristicasGenerales { get; set; }
        private DateTime fechaAlta { get; set; }
        private DateTime fechaBaja { get; set; }
        private string motivoBaja { get; set; }
        private DateTime tiempoAntelacionReserva { get; set; }
        private List <RecursoTecnologico> recursoTecnologicos { get; set; }
        private List <AsignacionCientificoDelCl> cientificos { get; set; }

        public CentroDeInvestigacion(string nombre, string sigla, string direccion, string edificio, int piso, string coordenadas, int telefonosContacto, string mail, int numeroResolucionCreacion, DateTime fechaResolucionCreacion, string reglamento, string caracteristicasGenerales, DateTime fechaAlta, DateTime fechaBaja, string motivoBaja, DateTime tiempoAntelacionReserva, List<AsignacionCientificoDelCl> cientificos, List<RecursoTecnologico> recursoTecnologicos)
        {
            this.nombre = nombre;
            this.sigla = sigla;
            this.direccion = direccion;
            this.edificio = edificio;
            this.piso = piso;
            this.coordenadas = coordenadas;
            this.telefonosContacto = telefonosContacto;
            this.mail = mail;
            this.numeroResolucionCreacion = numeroResolucionCreacion;
            this.fechaResolucionCreacion = fechaResolucionCreacion;
            this.reglamento = reglamento;
            this.caracteristicasGenerales = caracteristicasGenerales;
            this.fechaAlta = fechaAlta;
            this.fechaBaja = fechaBaja;
            this.motivoBaja = motivoBaja;
            this.tiempoAntelacionReserva = tiempoAntelacionReserva;
            this.cientificos = cientificos;
            this.recursoTecnologicos = recursoTecnologicos;
        }

        public CentroDeInvestigacion() { }

        internal List<RecursoTecnologico> getRecursoTecnologicos()
        {
            List<RecursoTecnologico> recursos = new List<RecursoTecnologico> { };
            foreach (RecursoTecnologico rec in recursoTecnologicos)
            {
                recursos.Add(rec);
            }
            return recursos;
        }

        internal string getNombre()
        {
            return sigla;
        }

        public List<AsignacionCientificoDelCl> getCientificos()
        {
            return cientificos;
        }

        internal bool esTuCientificoActivo(PersonalCientiico personalCientiico, GestorReservaTurno gestor)
        {
            foreach(AsignacionCientificoDelCl asigCientif in cientificos)
            {
                if (asigCientif.esCientificoActivo() && asigCientif.getPersonalCientifico() == personalCientiico)
                {
                    gestor.setAsigC(asigCientif);
                    return true;
                }
            }
            return false;
        }
    }
}
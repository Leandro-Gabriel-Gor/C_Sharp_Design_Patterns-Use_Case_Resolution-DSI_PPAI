using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Entidades
{
    public class Usuario
    {
        private string usuario { get; set; }
        private string contraseña { get; set; }
        private bool habilitado { get; set; }

        public Usuario(string usuario, string contraseña, bool habilitado)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.habilitado = habilitado;
        }

        public PersonalCientiico obtenerCientifico(List<PersonalCientiico> cientificosbd)
        {
            foreach (PersonalCientiico cientif in cientificosbd)
            {
                if (cientif.getUsuario() == this)
                {
                    return cientif;
                }
            }
            return new PersonalCientiico();
        }

        public string Uss
        {
            get => usuario;
            set => usuario = value;
        }

        public string Con
        {
            get => contraseña;
            set => contraseña = value;
        }

        public bool Habilitado
        {
            get => habilitado;
            set => habilitado = value;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class Persona
    {
        private string nombre;

        public string Nombre
        {
            get => nombre;
            set
            {
                // Validar formato “Apellidos, Nombres”
                string patron = @"^\s*(?<apellido>[\p{L}\s]{2,}?),\s*(?<nombres>[\p{L}\s]{2,})\s*$";
                Match march = Regex.Match(value, patron);
                if (march.Success == false)
                {
                    throw new FormatoNombreNoValidoException();
                }


                nombre = value;
            }
        }

        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }

        public int CompareTo(Persona other)
        {
            if (other != null)
                return nombre.CompareTo(other.nombre);
            return -1;
        }

        virtual public string Describir()
        {
            return nombre;
        }


    }
}

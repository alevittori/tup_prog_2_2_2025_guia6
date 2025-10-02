using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class FormatoNombreNoValidoException:ApplicationException
    {
        public FormatoNombreNoValidoException() : base("No cumple con el formato Valido ( Apellido, Nombre)") { }
        public FormatoNombreNoValidoException(string message) : base(message) { }
        public FormatoNombreNoValidoException(string message, Exception ex) : base(message, ex) { }

    }
}

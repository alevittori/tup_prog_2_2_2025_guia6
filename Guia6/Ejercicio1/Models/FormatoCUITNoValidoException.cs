using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class FormatoCUITNoValidoException:ApplicationException
    {
        public FormatoCUITNoValidoException() : base("CUIT NO VALIDO") { }
        public FormatoCUITNoValidoException(string message) : base(message) { }
        public FormatoCUITNoValidoException(string message,  Exception innerException) : base(message, innerException) { }

    }
}

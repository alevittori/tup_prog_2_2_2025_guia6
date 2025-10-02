using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Ejercicio1.Models
{
    internal class PersonaJuridica : Persona
    {
        string cuit;
        public PersonaJuridica(string nombre, string CUIT) : base(nombre)
        {
            
            string cuitSinGuiones = CUIT.Replace("-", "");
            
            /*
             * // Con using
                using System.Text.RegularExpressions;

                bool valido = Regex.IsMatch(cuit, @"^\d{11}$");

                // Sin using
                bool valido = System.Text.RegularExpressions.Regex.IsMatch(cuit, @"^\d{11}$");
             * */



            if (!Regex.IsMatch(cuitSinGuiones, @"^\d{11}$"))
                throw new FormatoCUITNoValidoException("El CUIT debe tener exactamente 11 dígitos numéricos.");

            if (!ValidarCUIT(cuitSinGuiones))
                throw new FormatoCUITNoValidoException("El dígito verificador del CUIT no es válido.");

             cuit = CUIT;
        }

        private bool ValidarCUIT(string cuit)
        {
            int[] pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;

            for (int i = 0; i < pesos.Length; i++)
            {
                suma += int.Parse(cuit[i].ToString()) * pesos[i];
            }

            int resto = suma % 11;
            int digitoVerificador = resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;

            return digitoVerificador == int.Parse(cuit[10].ToString());
        }

        public override string Describir()
        {
            return $"{base.Describir()} (Cuit: {cuit}) .";
        }
    }
}

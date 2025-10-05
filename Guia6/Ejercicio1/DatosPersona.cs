using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class DatosPersona : Form
    {
        public DatosPersona()
        {
            InitializeComponent();
            rbFisica.Checked = true;
        }

        private void DatosPersona_Load(object sender, EventArgs e)
        {
            
        }

        private void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            tbCUIT.Enabled = rbFisica.Checked == false;
        }
    }
}

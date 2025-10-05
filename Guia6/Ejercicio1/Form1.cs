using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List<Persona> personas;

        void ActualizarDAtos()
        {
            personas.Sort();
            lbPersonas.Items.Clear();
            foreach ( Persona p in personas)
            {
                lbPersonas.Items.Add(p);
            }
        }
        public Form1()
        {
            InitializeComponent();
            personas = new List<Persona> ();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DatosPersona VCargarPersona = new DatosPersona ();

            VCargarPersona.ShowDialog();

            bool volver = true; // bandera
            while (VCargarPersona.DialogResult == DialogResult.OK && volver) 
            {
                // tomamos los datos de los texbox
                string nombre = VCargarPersona.tbNombre.Text;
                string cuit = VCargarPersona.tbCUIT.Text;

                //Declaramos un persona, para que el tramo de try pueda capturarla
                Persona nuevaPersona = null;

                try
                {
                    if (VCargarPersona.rbFisica.Checked) { nuevaPersona = new Persona(nombre); }
                
                    if(VCargarPersona.rbJuridica.Checked) { nuevaPersona = new PersonaJuridica(nombre, cuit); }

                    if(nuevaPersona != null)
                    {
                        personas.Add(nuevaPersona);// agrego persona a la list 
                        volver = false; // ponemos bandera en false para salir del while
                        ActualizarDAtos(); // cargamos datos en el listbox


                    }
                    else { MessageBox.Show("Seleccione un tipo de persona", "Atencion"); }

                }
                catch(FormatoNombreNoValidoException fe)
                {
                    VCargarPersona.lNombreError.Text = fe.Message;
                    VCargarPersona.lNombreError.Visible = true;
                }
                catch(FormatoCUITNoValidoException ec)
                {
                    VCargarPersona.lCUITError.Text = ec.Message;
                    VCargarPersona.lCUITError.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Inesperado");
                }

                //preguntamos por la bandera -> si true volvemos a mostrar la ventana
                if (volver) { VCargarPersona.ShowDialog(); }
            
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Persona personABorrar = null;
            try
            {
                personas.Sort();
                personABorrar = lbPersonas.SelectedItem as Persona;
                int idx = personas.BinarySearch(personABorrar);

                if(idx >= 0)
                {
                    personABorrar = personas[idx];
                }
                else { MessageBox.Show("No se encontro la persona en la lista","Lo siento",MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    


                if (personABorrar != null)
                {
                    personas.Remove(personABorrar);
                    MessageBox.Show("Persona Borrada", "Exito!");
                    ActualizarDAtos();
                }
                //else
                //{
                //    MessageBox.Show("Seleccione Persona a Borrar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ups",MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatosDb;

namespace ProyectoDiscos
{
    public partial class frmAltaDisco : Form
    {
        public frmAltaDisco()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



       

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            Disco disco = new Disco();
            DiscoDatos datos = new DiscoDatos();
            
            

            try
            {
                disco.titulo = txtTitulo.Text;
                disco.cantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                disco.fechaLanzamiento = dtpFechaLanzamiento.Value;
               


                datos.agregar(disco);
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}

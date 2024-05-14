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
                disco.GeneroMusical = (Estilo)cboGeneroMusical.SelectedItem;
                disco.TipoEdicion = (TipoEdicion)cboTipoEdicion.SelectedItem;
                disco.urlImagenTapa = txtUrlImagenTapa.Text;


                datos.agregar(disco);
                MessageBox.Show("Agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {

                    MessageBox.Show("agrega la cantidad de canciones por favor");
            }
        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            EstiloDatos estiloDatos = new EstiloDatos();
            TipoEdicionDatos tipoEdicionDatos = new TipoEdicionDatos();

            try
            {
                cboGeneroMusical.DataSource = estiloDatos.listar();
                cboTipoEdicion.DataSource = tipoEdicionDatos.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagenTapa_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagenTapa.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDiscos.Load(imagen);
            }
            catch (Exception)
            {

                pbxDiscos.Load("https://th.bing.com/th/id/OIP.3MyS_cOKsArFhg6L4ebnggHaHa?w=180&h=180&c=7&r=0&o=5&pid=1.7");
            }
        }
    }
}

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
using System.IO;
using System.Configuration;        


namespace ProyectoDiscos
{
    public partial class frmAltaDisco : Form
    {
        private Disco discos = null;
        private OpenFileDialog archivo = null;
        public frmAltaDisco()
        {
            InitializeComponent();
        }
        public frmAltaDisco(Disco disco)
        {
            InitializeComponent();
            this.discos = disco; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



       

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            //Disco disco = new Disco();
            DiscoDatos datos = new DiscoDatos();
            
            

            try
            
               {
                if (discos == null) 
                    discos = new Disco();  
                
                discos.titulo = txtTitulo.Text;
                discos.cantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                discos.fechaLanzamiento = dtpFechaLanzamiento.Value;
                discos.urlImagenTapa = txtUrlImagenTapa.Text;
                discos.GeneroMusical = (Estilo)cboGeneroMusical.SelectedItem;
                discos.TipoEdicion = (TipoEdicion)cboTipoEdicion.SelectedItem;

                if (discos.Id != 0)
                {
                datos.modificar(discos);
                MessageBox.Show("Modificado exitosamente");

                }
                else
                {

                datos.agregar(discos);
                MessageBox.Show("Agregado exitosamente");
                }

                //Guardo imagen si la levantó localmente:
                if (archivo != null && !(txtUrlImagenTapa.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["carpeta-imagenes"] + archivo.SafeFileName);

                Close();
            }
            catch (Exception ex)
            {
                throw ex;
              //  MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            EstiloDatos estiloDatos = new EstiloDatos();
            TipoEdicionDatos tipoEdicionDatos = new TipoEdicionDatos();

            try
            {
                cboGeneroMusical.DataSource = estiloDatos.listar();
                cboGeneroMusical.ValueMember = "Id";
                cboGeneroMusical.DisplayMember = "Descripcion";
                cboTipoEdicion.DataSource = tipoEdicionDatos.listar();
                cboTipoEdicion.ValueMember = "Id";
                cboTipoEdicion.DisplayMember = "Descripcion";



                if (discos != null) 
                {
                   txtTitulo.Text = discos.titulo;
                   txtCantidadCanciones.Text = discos.cantidadCanciones.ToString ();
                   dtpFechaLanzamiento.Value = discos.fechaLanzamiento;
                   txtUrlImagenTapa.Text = discos.urlImagenTapa;
                   cargarImagen(discos.urlImagenTapa);
                   cboGeneroMusical.SelectedValue = discos.GeneroMusical.Id;
                   cboTipoEdicion.SelectedValue = discos.TipoEdicion.Id;



                }
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

        private void txtCantidadCanciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg; |png|*.png";
           if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagenTapa.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //guardo imagen
                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["carpeta-imagenes"] + archivo.SafeFileName);
            }
        }
    }
}
    
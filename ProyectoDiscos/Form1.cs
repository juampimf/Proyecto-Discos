using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using DatosDb;

namespace ProyectoDiscos
{
    public partial class Form1 : Form
    {
        private List<Disco> listaDiscos;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
           Disco Seleccionado = (Disco) dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(Seleccionado.urlImagenTapa);

            
        }

        private void cargar()
        {
            DiscoDatos datos = new DiscoDatos();
            try
            {
                listaDiscos = datos.listar();
                dgvDiscos.DataSource = listaDiscos;
                dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
                cargarImagen(listaDiscos[0].urlImagenTapa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaDisco alta = new frmAltaDisco();
            alta.ShowDialog();
            cargar();

        }
    }
}

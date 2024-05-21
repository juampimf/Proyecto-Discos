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
            cboCampo.Items.Add("Titulo");
            cboCampo.Items.Add("CantidadCanciones");
            cboCampo.Items.Add("GeneroMusical");
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDiscos.CurrentRow != null)
            {
           Disco Seleccionado = (Disco) dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(Seleccionado.urlImagenTapa);
            }

            
        }

        private void cargar()
        {
            DiscoDatos datos = new DiscoDatos();
            try
            {
                listaDiscos = datos.listar();
                dgvDiscos.DataSource = listaDiscos;
                ocultarColumnas();

                cargarImagen(listaDiscos[0].urlImagenTapa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ocultarColumnas()
        {
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

            frmAltaDisco modificar = new frmAltaDisco(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            DiscoDatos datos = new DiscoDatos();
            Disco seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar este disco?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                datos.eliminar(seleccionado.Id);
                cargar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if(cboCampo.SelectedIndex == -1)
            {
                MessageBox.Show("Por Favor, seleccione el campo para filtrar.");
                return true;
            }
            if(cboCriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Por Favor, seleccione el criterio para filtrar.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "CantidadCanciones")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debes cargar el filtro para numéricos...");
                     return true;
                }
                if (!soloNumeros(txtFiltroAvanzado.Text))
                {

                    MessageBox.Show("Solo nros para filtrar por un campo numerico...");
                    return true;
                }
                    

                

            }
            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            DiscoDatos datos = new DiscoDatos();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                    dgvDiscos.DataSource = datos.filtrar( campo, criterio, filtro);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

       

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaDiscos.FindAll(x => x.titulo.ToLower().Contains(filtro.ToLower()) || x.GeneroMusical.ToString().ToLower().Contains(filtro.ToLower()));
            }
            else
            {
                listaFiltrada = listaDiscos;
            }


            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "CantidadCanciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        
    }
}

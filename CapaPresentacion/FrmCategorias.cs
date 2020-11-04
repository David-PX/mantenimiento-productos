using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmCategorias : Form
    {

        private string idcategorias;
        private bool Editarse = false;
        E_categorias objEntidad = new E_categorias();
        N_categoria objNegocios = new N_categoria();
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void cerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarApp_MouseHover(object sender, EventArgs e)
        {
            cerrarApp.BackColor = Color.Gray;
        }

        private void cerrarApp_MouseLeave(object sender, EventArgs e)
        {
            cerrarApp.BackColor = Color.Transparent;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
            accionesTabla();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(txtBuscar.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(Editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text;
                    objEntidad.Descripcion = txtDes.Text;

                    objNegocios.InsertandoCategoria(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarTabla("");
                    limpiarCaja();
                }
                catch(Exception ez)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ez);
                }
            }
             if (Editarse == true)
            {

                try
                {
                    objEntidad.IdCategorias = Convert.ToInt32(idcategorias);
                    objEntidad.Nombre = txtNombre.Text.ToString();
                    objEntidad.Descripcion = txtDes.Text.ToString();

                    objNegocios.EditandoCategoria(objEntidad);

                    MessageBox.Show("Se edito el registro");
                    MostrarTabla("");
                    limpiarCaja();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }

            }
        }



        public void accionesTabla()
        {
            tablaCategoria.Columns[0].Visible = false;
            tablaCategoria.Columns[1].Width = 60;
            tablaCategoria.Columns[2].Width = 170;


            tablaCategoria.ClearSelection();

        }


        public void MostrarTabla(string buscar)
        {
            N_categoria objNegocio = new N_categoria();
            tablaCategoria.DataSource = objNegocio.ListarCategoria(buscar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();

        }

        private void limpiarCaja()
        {
            txtCod.Text = "";
            txtNombre.Text = "";
            txtDes.Text = "";
            txtNombre.Focus();
            Editarse = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                Editarse = true;
                idcategorias = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCod.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDes.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count > 0)
            {
                objEntidad.IdCategorias = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocios.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                MostrarTabla("");
                limpiarCaja();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que quieres eliminar");
            }
        }
    }
}

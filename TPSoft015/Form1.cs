using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TPSoft015
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            visualizar(null);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcular();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod = txtCod.Text;
            visualizar(cod);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtId.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            txtCod.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtNom.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtApeP.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            txtApeM.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            txtAnotacion.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            txtNota1.Text = dgvProductos.CurrentRow.Cells[6].Value.ToString();
            txtNota2.Text = dgvProductos.CurrentRow.Cells[7].Value.ToString();
            txtNota3.Text = dgvProductos.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Salir", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                int id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                Control_Alumnos conProd = new Control_Alumnos();
                conProd.eliminar(id);
                limpiar();
                visualizar(null);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void visualizar(string filtro)
        {
            Control_Alumnos opAlu = new Control_Alumnos();
            dgvProductos.DataSource = opAlu.consulta(filtro);
        }

        private void limpiar()
        {
            txtId.Text = string.Empty;
            txtCod.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtApeP.Text = string.Empty;
            txtApeM.Text = string.Empty;
            txtAnotacion.Text = string.Empty;
            txtNota1.Text = string.Empty;
            txtNota2.Text = string.Empty;
            txtNota3.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtProm.Text = string.Empty;
            txtSituacion.Text = string.Empty;
            txtCod.Focus();
        }

        private void guardar()
        {
            bool sentinela = false;
            Alumnos prod = new Alumnos();
            prod.Codigo = txtCod.Text;
            prod.Nombre = txtNom.Text;
            prod.Apa = txtApeP.Text;
            prod.Ama = txtApeM.Text;
            prod.Anotacion = txtAnotacion.Text;
            prod.Nota1 = int.Parse(txtNota1.Text);
            prod.Nota2 = int.Parse(txtNota2.Text);
            prod.Nota3 = int.Parse(txtNota3.Text);

            Control_Alumnos conAlumn = new Control_Alumnos();
            if (txtId.Text != "")
            {
                prod.Id = int.Parse(txtId.Text);
                sentinela = conAlumn.actualizar(prod);
            }
            else
            {
                sentinela = conAlumn.insertar(prod);
            }
            if (sentinela)
            {
                MessageBox.Show("Registro guardado");
                limpiar();
                visualizar(null);
            }
        }

        private void calcular()
        {
            if (string.IsNullOrEmpty(txtCod.Text) || string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtApeP.Text)
                || string.IsNullOrEmpty(txtApeM.Text) || string.IsNullOrEmpty(txtNota1.Text)
                 || string.IsNullOrEmpty(txtNota2.Text) || string.IsNullOrEmpty(txtNota3.Text))
            {
                MessageBox.Show("Ingrese todos los datos");
            }
            else
            {
                Operaciones opAlu = new Operaciones();
                short n1 = short.Parse(txtNota1.Text);
                short n2 = short.Parse(txtNota2.Text);
                short n3 = short.Parse(txtNota3.Text);
                int prom = opAlu.promedio(n1, n2, n3);
                int edad = opAlu.calcEdad(dtpFechaNa.Value);
                string situacion = opAlu.estado(prom);
                txtProm.Text = prom.ToString();
                txtEdad.Text = edad.ToString();
                txtSituacion.Text = situacion;
            }
        }
    }
}

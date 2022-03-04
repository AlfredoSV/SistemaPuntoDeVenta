﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Servicios;
using Dominio.Entidades;

namespace PuntoDeVenta.ProductosForms
{
    public partial class Productos : Form
    {
        private readonly ServicioProductos _servicioProductos;
        private Usuario _usuarioLogueado;

        public Productos()
        {
            try
            {

                _servicioProductos = ServicioProductos.Instacia;
                InitializeComponent();
                var productos = _servicioProductos.ConsultarProductosBD();
                dataGridViewProductos.DataSource = productos;


            }
            catch (Exception exception)
            {

                throw exception;
            }

        }


        private void Productos_Load(object sender, EventArgs e)
        {


        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Columna:" + e.ColumnIndex.ToString());

            MessageBox.Show(dataGridViewProductos.Rows[e.RowIndex].Cells[2].Value.ToString());

        }

        private void btnSalirProductos_Click(object sender, EventArgs e)
        {
            var inicioForm = new Inicio();
            inicioForm.Show(_usuarioLogueado);
            this.Close();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            //Validación

            /*var stock = (int)(txtStockProducto.Value);
            var nombre = txtNombreProducto.Text.Trim();
            var precio = Convert.ToDecimal(txtPrecioProducto.Text.Trim());
            var descripcion = txtDescripcionProducto.Text.Trim();
            var proveedor = comboProveedorProducto.SelectedItem;


            try
            {
                _servicioProductos.GuardarNuevoProducto(stock, nombre, descripcion, precio, proveedor,);
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public void Show(Usuario usuario)
        {

            _usuarioLogueado = usuario;
            base.Show();
        }

        private void btnLimpiarFormProducto_Click(object sender, EventArgs e)
        {
            txtNombreProducto.Text = "";
            txtPrecioProducto.Text = "";
            txtDescripcionProducto.Text = "";
            txtStockProducto.Value = 0;
        }
    }
}

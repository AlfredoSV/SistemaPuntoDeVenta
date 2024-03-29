﻿using Aplicacion.Servicios;
using Dominio;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.ProductosForms
{
    public partial class CargaMasiva : Form
    {
        private static CargaMasiva _instancia;
        private ServicioExcelProductos _servicioExcelProductos;

        public static CargaMasiva Instancia
        {
            get
            {

                if (_instancia == null)
                    _instancia = new CargaMasiva();
                return _instancia;

            }
            private set { }
        }


        private CargaMasiva()
        {
            _servicioExcelProductos = ServicioExcelProductos.Instancia;
            InitializeComponent();
        }

        private void btnSalirCargaMasiva_Click(object sender, EventArgs e)
         => this.Close();
            
        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (openFile.SafeFileName.Split('.')[1].Equals("xlsx"))
                    {
                        using (MemoryStream memory = new MemoryStream())
                        {
                            using (FileStream fileStream = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read))
                            {
                                fileStream.CopyTo(memory);                           
                                List<Producto> res = _servicioExcelProductos.LeerExcelProductos(memory).ToList();
                                dataGridViewProductosCargados.DataSource = res;
                            }
                        }

                    }
                    else
                    {
                        throw new ExcepcionComun("Aplicación", "El documento no tiene el formato correcto", "LeerExcelProductos");

                    }
                }
            }
            catch (ExcepcionComun excepcionComun)
            {
                MessageBox.Show(excepcionComun.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sucedió un error no controlado, favor de contactar con el administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarCarga_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de cargar los siguientes productos?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if(DialogResult.OK == resultado)
            {

            }
        }
    }
}

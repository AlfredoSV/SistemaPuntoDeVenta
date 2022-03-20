﻿

using Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class Login : Form
    {
        private static Login _instancia;
        private readonly ServicioAutenticacion _servicioAutenticacion;

        public static Login Instancia
        {
            get
            {

                if (_instancia == null)
                    _instancia = new Login();

                return _instancia;

            }
        }

        public Login()
        {
            _servicioAutenticacion = ServicioAutenticacion.Instacia;
            InitializeComponent();
        }


        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            await Ingresar();
        }


        public void CerrarSesion()
        {
            this.Show();
            txtContrasenia.Text = "";
            txtUsuario.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private async void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                await Ingresar();

        }

        private async void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                await Ingresar();
        }

        public new void Show()
        {
            txtContrasenia.Text = "";
            txtUsuario.Text = "";
            base.Show();
        }

        private async Task Ingresar()
        {
            try
            {
                var usuario = txtUsuario.Text.Trim();
                var contrasenia = txtContrasenia.Text.Trim();
                var inicioForm = new Inicio();


                if (!usuario.Equals("") && !contrasenia.Equals(""))
                {


                    if (await _servicioAutenticacion.ValidarUsuario(usuario, contrasenia))
                    {
                        this.Hide();
                        inicioForm.Show(await _servicioAutenticacion.ConsultarUsuario(usuario, contrasenia));
                    }
                    else
                    {
                        MessageBox.Show("El usuario y/o contraseña son incorrectos o el usuario no se ecuentra activo", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Favor de ingresar usuario y/o contraseña", "Alterta");
                }

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnRegistrarme_Click(object sender, EventArgs e)
        {
            var registroUsuario = new RegistroUsuario();
            registroUsuario.ShowDialog();
        }
    }
}

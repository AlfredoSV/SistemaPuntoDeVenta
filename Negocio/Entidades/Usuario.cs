﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Entidades
{
    public class Usuario
    {
        private Guid _idUsuario;
        private string _nombreUsuario;
        private string _contrsenia;
        private DateTime _fechayHoraAlta;
        private Sucursal _sucursal;
        private Rol _rol;

        public Guid IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contrsenia { get => _contrsenia; set => _contrsenia = value; }
        public DateTime FechayHoraAlta { get => _fechayHoraAlta; set => _fechayHoraAlta = value; }
        internal Sucursal Sucursal { get => _sucursal; set => _sucursal = value; }
        internal Rol Rol { get => _rol; set => _rol = value; }

        public Usuario(Guid idUsuario, string nombreUsuario, string contrsenia, DateTime fechayHoraAlta, Sucursal sucursal, Rol rol)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contrsenia = contrsenia;
            FechayHoraAlta = fechayHoraAlta;
            Sucursal = sucursal;
            Rol = rol;
        }


        public static Usuario CrearUsuario(Guid idUsuario, string nombreUsuario, string contrsenia, DateTime fechayHoraAlta, Sucursal sucursal, Rol rol)
        {
            return new Usuario(idUsuario, nombreUsuario, contrsenia, fechayHoraAlta, sucursal, rol);
        }

    }
}

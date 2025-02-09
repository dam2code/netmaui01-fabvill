using System;
using System.Collections.Generic;
using MauiApp6.Modelos;

namespace MauiApp6.Controlador
{
    internal class BaseControlador
    {
        protected List<Parte> PartesDelUsuario
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.TokenDeAutorizacion))
                {
                    return null;
                }

                if (!FactoryPartes.Partes.ContainsKey(this.TokenDeAutorizacion))
                {
                    return null;
                }

                var resultado = FactoryPartes.Partes[this.TokenDeAutorizacion];

                return resultado.Item2;
            }
        }

        protected bool VerificarAutorizacion()
        {
            FactoryPartes.LimpiarDatosObsoletos();

            try
            {
                if (string.IsNullOrWhiteSpace(this.TokenDeAutorizacion))
                {
                    return false;
                }

                if (!FactoryPartes.Partes.ContainsKey(this.TokenDeAutorizacion))
                {
                    return false;
                }

                return true;
            }
            catch
            {
            }

            return false;
        }

        protected string TokenDeAutorizacion
        {
            get
            {
                string tokenDeAutorizacion = string.Empty;

                tokenDeAutorizacion = "Aquí obtendrás el token desde el encabezado de solicitud";

                return tokenDeAutorizacion;
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using MauiApp6.Modelos;

namespace MauiApp6.Controlador
{
    internal class LoginControlador
    {
        public async Task<string> ObtenerTokenAutorizacion()
        {
            try
            {
                var tokenDeAutorizacion = Guid.NewGuid().ToString();

                FactoryPartes.Inicializar(tokenDeAutorizacion);

                return tokenDeAutorizacion;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

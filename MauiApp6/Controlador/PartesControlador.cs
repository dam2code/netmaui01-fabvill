using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsService.Models;

namespace MauiApp6.Controlador
{
    internal class PartesControlador
    {
        public static string ObtenerTokenAutorizacion()
        {
            try
            {
                var authorizationToken = Guid.NewGuid().ToString();

                PartsFactory.Initialize(authorizationToken);

                return authorizationToken;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}

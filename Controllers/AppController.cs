using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    public class AppController
    {
        [HttpGet(Name = "GetAppName")]
        public string GetNombreApp()
        {
            //Interpreté que "con el nombre de la app a elección" significa que le pongo nombre a la app yo 
            string AppName = "Mi Primera API";
            return AppName;
        }
    }
}

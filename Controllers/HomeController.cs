using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NETPortafolio.Models;
using NETPortafolio.Services;

namespace NETPortafolio.Controllers
{
    /*
     * Home controller, sabemos que es un controller por que hereda de la clase Controller,
     * que nos permite acceder a sus métodos auxiliares para manejar las vistas y las respuestas HTTP.
     * Por ejemplo: IActionResult, View(), RedirectToAction(), etc.
     */
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly RepositoryProyectos _repositoryProyectos;

        public HomeController(ILogger logger, RepositoryProyectos repositoryProyectos)
        {
            _logger = logger;
            _repositoryProyectos = repositoryProyectos;
        }
        /*
         * IActionResult son las funciones que se ejecutan cuando hacemos una petición HTTP a una ruta específica.
         */
        public IActionResult Index()
        {
            /*
             * View() es un método auxiliar que devuelve una vista asociada a la acción del controlador.
             */
            var proyectos = _repositoryProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

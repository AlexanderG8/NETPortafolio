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
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryProyectos _repositoryProyectos;
        private readonly IServiceEmail _serviceEmail;

        public HomeController(ILogger<HomeController> logger, IRepositoryProyectos repositoryProyectos, IServiceEmail serviceEmail)
        {
            _logger = logger;
            _repositoryProyectos = repositoryProyectos;
            _serviceEmail = serviceEmail;
        }
        /*
         * IActionResult son las funciones que se ejecutan cuando hacemos una petición HTTP a una ruta específica.
         */
        public IActionResult Index()
        {
            _logger.LogInformation("Ejecutando el método Index del HomeController");
            var proyectos = _repositoryProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            /*
             * View() es un método auxiliar que devuelve una vista asociada a la acción del controlador.
             */
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Proyectos()
        {
            var proyectos = _repositoryProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        public IActionResult Contacto() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactViewModel contactViewModel) 
        {
            await _serviceEmail.Enviar(contactViewModel);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias() 
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

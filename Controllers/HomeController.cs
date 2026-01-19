using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NETPortafolio.Models;

namespace NETPortafolio.Controllers
{
    /*
     * Home controller, sabemos que es un controller por que hereda de la clase Controller,
     * que nos permite acceder a sus métodos auxiliares para manejar las vistas y las respuestas HTTP.
     * Por ejemplo: IActionResult, View(), RedirectToAction(), etc.
     */
    public class HomeController : Controller
    {
        /*
         * IActionResult son las funciones que se ejecutan cuando hacemos una petición HTTP a una ruta específica.
         */
        public IActionResult Index()
        {
            /*
             * View() es un método auxiliar que devuelve una vista asociada a la acción del controlador.
             */
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos() 
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET Core.",
                    ImagenURL = "/img/amazon.png",
                    Link = "https://amazon.com"
                },
                new Proyecto
                {
                    Titulo = "New York Times",
                    Descripcion = "Pagina de Noticias React.",
                    ImagenURL = "/img/nyt.png",
                    Link = "https://nytimes.com"
                },
                new Proyecto
                {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades.",
                    ImagenURL = "/img/reddit.png",
                    Link = "https://reddit.com"
                },
                new Proyecto
                {
                    Titulo = "Steam",
                    Descripcion = "Tienda en línea para comprar videojuegos.",
                    ImagenURL = "/img/steam.png",
                    Link = "https://store.steampowered.com"
                }
            };
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

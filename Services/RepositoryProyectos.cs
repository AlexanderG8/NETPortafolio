using NETPortafolio.Models;

namespace NETPortafolio.Services
{
    public interface IRepositoryProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositoryProyectos : IRepositoryProyectos
    {
        public List<Proyecto> ObtenerProyectos()
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
    }
}

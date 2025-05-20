using System.Diagnostics;
using JazzDBMVC.Data;
using JazzDBMVC.Gateways;
using JazzDBMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JazzDBMVC.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public string ArtistList { get; private set; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Index

        public IActionResult Index()
        {
            return View();
        }

        //Get /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Get /Home/Albums
        public IActionResult Albums()
        {
            var albumWithArtists = 
                (from a in _context.Albums
                join aa in _context.AlbumArtists on a.AlbumId equals aa.AlbumId
                join ar in _context.Artists on aa.ArtistId equals ar.ArtistId
                select new AlbumWithArtist
                {
                    AlbumId = a.AlbumId,
                    AlbumName = a.AlbumName,
                    AlbumImageUrl = a.AlbumImageUrl,
                    LabelName = a.LabelName,
                    Copyrights = a.Copyrights,
                    ReleaseDate = a.ReleaseDate,
                    AlbumBlurb = a.AlbumBlurb,
                    AlbumUrl = a.AlbumUrl,
                    ArtistId = ar.ArtistId,
                    ArtistName = ar.ArtistName
                }).ToList();
            return View(albumWithArtists);
        }

        public IActionResult Artists()
        {
            var artists = _context.Artists.ToList();
            return View(artists);
        }

        // Get /Create
        [HttpGet]
        public IActionResult CreateAlbum()
        {
            var artists = _context.Artists.ToList();
            ViewBag.Artists = new SelectList(artists, "ArtistId", "ArtistName");

            var model = new AlbumWithArtist();
            return View(model);
        }

        // Post /Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAlbum(AlbumWithArtist albumWithArtist)
        {
            if (ModelState.IsValid)
            {
                var album = new Album
                {
                    AlbumName = albumWithArtist.AlbumName,
                    AlbumImageUrl = albumWithArtist.AlbumImageUrl,
                    LabelName = albumWithArtist.LabelName,
                    Copyrights = albumWithArtist.Copyrights,
                    ReleaseDate = albumWithArtist.ReleaseDate,
                    AlbumBlurb = albumWithArtist.AlbumBlurb,
                    AlbumUrl = albumWithArtist.AlbumUrl
                };

                _context.Albums.Add(album);
                _context.SaveChanges();  // Ensure album is saved first to get the AlbumId

                var albumArtist = new AlbumArtist
                {
                    AlbumId = album.AlbumId,
                    ArtistId = albumWithArtist.ArtistId
                };

                _context.AlbumArtists.Add(albumArtist);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // If ModelState is not valid, reload the artist list and return to the view
            ViewBag.Artists = _context.Artists
                .Select(a => new { a.ArtistId, a.ArtistName })
                .ToList();

            return View(albumWithArtist);
        }

        [HttpGet]
        public IActionResult CreateArtist()
        {
            return View(); // Return a blank view for artist creation
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Artists.Add(artist);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to main page or artist list
            }

            return View(artist); // If invalid, return to the same view with errors
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var albumWithArtist = (from album in _context.Albums
                                   join albumArtist in _context.AlbumArtists on album.AlbumId equals albumArtist.AlbumId
                                   join artist in _context.Artists on albumArtist.ArtistId equals artist.ArtistId
                                   where album.AlbumId == id
                                   select new AlbumWithArtist
                                   {
                                       AlbumId = album.AlbumId,
                                       AlbumName = album.AlbumName,
                                       ArtistId = artist.ArtistId,
                                       ArtistName = artist.ArtistName,
                                       AlbumImageUrl = album.AlbumImageUrl,
                                       LabelName = album.LabelName,
                                       Copyrights = album.Copyrights,
                                       ReleaseDate = album.ReleaseDate,
                                       AlbumBlurb = album.AlbumBlurb,
                                       AlbumUrl = album.AlbumUrl
                                   }).FirstOrDefault();

            if (albumWithArtist == null)
            {
                return NotFound();
            }

            return View(albumWithArtist);
        }

        [HttpPost]
        public IActionResult Edit(AlbumWithArtist model)
        {
            if (ModelState.IsValid)
            {
                var albumWithArtist = _context.AlbumWithArtists.Find(model.AlbumId);
                if (albumWithArtist == null)
                {
                    return NotFound();
                }

                albumWithArtist.AlbumName = model.AlbumName;
                albumWithArtist.AlbumImageUrl = model.AlbumImageUrl;
                albumWithArtist.LabelName = model.LabelName;
                albumWithArtist.ReleaseDate = model.ReleaseDate;
                albumWithArtist.AlbumBlurb = model.AlbumBlurb;
                albumWithArtist.AlbumUrl = model.AlbumUrl;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [HttpPost]
        public IActionResult DeleteArtistConfirmed(int id)
        {
            var artist = _context.Artists.Find(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}

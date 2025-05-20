using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JazzDBMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace JazzDBMVC.Gateways
{
    public class DBGateway
    {
        private readonly ApplicationDbContext _context;

        public DBGateway(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all albums
        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        // Get a single album by ID
        public async Task<Album?> GetAlbumByIdAsync(int albumId)
        {
            return await _context.Albums.FindAsync(albumId);
        }

        // Create a new album
        public async Task CreateAlbumAsync(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
        }

        // Update an existing album
        public async Task UpdateAlbumAsync(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }

        // Delete an album by ID
        public async Task DeleteAlbumAsync(int albumId)
        {
            var album = await _context.Albums.FindAsync(albumId);
            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }
    }
}
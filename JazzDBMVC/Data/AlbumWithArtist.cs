namespace JazzDBMVC.Data
{
    public class AlbumWithArtist
    {
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public string AlbumImageUrl { get; set; }

        public string? LabelName { get; set; }

        public string? Copyrights { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public string? AlbumBlurb { get; set; }

        public string? AlbumUrl { get; set; }
    }
}

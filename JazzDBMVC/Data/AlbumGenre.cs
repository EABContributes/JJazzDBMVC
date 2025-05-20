using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class AlbumGenre
{
    public int TrackId { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}

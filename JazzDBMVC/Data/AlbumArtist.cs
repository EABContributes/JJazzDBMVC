using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class AlbumArtist
{
    public int ArtistId { get; set; }

    public int AlbumId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual Artist Artist { get; set; } = null!;
}

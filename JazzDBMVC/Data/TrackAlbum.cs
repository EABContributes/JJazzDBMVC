using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class TrackAlbum
{
    public int TrackId { get; set; }

    public int AlbumId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}

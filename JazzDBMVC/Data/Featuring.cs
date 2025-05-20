using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class Featuring
{
    public int TrackId { get; set; }

    public int ArtistId { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Track Track { get; set; } = null!;
}

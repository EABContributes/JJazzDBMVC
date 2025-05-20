using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string ArtistName { get; set; } = null!;

    public string ArtistUrl { get; set; } = null!;

    public string? ArtistBlurb { get; set; }
}

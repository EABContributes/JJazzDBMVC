using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class Track
{
    public int TrackId { get; set; }

    public string TrackName { get; set; } = null!;

    public int TrackDuration { get; set; }

    public string TrackUrl { get; set; } = null!;

    public string DiscNumber { get; set; } = null!;

    public int TrackNumber { get; set; }
}

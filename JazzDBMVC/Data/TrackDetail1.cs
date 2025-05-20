using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class TrackDetail1
{
    public int TrackId { get; set; }

    public decimal? Danceability { get; set; }

    public decimal? Energy { get; set; }

    public int? KeySignature { get; set; }

    public decimal? Loudness { get; set; }

    public short? Mode { get; set; }

    public decimal? Speechiness { get; set; }

    public decimal? Acousticness { get; set; }

    public decimal? Instrumentalness { get; set; }

    public decimal? Liveness { get; set; }

    public decimal? Valence { get; set; }

    public decimal? Tempo { get; set; }

    public int? TimeSignature { get; set; }

    public virtual Track Track { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class Album
{
    public int AlbumId { get; set; }

    public string AlbumName { get; set; }

    public string AlbumImageUrl { get; set; }

    public string? LabelName { get; set; }

    public string? Copyrights { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string? AlbumBlurb { get; set; }

    public string? AlbumUrl { get; set; }
}
